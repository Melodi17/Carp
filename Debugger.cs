using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Carp.objects.types;

namespace Carp;

public class Debugger
{
    public int[] Breakpoints { get; set; } = Array.Empty<int>();
    
    private int _port;
    private TcpListener _listener;
    public bool Attached { get; private set; } = false;
    
    public Debugger(int port = 8080)
    {
        this._port = port;
    }
    
    public void Start()
    {
        this._listener = new(IPAddress.Any, this._port);
        this._listener.Start(1);
        Console.WriteLine($"Debugger listening on port {this._port}");
        while (true)
        {
            TcpClient client = this._listener.AcceptTcpClient();
            Console.WriteLine("Debugger attached");
            NetworkStream stream = client.GetStream();
            this.HandleClient(client, stream);
        }
    }
    
    public void StartAsync()
    {
        Thread thread = new(this.Start);
        thread.IsBackground = true;
        thread.Start();
    }
    
    public void Stop()
    {
        this._listener.Stop();
    }

    private void HandleClient(TcpClient client, NetworkStream stream)
    {
        this.Attached = true;
        
        try
        {
            BinaryReader reader = new(stream);
            BinaryWriter writer = new(stream);

            while (client.Connected)
            {
                // read an int32
                int len = reader.ReadInt32();

                // read the message
                byte[] buffer = new byte[len];
                stream.Read(buffer, 0, len);
                string msg = Encoding.UTF8.GetString(buffer);

                // handle the message
                string response = this.HandleMessage(msg);
                // send the response
                // write the length of the response
                writer.Write(response.Length);
                
                // write the response
                writer.Write(Encoding.UTF8.GetBytes(response));
            }
        }
        catch (Exception e)
        {
            return;
        }
        finally
        {
            this.Attached = false;
        }
    }
    
    private string HandleMessage(string msg)
    {
        string[] parts = msg.Split(" ");
        string command = parts[0];
        string[] args = parts.Length > 1 ? parts[1..] : Array.Empty<string>();
        
        switch (command)
        {
            case "kill":
                {
                    // kill the process
                    int pid = Environment.ProcessId;
                    // run taskkill /f /pid pid
                    ProcessStartInfo info = new("taskkill", $"/f /pid {pid}");
                    Process.Start(info);
                    this.Stop();
                    return "ok";
                }
            
            case "pause":
                {
                    CarpInterpreter.Instance.Paused = true;
                    return "ok";
                }
            
            case "resume":
                {
                    CarpInterpreter.Instance.Paused = false;
                    return "ok";
                }
            
            case "step":
                {
                    CarpInterpreter.Instance.Step();
                    return "ok";
                }

            case "info":
                {
                    Flags f = Flags.Instance;
                    CarpInterpreter i = CarpInterpreter.Instance;
                    
                    StringBuilder sb = new();
                    sb.Append($"flags,");
                    sb.Append($"treat_warnings_as_errors: {f.StrictWarnings},");
                    sb.Append($"debug: {f.Debug},");
                    sb.Append($"implicit_casting: {f.ImplicitCasting},");
                    sb.Append($"loaded_from_file: {f.LoadedFromFile},");
                    sb.Append($"execution_context: {f.ExecutionContext},");
                    sb.Append($"interpreter,");
                    sb.Append($"paused: {i.Paused},");
                    sb.Append($"current_line: {i.CurrentLine}");
                    
                    return sb.ToString();
                }
            
            case "executioncontext":
                {
                    return Flags.Instance.LoadedFromFile 
                        ? File.ReadAllText(Flags.Instance.ExecutionContext) 
                        : Flags.Instance.ExecutionContext;
                }

            case "breakpoint":
                {
                    try
                    {
                        int[] breakpoints = args.Select(int.Parse).ToArray();
                        this.Breakpoints = breakpoints;
                        return "ok";
                    }
                    catch (Exception e)
                    {
                        return "invalid breakpoint";
                    }
                }
            
            case "eval":
                {
                    string code = string.Join(" ", args);
                    CarpObject response = Program.RunString(CarpInterpreter.Instance, code);
                    return response.Repr();
                }

            default:
                return "unknown command";
        }
    }
}
