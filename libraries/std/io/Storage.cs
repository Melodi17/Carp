namespace Carp.libraries.std.io;

using exceptions;

public static class Storage
{
    public static string Current => Directory.GetCurrentDirectory();
    
    public static string Read(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            throw new PathNotFoundException(path);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error reading file at '{path}': {ex.Message}");
        }
    }
    
    public static void Write(string path, string content)
    {
        try
        {
            File.WriteAllText(path, content);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error writing to file at '{path}': {ex.Message}");
        }
    }
    
    public static byte[] ReadData(string path)
    {
        try
        {
            return File.ReadAllBytes(path);
        }
        catch (FileNotFoundException)
        {
            throw new PathNotFoundException(path);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error reading data from '{path}': {ex.Message}");
        }
    }
    
    public static void WriteData(string path, byte[] data)
    {
        try
        {
            File.WriteAllBytes(path, data);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error writing data to '{path}': {ex.Message}");
        }
    }
    
    public static bool Exists(string path) => File.Exists(path) || Directory.Exists(path);
    public static bool IsDirectory(string path) => Directory.Exists(path);
    public static bool IsFile(string path) => File.Exists(path);

    public static void Delete(string path)
    {
        try
        {
            if (File.Exists(path))
                File.Delete(path);
            else if (Directory.Exists(path))
                Directory.Delete(path, true);
            else
                throw new PathNotFoundException(path);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error deleting path '{path}': {ex.Message}");
        }
    }
}

public class PathNotFoundException(string path) 
    : RuntimeException($"Path '{path}' not found.");