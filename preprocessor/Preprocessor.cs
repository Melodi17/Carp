using System.Text;
using System.Text.RegularExpressions;
using Antlr4.Runtime;

namespace Carp.preprocessor;

public class Preprocessor
{
    internal class PrimitiveToken
    {
        public string Value { get; set; }
        public PrimitiveTokenType Type { get; set; }
        
        public PrimitiveToken(string value, PrimitiveTokenType type)
        {
            this.Value = value;
            this.Type = type;
        }
        
        public override string ToString()
        {
            return $"[{this.Type}] {this.Value}";
        }
    }

    internal enum PrimitiveTokenType
    {
        Identifier,
        Constant,
        Operator,
        Junk,
    }
    
    internal record Macro(string Name, List<string> Arguments, List<PrimitiveToken> Body);
    
    private string _source;
    private static List<Macro> macros = new();
    
    public Preprocessor(string source)
    {
        this._source = source;
    }

    private IEnumerable<PrimitiveToken> FastLex()
    {
        char[] junk = new[] {' ', '\t', '\n', '\r'};

        StringReader sr = new(this._source);
        
        bool IsId(char c) => char.IsLetter(c) || char.IsNumber(c) || c == '_';

        char Next()
        {
            int ch = sr.Read();
            if (ch == -1)
                return '\0';
            return (char) ch;
        }
        
        char Peek()
        {
            int ch = sr.Peek();
            if (ch == -1)
                return '\0';
            return (char) ch;
        }
        
        string Until(char c)
        {
            StringBuilder sb = new();
            while (Peek() != c && Peek() != '\0')
            {
                sb.Append(Next());
            }
            return sb.ToString();
        }

        string UntilNotId()
        {
            StringBuilder sb = new();
            while (IsId(Peek()) && Peek() != '\0')
            {
                sb.Append(Next());
            }
            return sb.ToString();
        }

        char ch = Next();
        while (ch != '\0')
        {
            if (junk.Contains(ch))
            {
                yield return new(ch.ToString(), PrimitiveTokenType.Junk);
            }
            
            else if (char.IsLetter(ch) || ch == '_')
            {
                string id = UntilNotId();
                yield return new(ch + id, PrimitiveTokenType.Identifier);
            }
            
            else if (char.IsNumber(ch))
            {
                string num = UntilNotId();
                yield return new(ch + num, PrimitiveTokenType.Constant);
            }
            
            else if (ch == '\'')
            {
                // string str = Until('\'');
                // str += Next();
                // yield return new(ch + str, PrimitiveTokenType.Constant);
                
                // lets add escaping support
                StringBuilder text = new();
                bool escaped = false;
                while (!(!escaped && Peek() == '\''))
                {
                    char c = Next();
                    if (c == '\\')
                    {
                        escaped = true;
                        continue;
                    }
                
                    if (escaped)
                    {
                        text.Append('\\');
                        text.Append(c);
                        // switch (c)
                        // {
                        //     // case 'n':
                        //     //     text.Append('\n');
                        //     //     break;
                        //     // case 't':
                        //     //     text.Append('\t');
                        //     //     break;
                        //     // case 'r':
                        //     //     text.Append('\r');
                        //     //     break;
                        //     case '\\':
                        //         text.Append('\\');
                        //         break;
                        //     case '\'':
                        //         text.Append('\'');
                        //         break;
                        //     // case '0':
                        //     //     text.Append('\0');
                        //     //     break;
                        //     default:
                        //         throw new CarpError.PreprocessorError($"Unknown escape sequence \\{c}");
                        // }
                        escaped = false;
                    }
                    else
                        text.Append(c);
                }
                
                // string textStr = text.ToString();
                // if (textStr.Contains("\'"))
                // {
                //     // this is a complex string
                // }
                
                
                yield return new(ch + text.ToString() + Next(), PrimitiveTokenType.Constant);
            }

            else
            {
                yield return new(ch.ToString(), PrimitiveTokenType.Operator);
            }
            ch = Next();
        }
    }
    
    

