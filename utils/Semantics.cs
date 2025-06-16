namespace Carp.utils;

using Antlr4.Runtime;
using Antlr4.Runtime.Atn;

public static class Semantics
{
    public static int CalculateDepth(CommonTokenStream tokens)
    {
        (int Opening, int Closing)[] delimiters =
        [
            (CarpGrammarLexer.LBRACE, CarpGrammarLexer.RBRACE),
            (CarpGrammarLexer.LPAREN, CarpGrammarLexer.RPAREN),
            (CarpGrammarLexer.LBRACKET, CarpGrammarLexer.RBRACKET)
        ];

        int[] depths = new int[delimiters.Length];
        foreach (IToken? token in tokens.GetTokens())
        {
            for (int i = 0; i < delimiters.Length; i++)
            {
                if (token.Type == delimiters[i].Opening)
                    depths[i]++;
                else if (token.Type == delimiters[i].Closing)
                    depths[i]--;
            }
        }

        return depths.Sum();
    }

    public static bool ShouldMultiline(CommonTokenStream tokenStream)
    {
        if (tokenStream.Size < 2)
            return false;

        // If the depth is greater than 0, we should multiline
        int depth = Semantics.CalculateDepth(tokenStream);
        if (depth > 0)
            return true;

        // if (Semantics.CheckUnfinishedMethodDelcaration(tokenStream))
        //     return true;

        // Docstrings precede methods, fields and other declarations.
        if (tokenStream.Get(tokenStream.Size - 2).Type == CarpGrammarParser.DOCSTRING)
            return true;

        int[] multiliners =
        [
            CarpGrammarParser.PERIOD,
            CarpGrammarParser.COMMA,
            CarpGrammarParser.EQUALS,
            CarpGrammarParser.EQUALS_EQUALS,
            CarpGrammarParser.NOT_EQUALS,
            CarpGrammarParser.GREATER_THAN,
            CarpGrammarParser.LESS_THAN,
            CarpGrammarParser.LESS_THAN_EQUALS,
            CarpGrammarParser.GREATER_THAN_EQUALS,
            CarpGrammarParser.PIPE,
            CarpGrammarParser.AMPERSAND,
            CarpGrammarParser.TILDE,
            CarpGrammarParser.TILDE_TILDE,
            CarpGrammarParser.AT,
            CarpGrammarParser.BANG,
            CarpGrammarParser.PLUS_EQUALS,
            CarpGrammarParser.MINUS_EQUALS,
            CarpGrammarParser.ASTERISK_EQUALS,
            CarpGrammarParser.SLASH_EQUALS,
            CarpGrammarParser.CARET_EQUALS,
            CarpGrammarParser.PERCENT_EQUALS,
            CarpGrammarParser.LEFT_SHIFT,
            CarpGrammarParser.RIGHT_SHIFT,
            CarpGrammarParser.PLUS,
            CarpGrammarParser.MINUS,
            CarpGrammarParser.SLASH,
            CarpGrammarParser.PERCENT,
            CarpGrammarParser.ASTERISK_BSPACE,
            CarpGrammarParser.ASTERISK_LSPACE,
            CarpGrammarParser.BACKSLASH,
            CarpGrammarParser.CARET,
            CarpGrammarParser.QUESTION_MARK,
            CarpGrammarParser.UNDERSCORE,
            CarpGrammarParser.COLON,
            CarpGrammarParser.SEMICOLON,
            CarpGrammarParser.COLON_COLON,
            CarpGrammarParser.SEMICOLON_SEMICOLON,
            CarpGrammarParser.ARROW
        ];
        if (multiliners.Contains(tokenStream.Get(tokenStream.Size - 2).Type))
            return true;

        return false;
    }
    private static bool CheckUnfinishedMethodDelcaration(CommonTokenStream tokenStream)
    {
        try
        {
            // go to end of stream
            // void mymethod(some data)
            //                         ^--- we're here
            tokenStream.Seek(tokenStream.Size - 2);
            if (tokenStream.LT(1).Type != CarpGrammarParser.RPAREN)
                return false;

            // void mymethod(some data)
            //              ^--- skips to the opening parenthesis
            while (tokenStream.LT(1).Type != CarpGrammarParser.LPAREN)
            {
                if (tokenStream.LT(1).Type == Recognizer<IToken, ParserATNSimulator>.Eof)
                    return false;
                tokenStream.Seek(tokenStream.Index - 1);
            }

            // void mymethod(some data)
            // ^--- we're here
            tokenStream.Seek(tokenStream.Index - 2);

            if (tokenStream.LT(1).Type != CarpGrammarParser.ID)
                return false;

            if (tokenStream.LT(2).Type != CarpGrammarParser.ID)
                return false;

            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            tokenStream.Reset();
        }
    }
}