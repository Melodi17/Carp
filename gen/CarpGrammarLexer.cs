//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/melod/source/csharp/Carp/CarpGrammar.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class CarpGrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		ELIPSIS=1, PERIOD=2, COMMA=3, LPAREN=4, RPAREN=5, LBRACE=6, RBRACE=7, 
		LBRACKET=8, RBRACKET=9, EQUALS=10, EQUALS_EQUALS=11, NOT_EQUALS=12, GREATER_THAN=13, 
		LESS_THAN=14, LESS_THAN_EQUALS=15, GREATER_THAN_EQUALS=16, PIPE=17, AMPERSAND=18, 
		TILDE=19, AT=20, BANG=21, PLUS_EQUALS=22, MINUS_EQUALS=23, ASTERISK_EQUALS=24, 
		SLASH_EQUALS=25, CARET_EQUALS=26, PERCENT_EQUALS=27, PLUS_PLUS=28, MINUS_MINUS=29, 
		PLUS=30, MINUS=31, SLASH=32, PERCENT=33, ASTERISK_BSPACE=34, ASTERISK_LSPACE=35, 
		ASTERISK_RSPACE=36, ASTERISK_NSPC=37, BACKSLASH=38, CARET=39, QUESTION_MARK=40, 
		UNDERSCORE=41, COLON=42, SEMICOLON=43, COLON_COLON=44, SEMICOLON_SEMICOLON=45, 
		ARROW=46, HASH=47, TRUE=48, FALSE=49, NULL=50, TRY=51, CATCH=52, FINALLY=53, 
		IF=54, ELSE=55, ELSE_IF=56, WHILE=57, ITER=58, RETURN=59, BREAK=60, CONTINUE=61, 
		YIELD=62, CLASS=63, STRUCT=64, LET=65, IMPORT=66, ID=67, INT=68, WS=69, 
		COMMENT=70, STRING=71;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"ELIPSIS", "PERIOD", "COMMA", "LPAREN", "RPAREN", "LBRACE", "RBRACE", 
		"LBRACKET", "RBRACKET", "EQUALS", "EQUALS_EQUALS", "NOT_EQUALS", "GREATER_THAN", 
		"LESS_THAN", "LESS_THAN_EQUALS", "GREATER_THAN_EQUALS", "PIPE", "AMPERSAND", 
		"TILDE", "AT", "BANG", "PLUS_EQUALS", "MINUS_EQUALS", "ASTERISK_EQUALS", 
		"SLASH_EQUALS", "CARET_EQUALS", "PERCENT_EQUALS", "PLUS_PLUS", "MINUS_MINUS", 
		"PLUS", "MINUS", "SLASH", "PERCENT", "ASTERISK_BSPACE", "ASTERISK_LSPACE", 
		"ASTERISK_RSPACE", "ASTERISK_NSPC", "BACKSLASH", "CARET", "QUESTION_MARK", 
		"UNDERSCORE", "COLON", "SEMICOLON", "COLON_COLON", "SEMICOLON_SEMICOLON", 
		"ARROW", "HASH", "TRUE", "FALSE", "NULL", "TRY", "CATCH", "FINALLY", "IF", 
		"ELSE", "ELSE_IF", "WHILE", "ITER", "RETURN", "BREAK", "CONTINUE", "YIELD", 
		"CLASS", "STRUCT", "LET", "IMPORT", "ID", "INT", "WS", "COMMENT", "STRING", 
		"SHORT_STRING_ITEM_FOR_SINGLE_QUOTE", "SHORT_STRING_CHAR_NO_SINGLE_QUOTE"
	};


	public CarpGrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public CarpGrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'..'", "'.'", "','", "'('", "')'", "'{'", "'}'", "'['", "']'", 
		"'='", "'=='", null, "'>'", "'<'", "'<='", "'>='", "'|'", "'&'", "'~'", 
		"'@'", "'!'", "'+='", "'-='", "'*='", "'/='", "'^='", "'%='", "'++'", 
		"'--'", "'+'", "'-'", "'/'", "'%'", "' * '", "' *'", "'* '", "'*'", "'\\'", 
		"'^'", "'?'", "'_'", "':'", "';'", "'::'", "';;'", "'->'", "'#'", "'true'", 
		"'false'", "'null'", "'try'", "'catch'", "'finally'", "'if'", "'else'", 
		"'else if'", "'while'", "'for'", "'return'", "'break'", "'continue'", 
		"'yield'", "'class'", "'struct'", "'let'", "'import'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "ELIPSIS", "PERIOD", "COMMA", "LPAREN", "RPAREN", "LBRACE", "RBRACE", 
		"LBRACKET", "RBRACKET", "EQUALS", "EQUALS_EQUALS", "NOT_EQUALS", "GREATER_THAN", 
		"LESS_THAN", "LESS_THAN_EQUALS", "GREATER_THAN_EQUALS", "PIPE", "AMPERSAND", 
		"TILDE", "AT", "BANG", "PLUS_EQUALS", "MINUS_EQUALS", "ASTERISK_EQUALS", 
		"SLASH_EQUALS", "CARET_EQUALS", "PERCENT_EQUALS", "PLUS_PLUS", "MINUS_MINUS", 
		"PLUS", "MINUS", "SLASH", "PERCENT", "ASTERISK_BSPACE", "ASTERISK_LSPACE", 
		"ASTERISK_RSPACE", "ASTERISK_NSPC", "BACKSLASH", "CARET", "QUESTION_MARK", 
		"UNDERSCORE", "COLON", "SEMICOLON", "COLON_COLON", "SEMICOLON_SEMICOLON", 
		"ARROW", "HASH", "TRUE", "FALSE", "NULL", "TRY", "CATCH", "FINALLY", "IF", 
		"ELSE", "ELSE_IF", "WHILE", "ITER", "RETURN", "BREAK", "CONTINUE", "YIELD", 
		"CLASS", "STRUCT", "LET", "IMPORT", "ID", "INT", "WS", "COMMENT", "STRING"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "CarpGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CarpGrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,71,444,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,2,58,7,58,2,59,7,59,2,60,7,60,2,61,7,61,2,62,7,62,2,63,
		7,63,2,64,7,64,2,65,7,65,2,66,7,66,2,67,7,67,2,68,7,68,2,69,7,69,2,70,
		7,70,2,71,7,71,2,72,7,72,1,0,1,0,1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,
		5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,10,1,10,1,10,1,11,1,11,1,11,1,
		11,3,11,176,8,11,1,12,1,12,1,13,1,13,1,14,1,14,1,14,1,15,1,15,1,15,1,16,
		1,16,1,17,1,17,1,18,1,18,1,19,1,19,1,20,1,20,1,21,1,21,1,21,1,22,1,22,
		1,22,1,23,1,23,1,23,1,24,1,24,1,24,1,25,1,25,1,25,1,26,1,26,1,26,1,27,
		1,27,1,27,1,28,1,28,1,28,1,29,1,29,1,30,1,30,1,31,1,31,1,32,1,32,1,33,
		1,33,1,33,1,33,1,34,1,34,1,34,1,35,1,35,1,35,1,36,1,36,1,37,1,37,1,38,
		1,38,1,39,1,39,1,40,1,40,1,41,1,41,1,42,1,42,1,43,1,43,1,43,1,44,1,44,
		1,44,1,45,1,45,1,45,1,46,1,46,1,47,1,47,1,47,1,47,1,47,1,48,1,48,1,48,
		1,48,1,48,1,48,1,49,1,49,1,49,1,49,1,49,1,50,1,50,1,50,1,50,1,51,1,51,
		1,51,1,51,1,51,1,51,1,52,1,52,1,52,1,52,1,52,1,52,1,52,1,52,1,53,1,53,
		1,53,1,54,1,54,1,54,1,54,1,54,1,55,1,55,1,55,1,55,1,55,1,55,1,55,1,55,
		1,56,1,56,1,56,1,56,1,56,1,56,1,57,1,57,1,57,1,57,1,58,1,58,1,58,1,58,
		1,58,1,58,1,58,1,59,1,59,1,59,1,59,1,59,1,59,1,60,1,60,1,60,1,60,1,60,
		1,60,1,60,1,60,1,60,1,61,1,61,1,61,1,61,1,61,1,61,1,62,1,62,1,62,1,62,
		1,62,1,62,1,63,1,63,1,63,1,63,1,63,1,63,1,63,1,64,1,64,1,64,1,64,1,65,
		1,65,1,65,1,65,1,65,1,65,1,65,1,66,1,66,5,66,379,8,66,10,66,12,66,382,
		9,66,1,67,3,67,385,8,67,1,67,4,67,388,8,67,11,67,12,67,389,1,67,4,67,393,
		8,67,11,67,12,67,394,1,67,1,67,4,67,399,8,67,11,67,12,67,400,1,67,1,67,
		4,67,405,8,67,11,67,12,67,406,3,67,409,8,67,1,68,4,68,412,8,68,11,68,12,
		68,413,1,68,1,68,1,69,1,69,5,69,420,8,69,10,69,12,69,423,9,69,1,69,1,69,
		1,69,1,69,1,70,1,70,5,70,431,8,70,10,70,12,70,434,9,70,1,70,1,70,1,71,
		1,71,1,71,3,71,441,8,71,1,72,1,72,1,421,0,73,1,1,3,2,5,3,7,4,9,5,11,6,
		13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,
		19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,
		31,63,32,65,33,67,34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,85,
		43,87,44,89,45,91,46,93,47,95,48,97,49,99,50,101,51,103,52,105,53,107,
		54,109,55,111,56,113,57,115,58,117,59,119,60,121,61,123,62,125,63,127,
		64,129,65,131,66,133,67,135,68,137,69,139,70,141,71,143,0,145,0,1,0,6,
		2,0,65,90,97,122,4,0,48,57,65,90,95,95,97,122,1,0,48,57,3,0,9,10,13,13,
		32,32,1,0,10,10,2,0,39,39,92,92,454,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,
		0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,
		1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,
		0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,
		1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,
		0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,
		1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,
		0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,
		1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,0,0,91,1,0,0,0,0,93,1,0,0,
		0,0,95,1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,0,0,101,1,0,0,0,0,103,1,0,0,0,0,
		105,1,0,0,0,0,107,1,0,0,0,0,109,1,0,0,0,0,111,1,0,0,0,0,113,1,0,0,0,0,
		115,1,0,0,0,0,117,1,0,0,0,0,119,1,0,0,0,0,121,1,0,0,0,0,123,1,0,0,0,0,
		125,1,0,0,0,0,127,1,0,0,0,0,129,1,0,0,0,0,131,1,0,0,0,0,133,1,0,0,0,0,
		135,1,0,0,0,0,137,1,0,0,0,0,139,1,0,0,0,0,141,1,0,0,0,1,147,1,0,0,0,3,
		150,1,0,0,0,5,152,1,0,0,0,7,154,1,0,0,0,9,156,1,0,0,0,11,158,1,0,0,0,13,
		160,1,0,0,0,15,162,1,0,0,0,17,164,1,0,0,0,19,166,1,0,0,0,21,168,1,0,0,
		0,23,175,1,0,0,0,25,177,1,0,0,0,27,179,1,0,0,0,29,181,1,0,0,0,31,184,1,
		0,0,0,33,187,1,0,0,0,35,189,1,0,0,0,37,191,1,0,0,0,39,193,1,0,0,0,41,195,
		1,0,0,0,43,197,1,0,0,0,45,200,1,0,0,0,47,203,1,0,0,0,49,206,1,0,0,0,51,
		209,1,0,0,0,53,212,1,0,0,0,55,215,1,0,0,0,57,218,1,0,0,0,59,221,1,0,0,
		0,61,223,1,0,0,0,63,225,1,0,0,0,65,227,1,0,0,0,67,229,1,0,0,0,69,233,1,
		0,0,0,71,236,1,0,0,0,73,239,1,0,0,0,75,241,1,0,0,0,77,243,1,0,0,0,79,245,
		1,0,0,0,81,247,1,0,0,0,83,249,1,0,0,0,85,251,1,0,0,0,87,253,1,0,0,0,89,
		256,1,0,0,0,91,259,1,0,0,0,93,262,1,0,0,0,95,264,1,0,0,0,97,269,1,0,0,
		0,99,275,1,0,0,0,101,280,1,0,0,0,103,284,1,0,0,0,105,290,1,0,0,0,107,298,
		1,0,0,0,109,301,1,0,0,0,111,306,1,0,0,0,113,314,1,0,0,0,115,320,1,0,0,
		0,117,324,1,0,0,0,119,331,1,0,0,0,121,337,1,0,0,0,123,346,1,0,0,0,125,
		352,1,0,0,0,127,358,1,0,0,0,129,365,1,0,0,0,131,369,1,0,0,0,133,376,1,
		0,0,0,135,384,1,0,0,0,137,411,1,0,0,0,139,417,1,0,0,0,141,428,1,0,0,0,
		143,440,1,0,0,0,145,442,1,0,0,0,147,148,5,46,0,0,148,149,5,46,0,0,149,
		2,1,0,0,0,150,151,5,46,0,0,151,4,1,0,0,0,152,153,5,44,0,0,153,6,1,0,0,
		0,154,155,5,40,0,0,155,8,1,0,0,0,156,157,5,41,0,0,157,10,1,0,0,0,158,159,
		5,123,0,0,159,12,1,0,0,0,160,161,5,125,0,0,161,14,1,0,0,0,162,163,5,91,
		0,0,163,16,1,0,0,0,164,165,5,93,0,0,165,18,1,0,0,0,166,167,5,61,0,0,167,
		20,1,0,0,0,168,169,5,61,0,0,169,170,5,61,0,0,170,22,1,0,0,0,171,172,5,
		33,0,0,172,176,5,61,0,0,173,174,5,60,0,0,174,176,5,62,0,0,175,171,1,0,
		0,0,175,173,1,0,0,0,176,24,1,0,0,0,177,178,5,62,0,0,178,26,1,0,0,0,179,
		180,5,60,0,0,180,28,1,0,0,0,181,182,5,60,0,0,182,183,5,61,0,0,183,30,1,
		0,0,0,184,185,5,62,0,0,185,186,5,61,0,0,186,32,1,0,0,0,187,188,5,124,0,
		0,188,34,1,0,0,0,189,190,5,38,0,0,190,36,1,0,0,0,191,192,5,126,0,0,192,
		38,1,0,0,0,193,194,5,64,0,0,194,40,1,0,0,0,195,196,5,33,0,0,196,42,1,0,
		0,0,197,198,5,43,0,0,198,199,5,61,0,0,199,44,1,0,0,0,200,201,5,45,0,0,
		201,202,5,61,0,0,202,46,1,0,0,0,203,204,5,42,0,0,204,205,5,61,0,0,205,
		48,1,0,0,0,206,207,5,47,0,0,207,208,5,61,0,0,208,50,1,0,0,0,209,210,5,
		94,0,0,210,211,5,61,0,0,211,52,1,0,0,0,212,213,5,37,0,0,213,214,5,61,0,
		0,214,54,1,0,0,0,215,216,5,43,0,0,216,217,5,43,0,0,217,56,1,0,0,0,218,
		219,5,45,0,0,219,220,5,45,0,0,220,58,1,0,0,0,221,222,5,43,0,0,222,60,1,
		0,0,0,223,224,5,45,0,0,224,62,1,0,0,0,225,226,5,47,0,0,226,64,1,0,0,0,
		227,228,5,37,0,0,228,66,1,0,0,0,229,230,5,32,0,0,230,231,5,42,0,0,231,
		232,5,32,0,0,232,68,1,0,0,0,233,234,5,32,0,0,234,235,5,42,0,0,235,70,1,
		0,0,0,236,237,5,42,0,0,237,238,5,32,0,0,238,72,1,0,0,0,239,240,5,42,0,
		0,240,74,1,0,0,0,241,242,5,92,0,0,242,76,1,0,0,0,243,244,5,94,0,0,244,
		78,1,0,0,0,245,246,5,63,0,0,246,80,1,0,0,0,247,248,5,95,0,0,248,82,1,0,
		0,0,249,250,5,58,0,0,250,84,1,0,0,0,251,252,5,59,0,0,252,86,1,0,0,0,253,
		254,5,58,0,0,254,255,5,58,0,0,255,88,1,0,0,0,256,257,5,59,0,0,257,258,
		5,59,0,0,258,90,1,0,0,0,259,260,5,45,0,0,260,261,5,62,0,0,261,92,1,0,0,
		0,262,263,5,35,0,0,263,94,1,0,0,0,264,265,5,116,0,0,265,266,5,114,0,0,
		266,267,5,117,0,0,267,268,5,101,0,0,268,96,1,0,0,0,269,270,5,102,0,0,270,
		271,5,97,0,0,271,272,5,108,0,0,272,273,5,115,0,0,273,274,5,101,0,0,274,
		98,1,0,0,0,275,276,5,110,0,0,276,277,5,117,0,0,277,278,5,108,0,0,278,279,
		5,108,0,0,279,100,1,0,0,0,280,281,5,116,0,0,281,282,5,114,0,0,282,283,
		5,121,0,0,283,102,1,0,0,0,284,285,5,99,0,0,285,286,5,97,0,0,286,287,5,
		116,0,0,287,288,5,99,0,0,288,289,5,104,0,0,289,104,1,0,0,0,290,291,5,102,
		0,0,291,292,5,105,0,0,292,293,5,110,0,0,293,294,5,97,0,0,294,295,5,108,
		0,0,295,296,5,108,0,0,296,297,5,121,0,0,297,106,1,0,0,0,298,299,5,105,
		0,0,299,300,5,102,0,0,300,108,1,0,0,0,301,302,5,101,0,0,302,303,5,108,
		0,0,303,304,5,115,0,0,304,305,5,101,0,0,305,110,1,0,0,0,306,307,5,101,
		0,0,307,308,5,108,0,0,308,309,5,115,0,0,309,310,5,101,0,0,310,311,5,32,
		0,0,311,312,5,105,0,0,312,313,5,102,0,0,313,112,1,0,0,0,314,315,5,119,
		0,0,315,316,5,104,0,0,316,317,5,105,0,0,317,318,5,108,0,0,318,319,5,101,
		0,0,319,114,1,0,0,0,320,321,5,102,0,0,321,322,5,111,0,0,322,323,5,114,
		0,0,323,116,1,0,0,0,324,325,5,114,0,0,325,326,5,101,0,0,326,327,5,116,
		0,0,327,328,5,117,0,0,328,329,5,114,0,0,329,330,5,110,0,0,330,118,1,0,
		0,0,331,332,5,98,0,0,332,333,5,114,0,0,333,334,5,101,0,0,334,335,5,97,
		0,0,335,336,5,107,0,0,336,120,1,0,0,0,337,338,5,99,0,0,338,339,5,111,0,
		0,339,340,5,110,0,0,340,341,5,116,0,0,341,342,5,105,0,0,342,343,5,110,
		0,0,343,344,5,117,0,0,344,345,5,101,0,0,345,122,1,0,0,0,346,347,5,121,
		0,0,347,348,5,105,0,0,348,349,5,101,0,0,349,350,5,108,0,0,350,351,5,100,
		0,0,351,124,1,0,0,0,352,353,5,99,0,0,353,354,5,108,0,0,354,355,5,97,0,
		0,355,356,5,115,0,0,356,357,5,115,0,0,357,126,1,0,0,0,358,359,5,115,0,
		0,359,360,5,116,0,0,360,361,5,114,0,0,361,362,5,117,0,0,362,363,5,99,0,
		0,363,364,5,116,0,0,364,128,1,0,0,0,365,366,5,108,0,0,366,367,5,101,0,
		0,367,368,5,116,0,0,368,130,1,0,0,0,369,370,5,105,0,0,370,371,5,109,0,
		0,371,372,5,112,0,0,372,373,5,111,0,0,373,374,5,114,0,0,374,375,5,116,
		0,0,375,132,1,0,0,0,376,380,7,0,0,0,377,379,7,1,0,0,378,377,1,0,0,0,379,
		382,1,0,0,0,380,378,1,0,0,0,380,381,1,0,0,0,381,134,1,0,0,0,382,380,1,
		0,0,0,383,385,5,45,0,0,384,383,1,0,0,0,384,385,1,0,0,0,385,408,1,0,0,0,
		386,388,7,2,0,0,387,386,1,0,0,0,388,389,1,0,0,0,389,387,1,0,0,0,389,390,
		1,0,0,0,390,409,1,0,0,0,391,393,7,2,0,0,392,391,1,0,0,0,393,394,1,0,0,
		0,394,392,1,0,0,0,394,395,1,0,0,0,395,396,1,0,0,0,396,398,5,46,0,0,397,
		399,7,2,0,0,398,397,1,0,0,0,399,400,1,0,0,0,400,398,1,0,0,0,400,401,1,
		0,0,0,401,409,1,0,0,0,402,404,5,46,0,0,403,405,7,2,0,0,404,403,1,0,0,0,
		405,406,1,0,0,0,406,404,1,0,0,0,406,407,1,0,0,0,407,409,1,0,0,0,408,387,
		1,0,0,0,408,392,1,0,0,0,408,402,1,0,0,0,409,136,1,0,0,0,410,412,7,3,0,
		0,411,410,1,0,0,0,412,413,1,0,0,0,413,411,1,0,0,0,413,414,1,0,0,0,414,
		415,1,0,0,0,415,416,6,68,0,0,416,138,1,0,0,0,417,421,5,35,0,0,418,420,
		9,0,0,0,419,418,1,0,0,0,420,423,1,0,0,0,421,422,1,0,0,0,421,419,1,0,0,
		0,422,424,1,0,0,0,423,421,1,0,0,0,424,425,7,4,0,0,425,426,1,0,0,0,426,
		427,6,69,0,0,427,140,1,0,0,0,428,432,5,39,0,0,429,431,3,143,71,0,430,429,
		1,0,0,0,431,434,1,0,0,0,432,430,1,0,0,0,432,433,1,0,0,0,433,435,1,0,0,
		0,434,432,1,0,0,0,435,436,5,39,0,0,436,142,1,0,0,0,437,441,3,145,72,0,
		438,439,5,92,0,0,439,441,9,0,0,0,440,437,1,0,0,0,440,438,1,0,0,0,441,144,
		1,0,0,0,442,443,8,5,0,0,443,146,1,0,0,0,13,0,175,380,384,389,394,400,406,
		408,413,421,432,440,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