    public string Process()
    {
        StringBuilder sb = new();
        
        ObjectStream<PrimitiveToken> stream = new(this.FastLex());
        
        string ReadJunk()
        {
            StringBuilder sb = new();
            while (stream.HasNext && stream.Peek().Type == PrimitiveTokenType.Junk)
            {
                sb.Append(stream.Next().Value);
            }
            return sb.ToString();
        }
        
        string UntilNewlineStr()
        {
            StringBuilder sb = new();
            while (stream.HasNext && !(stream.Peek().Type == PrimitiveTokenType.Junk 
                       && stream.Peek().Value == "\n"))
            {
                sb.Append(stream.Next().Value);
            }
            return sb.ToString();
        }
        
        List<PrimitiveToken> UntilNewline()
        {
            List<PrimitiveToken> pattern = new();
            while (stream.HasNext && !(stream.Peek().Type == PrimitiveTokenType.Junk 
                                       && stream.Peek().Value == "\n"))
            {
                pattern.Add(stream.Next());
            }
            return pattern;
        }

        List<PrimitiveToken> Until(params string[] keywords)
        {
            List<PrimitiveToken> pattern = new();
            while (stream.HasNext && !(stream.Peek().Type == PrimitiveTokenType.Identifier 
                                       && keywords.Contains(stream.Peek().Value)))
            {
                pattern.Add(stream.Next());
            }
            return pattern;
        }
        
        foreach (PrimitiveToken token in stream)
        {
            if (token.Type == PrimitiveTokenType.Identifier
                && token.Value == "import")
            {
                sb.Append("import");
                // do whatever
                sb.Append(UntilNewlineStr());
                // allow main parser to differentiate
                sb.Append(";");
                continue;
            }
            if (token.Type == PrimitiveTokenType.Operator
                && token.Value == "#")
            {
                if (stream.HasNext && stream.Peek().Type == PrimitiveTokenType.Identifier)
                {
                    PrimitiveToken next = stream.Next();
                    if (next.Value == "include")
                    {
                        ReadJunk();
                        string path = UntilNewlineStr();
                        sb.Append(Preprocessor.Include(path));
                    }
                    else if (next.Value == "define")
                    {
                        // format: #define [pattern] (with [identifier,]*)? as [pattern]
                        // example: #define get with src, path as src.path
                        // exeample: #define neg with x as -x
                        ReadJunk();
                        List<PrimitiveToken> pattern = Until("with", "as");
                        if (pattern.Count == 0)
                            throw new CarpError.PreprocessorError("Expected pattern after #define");
                        
                        if (!stream.HasNext)
                            throw new CarpError.PreprocessorError("Expected 'with' or 'as' after pattern");

                        PrimitiveToken x = stream.Next();
                        List<string> arguments = new();
                        if (x.Value == "with")
                        {
                            do
                            {
                                ReadJunk();
                                if (!stream.HasNext)
                                    throw new CarpError.PreprocessorError("Expected identifier after 'with'");
                                
                                PrimitiveToken arg = stream.Next();
                                
                                if (arg.Type != PrimitiveTokenType.Identifier)
                                    throw new CarpError.PreprocessorError("Expected identifier after 'with'");
                                
                                arguments.Add(arg.Value);
                            } while (stream.HasNext && stream.Next().Value == ",");
                        }
                        
                        ReadJunk();

                        if (!stream.HasNext)
                            throw new CarpError.PreprocessorError("Expected 'as' after pattern");
                        
                        if (x.Value != "as" && stream.Next().Value != "as")
                            throw new CarpError.PreprocessorError("Expected 'as' after pattern");
                        
                        List<PrimitiveToken> body = UntilNewline();
                        Macro macro = new(pattern[0].Value, arguments, body);
                        macros.Add(macro);
                    }
                    else
                    {
                        throw new CarpError.PreprocessorError($"Unknown preprocessor directive {next.Value}");
                    }
                }
                else
                {
                    throw new CarpError.PreprocessorError("Expected identifier after #");
                }
            }
            else if (token.Type == PrimitiveTokenType.Identifier)
            {
                Macro macro = macros.FirstOrDefault(x => x.Name == token.Value);
                if (macro != null)
                {
                    List<List<PrimitiveToken>> args = new();
                    if (stream.HasNext && stream.Peek().Value == "(")
                    {
                        stream.Next();
                        do 
                        {
                            ReadJunk();
                            if (!stream.HasNext)
                                throw new CarpError.PreprocessorError("Expected argument after '('");
                            
                            // until comma or )
                            List<PrimitiveToken> arg = new();
                            while (stream.HasNext && stream.Peek().Value != "," && stream.Peek().Value != ")") arg.Add(stream.Next());
                            args.Add(arg);

                        } while (stream.HasNext && stream.Next().Value == ",");
                    }
                    else
                    {
                        args = new();
                    }

                    if (args.Count != macro.Arguments.Count)
                        throw new CarpError.PreprocessorError($"Expected {macro.Arguments.Count} arguments, got {args.Count}");
                    
                    // List<PrimitiveToken> body = macro.Body;
                    // for (int i = 0; i < args.Count; i++)
                    // {
                    //     for (int j = 0; j < body.Count; j++)
                    //     {
                    //         if (body[j].Type == PrimitiveTokenType.Identifier
                    //             && body[j].Value == macro.Arguments[i])
                    //         {
                    //             body[j] = args[i];
                    //         }
                    //     }
                    // }
                    
                    // copy to new list
                    List<PrimitiveToken> body = new();
                    foreach (PrimitiveToken t in macro.Body)
                    {
                        if (t.Type == PrimitiveTokenType.Identifier
                            && macro.Arguments.Contains(t.Value))
                        {
                            body.AddRange(args[macro.Arguments.IndexOf(t.Value)]);
                        }
                        else
                            body.Add(t);
                    }

                    foreach (PrimitiveToken t in body) sb.Append(t.Value);
                    
                    // TODO: Debug only
                    // Console.WriteLine($"Macro {macro.Name}({string.Join(", ", macro.Arguments)}) => {string.Join("", body.Select(x=>x.Value))}");
                }
                else
                    sb.Append(token.Value);
            }
            else
                sb.Append(token.Value);
        }

        return sb.ToString();
    }
    
    private static string Include(string path)
    {
        string source = File.ReadAllText(path);
        Preprocessor pp = new(source);
        return pp.Process();
    }
}
