// Generated from D:/Source/csharp/Carp/CarpGrammar.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class CarpGrammarParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		ELIPSIS=1, PERIOD=2, COMMA=3, LPAREN=4, RPAREN=5, LBRACE=6, RBRACE=7, 
		LBRACKET=8, RBRACKET=9, EQUALS=10, EQUALS_EQUALS=11, NOT_EQUALS=12, GREATER_THAN=13, 
		LESS_THAN=14, LESS_THAN_EQUALS=15, GREATER_THAN_EQUALS=16, PIPE=17, AMPERSAND=18, 
		TILDE=19, TILDE_TILDE=20, AT=21, BANG=22, PLUS_EQUALS=23, MINUS_EQUALS=24, 
		ASTERISK_EQUALS=25, SLASH_EQUALS=26, CARET_EQUALS=27, PERCENT_EQUALS=28, 
		PLUS_PLUS=29, MINUS_MINUS=30, PLUS=31, MINUS=32, SLASH=33, PERCENT=34, 
		ASTERISK_BSPACE=35, ASTERISK_LSPACE=36, ASTERISK_RSPACE=37, ASTERISK_NSPC=38, 
		BACKSLASH=39, CARET=40, QUESTION_MARK=41, UNDERSCORE=42, COLON=43, SEMICOLON=44, 
		COLON_COLON=45, SEMICOLON_SEMICOLON=46, ARROW=47, HASH=48, TRUE=49, FALSE=50, 
		NULL=51, TRY=52, CATCH=53, FINALLY=54, IF=55, ELSE=56, ELSE_IF=57, WHILE=58, 
		ITER=59, RETURN=60, BREAK=61, CONTINUE=62, YIELD=63, CLASS=64, STRUCT=65, 
		LET=66, FIXED=67, ID=68, INT=69, WS=70, COMMENT=71, STRING=72, CHAR=73;
	public static final int
		RULE_program = 0, RULE_block = 1, RULE_generic_block = 2, RULE_statement = 3, 
		RULE_flow_control = 4, RULE_if_statement = 5, RULE_while_statement = 6, 
		RULE_try_statement = 7, RULE_iter_statement = 8, RULE_return_statement = 9, 
		RULE_break_statement = 10, RULE_continue_statement = 11, RULE_yield_statement = 12, 
		RULE_attribute = 13, RULE_definition_with_attr = 14, RULE_definition = 15, 
		RULE_expression = 16, RULE_expression_list = 17, RULE_compoundAssignment = 18, 
		RULE_constant = 19, RULE_unary = 20, RULE_logical = 21, RULE_comparison = 22, 
		RULE_binary = 23, RULE_array = 24, RULE_map = 25, RULE_modifier = 26, 
		RULE_type = 27, RULE_type_name_list = 28, RULE_name = 29;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "block", "generic_block", "statement", "flow_control", "if_statement", 
			"while_statement", "try_statement", "iter_statement", "return_statement", 
			"break_statement", "continue_statement", "yield_statement", "attribute", 
			"definition_with_attr", "definition", "expression", "expression_list", 
			"compoundAssignment", "constant", "unary", "logical", "comparison", "binary", 
			"array", "map", "modifier", "type", "type_name_list", "name"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'..'", "'.'", "','", "'('", "')'", "'{'", "'}'", "'['", "']'", 
			"'='", "'=='", null, "'>'", "'<'", "'<='", "'>='", "'|'", "'&'", "'~'", 
			"'~~'", "'@'", "'!'", "'+='", "'-='", "'*='", "'/='", "'^='", "'%='", 
			"'++'", "'--'", "'+'", "'-'", "'/'", "'%'", "' * '", "' *'", "'* '", 
			"'*'", "'\\'", "'^'", "'?'", "'_'", "':'", "';'", "'::'", "';;'", "'->'", 
			"'#'", "'true'", "'false'", "'null'", "'try'", "'catch'", "'finally'", 
			"'if'", "'else'", "'else if'", "'while'", "'for'", "'return'", "'break'", 
			"'continue'", "'yield'", "'class'", "'struct'", "'let'", "'fixed'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "ELIPSIS", "PERIOD", "COMMA", "LPAREN", "RPAREN", "LBRACE", "RBRACE", 
			"LBRACKET", "RBRACKET", "EQUALS", "EQUALS_EQUALS", "NOT_EQUALS", "GREATER_THAN", 
			"LESS_THAN", "LESS_THAN_EQUALS", "GREATER_THAN_EQUALS", "PIPE", "AMPERSAND", 
			"TILDE", "TILDE_TILDE", "AT", "BANG", "PLUS_EQUALS", "MINUS_EQUALS", 
			"ASTERISK_EQUALS", "SLASH_EQUALS", "CARET_EQUALS", "PERCENT_EQUALS", 
			"PLUS_PLUS", "MINUS_MINUS", "PLUS", "MINUS", "SLASH", "PERCENT", "ASTERISK_BSPACE", 
			"ASTERISK_LSPACE", "ASTERISK_RSPACE", "ASTERISK_NSPC", "BACKSLASH", "CARET", 
			"QUESTION_MARK", "UNDERSCORE", "COLON", "SEMICOLON", "COLON_COLON", "SEMICOLON_SEMICOLON", 
			"ARROW", "HASH", "TRUE", "FALSE", "NULL", "TRY", "CATCH", "FINALLY", 
			"IF", "ELSE", "ELSE_IF", "WHILE", "ITER", "RETURN", "BREAK", "CONTINUE", 
			"YIELD", "CLASS", "STRUCT", "LET", "FIXED", "ID", "INT", "WS", "COMMENT", 
			"STRING", "CHAR"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "CarpGrammar.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public CarpGrammarParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends Carp.interpreter.ScopedParserRuleContext {
		public StatementContext statement;
		public List<StatementContext> statements = new ArrayList<StatementContext>();
		public TerminalNode EOF() { return getToken(CarpGrammarParser.EOF, 0); }
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitProgram(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitProgram(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(63);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & -243752925873045230L) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & 831L) != 0)) {
				{
				{
				setState(60);
				((ProgramContext)_localctx).statement = statement();
				((ProgramContext)_localctx).statements.add(((ProgramContext)_localctx).statement);
				}
				}
				setState(65);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(66);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BlockContext extends Carp.interpreter.ScopedParserRuleContext {
		public StatementContext statement;
		public List<StatementContext> statements = new ArrayList<StatementContext>();
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitBlock(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitBlock(this);
			else return visitor.visitChildren(this);
		}
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(71);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & -243752925873045230L) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & 831L) != 0)) {
				{
				{
				setState(68);
				((BlockContext)_localctx).statement = statement();
				((BlockContext)_localctx).statements.add(((BlockContext)_localctx).statement);
				}
				}
				setState(73);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Generic_blockContext extends Carp.interpreter.ScopedParserRuleContext {
		public Generic_blockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_generic_block; }
	 
		public Generic_blockContext() { }
		public void copyFrom(Generic_blockContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LambdaBlockContext extends Generic_blockContext {
		public TerminalNode ARROW() { return getToken(CarpGrammarParser.ARROW, 0); }
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public LambdaBlockContext(Generic_blockContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterLambdaBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitLambdaBlock(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitLambdaBlock(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LambdaExpressionBlockContext extends Generic_blockContext {
		public TerminalNode ARROW() { return getToken(CarpGrammarParser.ARROW, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public LambdaExpressionBlockContext(Generic_blockContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterLambdaExpressionBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitLambdaExpressionBlock(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitLambdaExpressionBlock(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class EnclosedBlockContext extends Generic_blockContext {
		public TerminalNode LBRACE() { return getToken(CarpGrammarParser.LBRACE, 0); }
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public TerminalNode RBRACE() { return getToken(CarpGrammarParser.RBRACE, 0); }
		public EnclosedBlockContext(Generic_blockContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterEnclosedBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitEnclosedBlock(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitEnclosedBlock(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Generic_blockContext generic_block() throws RecognitionException {
		Generic_blockContext _localctx = new Generic_blockContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_generic_block);
		try {
			setState(82);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				_localctx = new EnclosedBlockContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(74);
				match(LBRACE);
				setState(75);
				block();
				setState(76);
				match(RBRACE);
				}
				break;
			case 2:
				_localctx = new LambdaExpressionBlockContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(78);
				match(ARROW);
				setState(79);
				expression(0);
				}
				break;
			case 3:
				_localctx = new LambdaBlockContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(80);
				match(ARROW);
				setState(81);
				statement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementContext extends Carp.interpreter.ScopedParserRuleContext {
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	 
		public StatementContext() { }
		public void copyFrom(StatementContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class DefinitionStatementContext extends StatementContext {
		public Definition_with_attrContext definition_with_attr() {
			return getRuleContext(Definition_with_attrContext.class,0);
		}
		public DefinitionStatementContext(StatementContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterDefinitionStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitDefinitionStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitDefinitionStatement(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class FlowControlStatementContext extends StatementContext {
		public Flow_controlContext flow_control() {
			return getRuleContext(Flow_controlContext.class,0);
		}
		public FlowControlStatementContext(StatementContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterFlowControlStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitFlowControlStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitFlowControlStatement(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionStatementContext extends StatementContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ExpressionStatementContext(StatementContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterExpressionStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitExpressionStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitExpressionStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_statement);
		try {
			setState(87);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				_localctx = new DefinitionStatementContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(84);
				definition_with_attr();
				}
				break;
			case 2:
				_localctx = new ExpressionStatementContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(85);
				expression(0);
				}
				break;
			case 3:
				_localctx = new FlowControlStatementContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(86);
				flow_control();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Flow_controlContext extends Carp.interpreter.ScopedParserRuleContext {
		public If_statementContext if_statement() {
			return getRuleContext(If_statementContext.class,0);
		}
		public While_statementContext while_statement() {
			return getRuleContext(While_statementContext.class,0);
		}
		public Iter_statementContext iter_statement() {
			return getRuleContext(Iter_statementContext.class,0);
		}
		public Return_statementContext return_statement() {
			return getRuleContext(Return_statementContext.class,0);
		}
		public Try_statementContext try_statement() {
			return getRuleContext(Try_statementContext.class,0);
		}
		public Break_statementContext break_statement() {
			return getRuleContext(Break_statementContext.class,0);
		}
		public Continue_statementContext continue_statement() {
			return getRuleContext(Continue_statementContext.class,0);
		}
		public Yield_statementContext yield_statement() {
			return getRuleContext(Yield_statementContext.class,0);
		}
		public Flow_controlContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_flow_control; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterFlow_control(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitFlow_control(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitFlow_control(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Flow_controlContext flow_control() throws RecognitionException {
		Flow_controlContext _localctx = new Flow_controlContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_flow_control);
		try {
			setState(97);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
				enterOuterAlt(_localctx, 1);
				{
				setState(89);
				if_statement();
				}
				break;
			case WHILE:
				enterOuterAlt(_localctx, 2);
				{
				setState(90);
				while_statement();
				}
				break;
			case ITER:
				enterOuterAlt(_localctx, 3);
				{
				setState(91);
				iter_statement();
				}
				break;
			case RETURN:
				enterOuterAlt(_localctx, 4);
				{
				setState(92);
				return_statement();
				}
				break;
			case TRY:
				enterOuterAlt(_localctx, 5);
				{
				setState(93);
				try_statement();
				}
				break;
			case BREAK:
				enterOuterAlt(_localctx, 6);
				{
				setState(94);
				break_statement();
				}
				break;
			case CONTINUE:
				enterOuterAlt(_localctx, 7);
				{
				setState(95);
				continue_statement();
				}
				break;
			case YIELD:
				enterOuterAlt(_localctx, 8);
				{
				setState(96);
				yield_statement();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class If_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext cond;
		public Generic_blockContext body;
		public ExpressionContext expression;
		public List<ExpressionContext> elif_expressions = new ArrayList<ExpressionContext>();
		public Generic_blockContext generic_block;
		public List<Generic_blockContext> elif_blocks = new ArrayList<Generic_blockContext>();
		public Generic_blockContext else_block;
		public TerminalNode IF() { return getToken(CarpGrammarParser.IF, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<Generic_blockContext> generic_block() {
			return getRuleContexts(Generic_blockContext.class);
		}
		public Generic_blockContext generic_block(int i) {
			return getRuleContext(Generic_blockContext.class,i);
		}
		public List<TerminalNode> ELSE_IF() { return getTokens(CarpGrammarParser.ELSE_IF); }
		public TerminalNode ELSE_IF(int i) {
			return getToken(CarpGrammarParser.ELSE_IF, i);
		}
		public TerminalNode ELSE() { return getToken(CarpGrammarParser.ELSE, 0); }
		public If_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_if_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterIf_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitIf_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitIf_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final If_statementContext if_statement() throws RecognitionException {
		If_statementContext _localctx = new If_statementContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_if_statement);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			match(IF);
			setState(100);
			((If_statementContext)_localctx).cond = expression(0);
			setState(101);
			((If_statementContext)_localctx).body = generic_block();
			setState(108);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(102);
					match(ELSE_IF);
					setState(103);
					((If_statementContext)_localctx).expression = expression(0);
					((If_statementContext)_localctx).elif_expressions.add(((If_statementContext)_localctx).expression);
					setState(104);
					((If_statementContext)_localctx).generic_block = generic_block();
					((If_statementContext)_localctx).elif_blocks.add(((If_statementContext)_localctx).generic_block);
					}
					} 
				}
				setState(110);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			}
			setState(113);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				{
				setState(111);
				match(ELSE);
				setState(112);
				((If_statementContext)_localctx).else_block = generic_block();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class While_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext cond;
		public Generic_blockContext body;
		public TerminalNode WHILE() { return getToken(CarpGrammarParser.WHILE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Generic_blockContext generic_block() {
			return getRuleContext(Generic_blockContext.class,0);
		}
		public While_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_while_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterWhile_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitWhile_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitWhile_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final While_statementContext while_statement() throws RecognitionException {
		While_statementContext _localctx = new While_statementContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_while_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(115);
			match(WHILE);
			setState(116);
			((While_statementContext)_localctx).cond = expression(0);
			setState(117);
			((While_statementContext)_localctx).body = generic_block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Try_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public Generic_blockContext try_block;
		public TypeContext type;
		public List<TypeContext> catch_types = new ArrayList<TypeContext>();
		public NameContext name;
		public List<NameContext> catch_names = new ArrayList<NameContext>();
		public Generic_blockContext generic_block;
		public List<Generic_blockContext> catch_blocks = new ArrayList<Generic_blockContext>();
		public Generic_blockContext finally_block;
		public TerminalNode TRY() { return getToken(CarpGrammarParser.TRY, 0); }
		public List<Generic_blockContext> generic_block() {
			return getRuleContexts(Generic_blockContext.class);
		}
		public Generic_blockContext generic_block(int i) {
			return getRuleContext(Generic_blockContext.class,i);
		}
		public List<TerminalNode> CATCH() { return getTokens(CarpGrammarParser.CATCH); }
		public TerminalNode CATCH(int i) {
			return getToken(CarpGrammarParser.CATCH, i);
		}
		public List<TerminalNode> LPAREN() { return getTokens(CarpGrammarParser.LPAREN); }
		public TerminalNode LPAREN(int i) {
			return getToken(CarpGrammarParser.LPAREN, i);
		}
		public List<TerminalNode> RPAREN() { return getTokens(CarpGrammarParser.RPAREN); }
		public TerminalNode RPAREN(int i) {
			return getToken(CarpGrammarParser.RPAREN, i);
		}
		public TerminalNode FINALLY() { return getToken(CarpGrammarParser.FINALLY, 0); }
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public Try_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_try_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterTry_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitTry_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitTry_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Try_statementContext try_statement() throws RecognitionException {
		Try_statementContext _localctx = new Try_statementContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_try_statement);
		try {
			int _alt;
			setState(153);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(119);
				match(TRY);
				setState(120);
				((Try_statementContext)_localctx).try_block = generic_block();
				setState(130);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(121);
						match(CATCH);
						setState(122);
						match(LPAREN);
						setState(123);
						((Try_statementContext)_localctx).type = type(0);
						((Try_statementContext)_localctx).catch_types.add(((Try_statementContext)_localctx).type);
						setState(124);
						((Try_statementContext)_localctx).name = name();
						((Try_statementContext)_localctx).catch_names.add(((Try_statementContext)_localctx).name);
						setState(125);
						match(RPAREN);
						setState(126);
						((Try_statementContext)_localctx).generic_block = generic_block();
						((Try_statementContext)_localctx).catch_blocks.add(((Try_statementContext)_localctx).generic_block);
						}
						} 
					}
					setState(132);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
				}
				setState(135);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
				case 1:
					{
					setState(133);
					match(FINALLY);
					setState(134);
					((Try_statementContext)_localctx).finally_block = generic_block();
					}
					break;
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(137);
				match(TRY);
				setState(138);
				((Try_statementContext)_localctx).try_block = generic_block();
				setState(146);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(139);
						match(CATCH);
						setState(140);
						((Try_statementContext)_localctx).type = type(0);
						((Try_statementContext)_localctx).catch_types.add(((Try_statementContext)_localctx).type);
						setState(141);
						((Try_statementContext)_localctx).name = name();
						((Try_statementContext)_localctx).catch_names.add(((Try_statementContext)_localctx).name);
						setState(142);
						((Try_statementContext)_localctx).generic_block = generic_block();
						((Try_statementContext)_localctx).catch_blocks.add(((Try_statementContext)_localctx).generic_block);
						}
						} 
					}
					setState(148);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
				}
				setState(151);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
				case 1:
					{
					setState(149);
					match(FINALLY);
					setState(150);
					((Try_statementContext)_localctx).finally_block = generic_block();
					}
					break;
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Iter_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public Iter_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_iter_statement; }
	 
		public Iter_statementContext() { }
		public void copyFrom(Iter_statementContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class IterStatementContext extends Iter_statementContext {
		public ExpressionContext iter;
		public Generic_blockContext body;
		public TerminalNode ITER() { return getToken(CarpGrammarParser.ITER, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Generic_blockContext generic_block() {
			return getRuleContext(Generic_blockContext.class,0);
		}
		public IterStatementContext(Iter_statementContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterIterStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitIterStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitIterStatement(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class IterAsUnpackedStatementContext extends Iter_statementContext {
		public ExpressionContext iter;
		public Generic_blockContext body;
		public TerminalNode ITER() { return getToken(CarpGrammarParser.ITER, 0); }
		public Type_name_listContext type_name_list() {
			return getRuleContext(Type_name_listContext.class,0);
		}
		public TerminalNode COLON() { return getToken(CarpGrammarParser.COLON, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Generic_blockContext generic_block() {
			return getRuleContext(Generic_blockContext.class,0);
		}
		public TerminalNode LPAREN() { return getToken(CarpGrammarParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(CarpGrammarParser.RPAREN, 0); }
		public IterAsUnpackedStatementContext(Iter_statementContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterIterAsUnpackedStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitIterAsUnpackedStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitIterAsUnpackedStatement(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class IterAsStatementContext extends Iter_statementContext {
		public ExpressionContext iter;
		public Generic_blockContext body;
		public TerminalNode ITER() { return getToken(CarpGrammarParser.ITER, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode COLON() { return getToken(CarpGrammarParser.COLON, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Generic_blockContext generic_block() {
			return getRuleContext(Generic_blockContext.class,0);
		}
		public TerminalNode LPAREN() { return getToken(CarpGrammarParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(CarpGrammarParser.RPAREN, 0); }
		public IterAsStatementContext(Iter_statementContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterIterAsStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitIterAsStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitIterAsStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Iter_statementContext iter_statement() throws RecognitionException {
		Iter_statementContext _localctx = new Iter_statementContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_iter_statement);
		try {
			setState(189);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				_localctx = new IterStatementContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(155);
				match(ITER);
				setState(156);
				((IterStatementContext)_localctx).iter = expression(0);
				setState(157);
				((IterStatementContext)_localctx).body = generic_block();
				}
				break;
			case 2:
				_localctx = new IterAsStatementContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(159);
				match(ITER);
				setState(160);
				type(0);
				setState(161);
				name();
				setState(162);
				match(COLON);
				setState(163);
				((IterAsStatementContext)_localctx).iter = expression(0);
				setState(164);
				((IterAsStatementContext)_localctx).body = generic_block();
				}
				break;
			case 3:
				_localctx = new IterAsStatementContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(166);
				match(ITER);
				setState(167);
				match(LPAREN);
				setState(168);
				type(0);
				setState(169);
				name();
				setState(170);
				match(COLON);
				setState(171);
				((IterAsStatementContext)_localctx).iter = expression(0);
				setState(172);
				match(RPAREN);
				setState(173);
				((IterAsStatementContext)_localctx).body = generic_block();
				}
				break;
			case 4:
				_localctx = new IterAsUnpackedStatementContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(175);
				match(ITER);
				setState(176);
				type_name_list();
				setState(177);
				match(COLON);
				setState(178);
				((IterAsUnpackedStatementContext)_localctx).iter = expression(0);
				setState(179);
				((IterAsUnpackedStatementContext)_localctx).body = generic_block();
				}
				break;
			case 5:
				_localctx = new IterAsUnpackedStatementContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(181);
				match(ITER);
				setState(182);
				match(LPAREN);
				setState(183);
				type_name_list();
				setState(184);
				match(COLON);
				setState(185);
				((IterAsUnpackedStatementContext)_localctx).iter = expression(0);
				setState(186);
				match(RPAREN);
				setState(187);
				((IterAsUnpackedStatementContext)_localctx).body = generic_block();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Return_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext value;
		public TerminalNode RETURN() { return getToken(CarpGrammarParser.RETURN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Return_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_return_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterReturn_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitReturn_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitReturn_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Return_statementContext return_statement() throws RecognitionException {
		Return_statementContext _localctx = new Return_statementContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_return_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(191);
			match(RETURN);
			setState(193);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				{
				setState(192);
				((Return_statementContext)_localctx).value = expression(0);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Break_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public TerminalNode BREAK() { return getToken(CarpGrammarParser.BREAK, 0); }
		public Break_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_break_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterBreak_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitBreak_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitBreak_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Break_statementContext break_statement() throws RecognitionException {
		Break_statementContext _localctx = new Break_statementContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_break_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			match(BREAK);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Continue_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public TerminalNode CONTINUE() { return getToken(CarpGrammarParser.CONTINUE, 0); }
		public Continue_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_continue_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterContinue_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitContinue_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitContinue_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Continue_statementContext continue_statement() throws RecognitionException {
		Continue_statementContext _localctx = new Continue_statementContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_continue_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(197);
			match(CONTINUE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Yield_statementContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext value;
		public TerminalNode YIELD() { return getToken(CarpGrammarParser.YIELD, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Yield_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_yield_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterYield_statement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitYield_statement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitYield_statement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Yield_statementContext yield_statement() throws RecognitionException {
		Yield_statementContext _localctx = new Yield_statementContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_yield_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(199);
			match(YIELD);
			setState(201);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				{
				setState(200);
				((Yield_statementContext)_localctx).value = expression(0);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AttributeContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext obj;
		public TerminalNode AT() { return getToken(CarpGrammarParser.AT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode LBRACKET() { return getToken(CarpGrammarParser.LBRACKET, 0); }
		public TerminalNode RBRACKET() { return getToken(CarpGrammarParser.RBRACKET, 0); }
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterAttribute(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitAttribute(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitAttribute(this);
			else return visitor.visitChildren(this);
		}
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_attribute);
		try {
			setState(209);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case AT:
				enterOuterAlt(_localctx, 1);
				{
				setState(203);
				match(AT);
				setState(204);
				((AttributeContext)_localctx).obj = expression(0);
				}
				break;
			case LBRACKET:
				enterOuterAlt(_localctx, 2);
				{
				setState(205);
				match(LBRACKET);
				setState(206);
				((AttributeContext)_localctx).obj = expression(0);
				setState(207);
				match(RBRACKET);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Definition_with_attrContext extends Carp.interpreter.ScopedParserRuleContext {
		public AttributeContext attribute;
		public List<AttributeContext> attrs = new ArrayList<AttributeContext>();
		public DefinitionContext def;
		public DefinitionContext definition() {
			return getRuleContext(DefinitionContext.class,0);
		}
		public List<AttributeContext> attribute() {
			return getRuleContexts(AttributeContext.class);
		}
		public AttributeContext attribute(int i) {
			return getRuleContext(AttributeContext.class,i);
		}
		public Definition_with_attrContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_definition_with_attr; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterDefinition_with_attr(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitDefinition_with_attr(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitDefinition_with_attr(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Definition_with_attrContext definition_with_attr() throws RecognitionException {
		Definition_with_attrContext _localctx = new Definition_with_attrContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_definition_with_attr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(214);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==LBRACKET || _la==AT) {
				{
				{
				setState(211);
				((Definition_with_attrContext)_localctx).attribute = attribute();
				((Definition_with_attrContext)_localctx).attrs.add(((Definition_with_attrContext)_localctx).attribute);
				}
				}
				setState(216);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(217);
			((Definition_with_attrContext)_localctx).def = definition();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DefinitionContext extends Carp.interpreter.ScopedParserRuleContext {
		public DefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_definition; }
	 
		public DefinitionContext() { }
		public void copyFrom(DefinitionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class EmptyFunctionDefinitionContext extends DefinitionContext {
		public TypeContext rtype;
		public NameContext key;
		public Type_name_listContext values;
		public TerminalNode LPAREN() { return getToken(CarpGrammarParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(CarpGrammarParser.RPAREN, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public Type_name_listContext type_name_list() {
			return getRuleContext(Type_name_listContext.class,0);
		}
		public EmptyFunctionDefinitionContext(DefinitionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterEmptyFunctionDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitEmptyFunctionDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitEmptyFunctionDefinition(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class FunctionDefinitionContext extends DefinitionContext {
		public TypeContext rtype;
		public NameContext key;
		public Type_name_listContext values;
		public Generic_blockContext body;
		public TerminalNode LPAREN() { return getToken(CarpGrammarParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(CarpGrammarParser.RPAREN, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public Type_name_listContext type_name_list() {
			return getRuleContext(Type_name_listContext.class,0);
		}
		public Generic_blockContext generic_block() {
			return getRuleContext(Generic_blockContext.class,0);
		}
		public FunctionDefinitionContext(DefinitionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterFunctionDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitFunctionDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitFunctionDefinition(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class InitializedVariableDefinitionContext extends DefinitionContext {
		public NameContext key;
		public ExpressionContext value;
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public TerminalNode EQUALS() { return getToken(CarpGrammarParser.EQUALS, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public InitializedVariableDefinitionContext(DefinitionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterInitializedVariableDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitInitializedVariableDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitInitializedVariableDefinition(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class VariableDefinitionContext extends DefinitionContext {
		public NameContext key;
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public VariableDefinitionContext(DefinitionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterVariableDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitVariableDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitVariableDefinition(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class EnumDefinitionContext extends DefinitionContext {
		public NameContext key;
		public NameContext name;
		public List<NameContext> values = new ArrayList<NameContext>();
		public TerminalNode FIXED() { return getToken(CarpGrammarParser.FIXED, 0); }
		public TerminalNode LBRACE() { return getToken(CarpGrammarParser.LBRACE, 0); }
		public TerminalNode RBRACE() { return getToken(CarpGrammarParser.RBRACE, 0); }
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public EnumDefinitionContext(DefinitionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterEnumDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitEnumDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitEnumDefinition(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ClassDefinitionContext extends DefinitionContext {
		public NameContext key;
		public TypeContext type;
		public List<TypeContext> interhits = new ArrayList<TypeContext>();
		public List<TypeContext> inherits = new ArrayList<TypeContext>();
		public Definition_with_attrContext definition_with_attr;
		public List<Definition_with_attrContext> definitions = new ArrayList<Definition_with_attrContext>();
		public TerminalNode CLASS() { return getToken(CarpGrammarParser.CLASS, 0); }
		public TerminalNode LBRACE() { return getToken(CarpGrammarParser.LBRACE, 0); }
		public TerminalNode RBRACE() { return getToken(CarpGrammarParser.RBRACE, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode COLON() { return getToken(CarpGrammarParser.COLON, 0); }
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<Definition_with_attrContext> definition_with_attr() {
			return getRuleContexts(Definition_with_attrContext.class);
		}
		public Definition_with_attrContext definition_with_attr(int i) {
			return getRuleContext(Definition_with_attrContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(CarpGrammarParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(CarpGrammarParser.COMMA, i);
		}
		public ClassDefinitionContext(DefinitionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterClassDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitClassDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitClassDefinition(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class StructDefinitionContext extends DefinitionContext {
		public NameContext key;
		public TypeContext type;
		public List<TypeContext> interhits = new ArrayList<TypeContext>();
		public List<TypeContext> inherits = new ArrayList<TypeContext>();
		public Definition_with_attrContext definition_with_attr;
		public List<Definition_with_attrContext> definitions = new ArrayList<Definition_with_attrContext>();
		public TerminalNode STRUCT() { return getToken(CarpGrammarParser.STRUCT, 0); }
		public TerminalNode LBRACE() { return getToken(CarpGrammarParser.LBRACE, 0); }
		public TerminalNode RBRACE() { return getToken(CarpGrammarParser.RBRACE, 0); }
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public TerminalNode COLON() { return getToken(CarpGrammarParser.COLON, 0); }
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<Definition_with_attrContext> definition_with_attr() {
			return getRuleContexts(Definition_with_attrContext.class);
		}
		public Definition_with_attrContext definition_with_attr(int i) {
			return getRuleContext(Definition_with_attrContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(CarpGrammarParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(CarpGrammarParser.COMMA, i);
		}
		public StructDefinitionContext(DefinitionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterStructDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitStructDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitStructDefinition(this);
			else return visitor.visitChildren(this);
		}
	}

	public final DefinitionContext definition() throws RecognitionException {
		DefinitionContext _localctx = new DefinitionContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_definition);
		int _la;
		try {
			setState(295);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				_localctx = new FunctionDefinitionContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(219);
				((FunctionDefinitionContext)_localctx).rtype = type(0);
				setState(220);
				((FunctionDefinitionContext)_localctx).key = name();
				setState(221);
				match(LPAREN);
				setState(222);
				((FunctionDefinitionContext)_localctx).values = type_name_list();
				setState(223);
				match(RPAREN);
				setState(224);
				((FunctionDefinitionContext)_localctx).body = generic_block();
				}
				break;
			case 2:
				_localctx = new EmptyFunctionDefinitionContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(226);
				((EmptyFunctionDefinitionContext)_localctx).rtype = type(0);
				setState(227);
				((EmptyFunctionDefinitionContext)_localctx).key = name();
				setState(228);
				match(LPAREN);
				setState(229);
				((EmptyFunctionDefinitionContext)_localctx).values = type_name_list();
				setState(230);
				match(RPAREN);
				}
				break;
			case 3:
				_localctx = new InitializedVariableDefinitionContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(232);
				type(0);
				setState(233);
				((InitializedVariableDefinitionContext)_localctx).key = name();
				setState(234);
				match(EQUALS);
				setState(235);
				((InitializedVariableDefinitionContext)_localctx).value = expression(0);
				}
				break;
			case 4:
				_localctx = new VariableDefinitionContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(237);
				type(0);
				setState(238);
				((VariableDefinitionContext)_localctx).key = name();
				}
				break;
			case 5:
				_localctx = new ClassDefinitionContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(240);
				match(CLASS);
				setState(241);
				((ClassDefinitionContext)_localctx).key = name();
				setState(251);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COLON) {
					{
					setState(242);
					match(COLON);
					setState(243);
					((ClassDefinitionContext)_localctx).type = type(0);
					((ClassDefinitionContext)_localctx).interhits.add(((ClassDefinitionContext)_localctx).type);
					setState(248);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(244);
						match(COMMA);
						setState(245);
						((ClassDefinitionContext)_localctx).type = type(0);
						((ClassDefinitionContext)_localctx).inherits.add(((ClassDefinitionContext)_localctx).type);
						}
						}
						setState(250);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(253);
				match(LBRACE);
				setState(257);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (((((_la - 8)) & ~0x3f) == 0 && ((1L << (_la - 8)) & 2233785415175774209L) != 0)) {
					{
					{
					setState(254);
					((ClassDefinitionContext)_localctx).definition_with_attr = definition_with_attr();
					((ClassDefinitionContext)_localctx).definitions.add(((ClassDefinitionContext)_localctx).definition_with_attr);
					}
					}
					setState(259);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(260);
				match(RBRACE);
				}
				break;
			case 6:
				_localctx = new StructDefinitionContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(262);
				match(STRUCT);
				setState(263);
				((StructDefinitionContext)_localctx).key = name();
				setState(273);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==COLON) {
					{
					setState(264);
					match(COLON);
					setState(265);
					((StructDefinitionContext)_localctx).type = type(0);
					((StructDefinitionContext)_localctx).interhits.add(((StructDefinitionContext)_localctx).type);
					setState(270);
					_errHandler.sync(this);
					_la = _input.LA(1);
					while (_la==COMMA) {
						{
						{
						setState(266);
						match(COMMA);
						setState(267);
						((StructDefinitionContext)_localctx).type = type(0);
						((StructDefinitionContext)_localctx).inherits.add(((StructDefinitionContext)_localctx).type);
						}
						}
						setState(272);
						_errHandler.sync(this);
						_la = _input.LA(1);
					}
					}
				}

				setState(275);
				match(LBRACE);
				setState(279);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (((((_la - 8)) & ~0x3f) == 0 && ((1L << (_la - 8)) & 2233785415175774209L) != 0)) {
					{
					{
					setState(276);
					((StructDefinitionContext)_localctx).definition_with_attr = definition_with_attr();
					((StructDefinitionContext)_localctx).definitions.add(((StructDefinitionContext)_localctx).definition_with_attr);
					}
					}
					setState(281);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(282);
				match(RBRACE);
				}
				break;
			case 7:
				_localctx = new EnumDefinitionContext(_localctx);
				enterOuterAlt(_localctx, 7);
				{
				setState(284);
				match(FIXED);
				setState(285);
				((EnumDefinitionContext)_localctx).key = name();
				setState(286);
				match(LBRACE);
				setState(290);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==UNDERSCORE || _la==ID) {
					{
					{
					setState(287);
					((EnumDefinitionContext)_localctx).name = name();
					((EnumDefinitionContext)_localctx).values.add(((EnumDefinitionContext)_localctx).name);
					}
					}
					setState(292);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(293);
				match(RBRACE);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MapExpressionContext extends ExpressionContext {
		public MapContext map() {
			return getRuleContext(MapContext.class,0);
		}
		public MapExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterMapExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitMapExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitMapExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LambdaExpressionContext extends ExpressionContext {
		public Type_name_listContext values;
		public Generic_blockContext body;
		public TerminalNode LPAREN() { return getToken(CarpGrammarParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(CarpGrammarParser.RPAREN, 0); }
		public Type_name_listContext type_name_list() {
			return getRuleContext(Type_name_listContext.class,0);
		}
		public Generic_blockContext generic_block() {
			return getRuleContext(Generic_blockContext.class,0);
		}
		public LambdaExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterLambdaExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitLambdaExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitLambdaExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ConstantExpressionContext extends ExpressionContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public ConstantExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterConstantExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitConstantExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitConstantExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ArrayExpressionContext extends ExpressionContext {
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public ArrayExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterArrayExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitArrayExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitArrayExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AssignmentExpressionContext extends ExpressionContext {
		public ExpressionContext left;
		public ExpressionContext right;
		public TerminalNode EQUALS() { return getToken(CarpGrammarParser.EQUALS, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public AssignmentExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterAssignmentExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitAssignmentExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitAssignmentExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ComparisonExpressionContext extends ExpressionContext {
		public ExpressionContext left;
		public ComparisonContext op;
		public ExpressionContext right;
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ComparisonContext comparison() {
			return getRuleContext(ComparisonContext.class,0);
		}
		public ComparisonExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterComparisonExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitComparisonExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitComparisonExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LogicalExpressionContext extends ExpressionContext {
		public ExpressionContext left;
		public LogicalContext op;
		public ExpressionContext right;
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public LogicalContext logical() {
			return getRuleContext(LogicalContext.class,0);
		}
		public LogicalExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterLogicalExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitLogicalExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitLogicalExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class VariableExpressionContext extends ExpressionContext {
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public VariableExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterVariableExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitVariableExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitVariableExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class WindExpressionContext extends ExpressionContext {
		public ExpressionContext inner;
		public TerminalNode COLON_COLON() { return getToken(CarpGrammarParser.COLON_COLON, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public WindExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterWindExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitWindExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitWindExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class BinaryExpressionContext extends ExpressionContext {
		public ExpressionContext left;
		public BinaryContext op;
		public ExpressionContext right;
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public BinaryContext binary() {
			return getRuleContext(BinaryContext.class,0);
		}
		public BinaryExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterBinaryExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitBinaryExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitBinaryExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CastExpressionContext extends ExpressionContext {
		public ExpressionContext obj;
		public TypeContext dest;
		public TerminalNode TILDE() { return getToken(CarpGrammarParser.TILDE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public CastExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterCastExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitCastExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitCastExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ParenthesizedExpressionContext extends ExpressionContext {
		public ExpressionContext obj;
		public TerminalNode LPAREN() { return getToken(CarpGrammarParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(CarpGrammarParser.RPAREN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ParenthesizedExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterParenthesizedExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitParenthesizedExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitParenthesizedExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CallExpressionContext extends ExpressionContext {
		public ExpressionContext obj;
		public Expression_listContext parameters;
		public TerminalNode LPAREN() { return getToken(CarpGrammarParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(CarpGrammarParser.RPAREN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Expression_listContext expression_list() {
			return getRuleContext(Expression_listContext.class,0);
		}
		public CallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterCallExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitCallExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitCallExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class InfixExpressionContext extends ExpressionContext {
		public Token token;
		public ExpressionContext expr;
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PLUS_PLUS() { return getToken(CarpGrammarParser.PLUS_PLUS, 0); }
		public TerminalNode MINUS_MINUS() { return getToken(CarpGrammarParser.MINUS_MINUS, 0); }
		public InfixExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterInfixExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitInfixExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitInfixExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CompoundAssignmentExpressionContext extends ExpressionContext {
		public ExpressionContext left;
		public CompoundAssignmentContext op;
		public ExpressionContext right;
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public CompoundAssignmentContext compoundAssignment() {
			return getRuleContext(CompoundAssignmentContext.class,0);
		}
		public CompoundAssignmentExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterCompoundAssignmentExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitCompoundAssignmentExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitCompoundAssignmentExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class FilterExpressionContext extends ExpressionContext {
		public ExpressionContext inner;
		public TerminalNode SEMICOLON_SEMICOLON() { return getToken(CarpGrammarParser.SEMICOLON_SEMICOLON, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public FilterExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterFilterExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitFilterExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitFilterExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class RangeExpressionContext extends ExpressionContext {
		public ExpressionContext left;
		public ExpressionContext right;
		public TerminalNode ELIPSIS() { return getToken(CarpGrammarParser.ELIPSIS, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public RangeExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterRangeExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitRangeExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitRangeExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class IndexExpressionContext extends ExpressionContext {
		public ExpressionContext obj;
		public Expression_listContext parameters;
		public TerminalNode LBRACKET() { return getToken(CarpGrammarParser.LBRACKET, 0); }
		public TerminalNode RBRACKET() { return getToken(CarpGrammarParser.RBRACKET, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public Expression_listContext expression_list() {
			return getRuleContext(Expression_listContext.class,0);
		}
		public IndexExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterIndexExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitIndexExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitIndexExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class UnaryExpressionContext extends ExpressionContext {
		public UnaryContext op;
		public ExpressionContext left;
		public UnaryContext unary() {
			return getRuleContext(UnaryContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public UnaryExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterUnaryExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitUnaryExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitUnaryExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TernaryExpressionContext extends ExpressionContext {
		public ExpressionContext condition;
		public ExpressionContext left;
		public ExpressionContext right;
		public TerminalNode QUESTION_MARK() { return getToken(CarpGrammarParser.QUESTION_MARK, 0); }
		public TerminalNode COLON() { return getToken(CarpGrammarParser.COLON, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TernaryExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterTernaryExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitTernaryExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitTernaryExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class PostfixExpressionContext extends ExpressionContext {
		public ExpressionContext expr;
		public Token token;
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode PLUS_PLUS() { return getToken(CarpGrammarParser.PLUS_PLUS, 0); }
		public TerminalNode MINUS_MINUS() { return getToken(CarpGrammarParser.MINUS_MINUS, 0); }
		public PostfixExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterPostfixExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitPostfixExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitPostfixExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class PropertyExpressionContext extends ExpressionContext {
		public ExpressionContext obj;
		public NameContext value;
		public TerminalNode PERIOD() { return getToken(CarpGrammarParser.PERIOD, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NameContext name() {
			return getRuleContext(NameContext.class,0);
		}
		public PropertyExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterPropertyExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitPropertyExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitPropertyExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class EndRangeExpressionContext extends ExpressionContext {
		public ExpressionContext right;
		public TerminalNode ELIPSIS() { return getToken(CarpGrammarParser.ELIPSIS, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public EndRangeExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterEndRangeExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitEndRangeExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitEndRangeExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CompareTypeExpressionContext extends ExpressionContext {
		public ExpressionContext obj;
		public TypeContext dest;
		public TerminalNode TILDE_TILDE() { return getToken(CarpGrammarParser.TILDE_TILDE, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public CompareTypeExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterCompareTypeExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitCompareTypeExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitCompareTypeExpression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 32;
		enterRecursionRule(_localctx, 32, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(318);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(298);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new InfixExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(299);
				((InfixExpressionContext)_localctx).token = _input.LT(1);
				_la = _input.LA(1);
				if ( !(_la==PLUS_PLUS || _la==MINUS_MINUS) ) {
					((InfixExpressionContext)_localctx).token = (Token)_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				setState(300);
				((InfixExpressionContext)_localctx).expr = expression(21);
				}
				break;
			case 3:
				{
				_localctx = new UnaryExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(301);
				((UnaryExpressionContext)_localctx).op = unary();
				setState(302);
				((UnaryExpressionContext)_localctx).left = expression(15);
				}
				break;
			case 4:
				{
				_localctx = new MapExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(304);
				map();
				}
				break;
			case 5:
				{
				_localctx = new ArrayExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(305);
				array();
				}
				break;
			case 6:
				{
				_localctx = new VariableExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(306);
				name();
				}
				break;
			case 7:
				{
				_localctx = new EndRangeExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(307);
				match(ELIPSIS);
				setState(308);
				((EndRangeExpressionContext)_localctx).right = expression(7);
				}
				break;
			case 8:
				{
				_localctx = new ParenthesizedExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(309);
				match(LPAREN);
				setState(310);
				((ParenthesizedExpressionContext)_localctx).obj = expression(0);
				setState(311);
				match(RPAREN);
				}
				break;
			case 9:
				{
				_localctx = new LambdaExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(313);
				match(LPAREN);
				setState(314);
				((LambdaExpressionContext)_localctx).values = type_name_list();
				setState(315);
				match(RPAREN);
				setState(316);
				((LambdaExpressionContext)_localctx).body = generic_block();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(375);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(373);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
					case 1:
						{
						_localctx = new BinaryExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((BinaryExpressionContext)_localctx).left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(320);
						if (!(precpred(_ctx, 16))) throw new FailedPredicateException(this, "precpred(_ctx, 16)");
						setState(321);
						((BinaryExpressionContext)_localctx).op = binary();
						setState(322);
						((BinaryExpressionContext)_localctx).right = expression(17);
						}
						break;
					case 2:
						{
						_localctx = new ComparisonExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((ComparisonExpressionContext)_localctx).left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(324);
						if (!(precpred(_ctx, 14))) throw new FailedPredicateException(this, "precpred(_ctx, 14)");
						setState(325);
						((ComparisonExpressionContext)_localctx).op = comparison();
						setState(326);
						((ComparisonExpressionContext)_localctx).right = expression(15);
						}
						break;
					case 3:
						{
						_localctx = new LogicalExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((LogicalExpressionContext)_localctx).left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(328);
						if (!(precpred(_ctx, 13))) throw new FailedPredicateException(this, "precpred(_ctx, 13)");
						setState(329);
						((LogicalExpressionContext)_localctx).op = logical();
						setState(330);
						((LogicalExpressionContext)_localctx).right = expression(14);
						}
						break;
					case 4:
						{
						_localctx = new TernaryExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((TernaryExpressionContext)_localctx).condition = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(332);
						if (!(precpred(_ctx, 12))) throw new FailedPredicateException(this, "precpred(_ctx, 12)");
						setState(333);
						match(QUESTION_MARK);
						setState(334);
						((TernaryExpressionContext)_localctx).left = expression(0);
						setState(335);
						match(COLON);
						setState(336);
						((TernaryExpressionContext)_localctx).right = expression(13);
						}
						break;
					case 5:
						{
						_localctx = new RangeExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((RangeExpressionContext)_localctx).left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(338);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(339);
						match(ELIPSIS);
						setState(340);
						((RangeExpressionContext)_localctx).right = expression(9);
						}
						break;
					case 6:
						{
						_localctx = new AssignmentExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((AssignmentExpressionContext)_localctx).left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(341);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(342);
						match(EQUALS);
						setState(343);
						((AssignmentExpressionContext)_localctx).right = expression(4);
						}
						break;
					case 7:
						{
						_localctx = new CompoundAssignmentExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((CompoundAssignmentExpressionContext)_localctx).left = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(344);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(345);
						((CompoundAssignmentExpressionContext)_localctx).op = compoundAssignment();
						setState(346);
						((CompoundAssignmentExpressionContext)_localctx).right = expression(3);
						}
						break;
					case 8:
						{
						_localctx = new CastExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((CastExpressionContext)_localctx).obj = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(348);
						if (!(precpred(_ctx, 23))) throw new FailedPredicateException(this, "precpred(_ctx, 23)");
						setState(349);
						match(TILDE);
						setState(350);
						((CastExpressionContext)_localctx).dest = type(0);
						}
						break;
					case 9:
						{
						_localctx = new CompareTypeExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((CompareTypeExpressionContext)_localctx).obj = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(351);
						if (!(precpred(_ctx, 22))) throw new FailedPredicateException(this, "precpred(_ctx, 22)");
						setState(352);
						match(TILDE_TILDE);
						setState(353);
						((CompareTypeExpressionContext)_localctx).dest = type(0);
						}
						break;
					case 10:
						{
						_localctx = new PostfixExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((PostfixExpressionContext)_localctx).expr = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(354);
						if (!(precpred(_ctx, 20))) throw new FailedPredicateException(this, "precpred(_ctx, 20)");
						setState(355);
						((PostfixExpressionContext)_localctx).token = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==PLUS_PLUS || _la==MINUS_MINUS) ) {
							((PostfixExpressionContext)_localctx).token = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						}
						break;
					case 11:
						{
						_localctx = new CallExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((CallExpressionContext)_localctx).obj = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(356);
						if (!(precpred(_ctx, 19))) throw new FailedPredicateException(this, "precpred(_ctx, 19)");
						setState(357);
						match(LPAREN);
						setState(358);
						((CallExpressionContext)_localctx).parameters = expression_list();
						setState(359);
						match(RPAREN);
						}
						break;
					case 12:
						{
						_localctx = new IndexExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((IndexExpressionContext)_localctx).obj = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(361);
						if (!(precpred(_ctx, 18))) throw new FailedPredicateException(this, "precpred(_ctx, 18)");
						setState(362);
						match(LBRACKET);
						setState(363);
						((IndexExpressionContext)_localctx).parameters = expression_list();
						setState(364);
						match(RBRACKET);
						}
						break;
					case 13:
						{
						_localctx = new PropertyExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((PropertyExpressionContext)_localctx).obj = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(366);
						if (!(precpred(_ctx, 17))) throw new FailedPredicateException(this, "precpred(_ctx, 17)");
						setState(367);
						match(PERIOD);
						setState(368);
						((PropertyExpressionContext)_localctx).value = name();
						}
						break;
					case 14:
						{
						_localctx = new WindExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((WindExpressionContext)_localctx).inner = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(369);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(370);
						match(COLON_COLON);
						}
						break;
					case 15:
						{
						_localctx = new FilterExpressionContext(new ExpressionContext(_parentctx, _parentState));
						((FilterExpressionContext)_localctx).inner = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(371);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(372);
						match(SEMICOLON_SEMICOLON);
						}
						break;
					}
					} 
				}
				setState(377);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,27,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Expression_listContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext expression;
		public List<ExpressionContext> expressions = new ArrayList<ExpressionContext>();
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(CarpGrammarParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(CarpGrammarParser.COMMA, i);
		}
		public Expression_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression_list; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterExpression_list(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitExpression_list(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitExpression_list(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Expression_listContext expression_list() throws RecognitionException {
		Expression_listContext _localctx = new Expression_listContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_expression_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(386);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 3945053630234898L) != 0) || ((((_la - 68)) & ~0x3f) == 0 && ((1L << (_la - 68)) & 51L) != 0)) {
				{
				setState(378);
				((Expression_listContext)_localctx).expression = expression(0);
				((Expression_listContext)_localctx).expressions.add(((Expression_listContext)_localctx).expression);
				setState(383);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(379);
					match(COMMA);
					setState(380);
					((Expression_listContext)_localctx).expression = expression(0);
					((Expression_listContext)_localctx).expressions.add(((Expression_listContext)_localctx).expression);
					}
					}
					setState(385);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CompoundAssignmentContext extends Carp.interpreter.ScopedParserRuleContext {
		public CompoundAssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compoundAssignment; }
	 
		public CompoundAssignmentContext() { }
		public void copyFrom(CompoundAssignmentContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ModulusCompoundContext extends CompoundAssignmentContext {
		public TerminalNode PERCENT_EQUALS() { return getToken(CarpGrammarParser.PERCENT_EQUALS, 0); }
		public ModulusCompoundContext(CompoundAssignmentContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterModulusCompound(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitModulusCompound(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitModulusCompound(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class DivideCompoundContext extends CompoundAssignmentContext {
		public TerminalNode SLASH_EQUALS() { return getToken(CarpGrammarParser.SLASH_EQUALS, 0); }
		public DivideCompoundContext(CompoundAssignmentContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterDivideCompound(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitDivideCompound(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitDivideCompound(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AddCompoundContext extends CompoundAssignmentContext {
		public TerminalNode PLUS_EQUALS() { return getToken(CarpGrammarParser.PLUS_EQUALS, 0); }
		public AddCompoundContext(CompoundAssignmentContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterAddCompound(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitAddCompound(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitAddCompound(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MultiplyCompoundContext extends CompoundAssignmentContext {
		public TerminalNode ASTERISK_EQUALS() { return getToken(CarpGrammarParser.ASTERISK_EQUALS, 0); }
		public TerminalNode ASTERISK_LSPACE() { return getToken(CarpGrammarParser.ASTERISK_LSPACE, 0); }
		public TerminalNode EQUALS() { return getToken(CarpGrammarParser.EQUALS, 0); }
		public MultiplyCompoundContext(CompoundAssignmentContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterMultiplyCompound(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitMultiplyCompound(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitMultiplyCompound(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class PowerCompoundContext extends CompoundAssignmentContext {
		public TerminalNode CARET_EQUALS() { return getToken(CarpGrammarParser.CARET_EQUALS, 0); }
		public PowerCompoundContext(CompoundAssignmentContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterPowerCompound(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitPowerCompound(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitPowerCompound(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class SubtractCompoundContext extends CompoundAssignmentContext {
		public TerminalNode MINUS_EQUALS() { return getToken(CarpGrammarParser.MINUS_EQUALS, 0); }
		public SubtractCompoundContext(CompoundAssignmentContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterSubtractCompound(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitSubtractCompound(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitSubtractCompound(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CompoundAssignmentContext compoundAssignment() throws RecognitionException {
		CompoundAssignmentContext _localctx = new CompoundAssignmentContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_compoundAssignment);
		try {
			setState(396);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PLUS_EQUALS:
				_localctx = new AddCompoundContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(388);
				match(PLUS_EQUALS);
				}
				break;
			case MINUS_EQUALS:
				_localctx = new SubtractCompoundContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(389);
				match(MINUS_EQUALS);
				}
				break;
			case ASTERISK_EQUALS:
				_localctx = new MultiplyCompoundContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(390);
				match(ASTERISK_EQUALS);
				}
				break;
			case SLASH_EQUALS:
				_localctx = new DivideCompoundContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(391);
				match(SLASH_EQUALS);
				}
				break;
			case ASTERISK_LSPACE:
				_localctx = new MultiplyCompoundContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(392);
				match(ASTERISK_LSPACE);
				setState(393);
				match(EQUALS);
				}
				break;
			case CARET_EQUALS:
				_localctx = new PowerCompoundContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(394);
				match(CARET_EQUALS);
				}
				break;
			case PERCENT_EQUALS:
				_localctx = new ModulusCompoundContext(_localctx);
				enterOuterAlt(_localctx, 7);
				{
				setState(395);
				match(PERCENT_EQUALS);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ConstantContext extends Carp.interpreter.ScopedParserRuleContext {
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	 
		public ConstantContext() { }
		public void copyFrom(ConstantContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class CharConstantContext extends ConstantContext {
		public TerminalNode CHAR() { return getToken(CarpGrammarParser.CHAR, 0); }
		public CharConstantContext(ConstantContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterCharConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitCharConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitCharConstant(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class IntConstantContext extends ConstantContext {
		public TerminalNode INT() { return getToken(CarpGrammarParser.INT, 0); }
		public IntConstantContext(ConstantContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterIntConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitIntConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitIntConstant(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class StringConstantContext extends ConstantContext {
		public TerminalNode STRING() { return getToken(CarpGrammarParser.STRING, 0); }
		public StringConstantContext(ConstantContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterStringConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitStringConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitStringConstant(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class FalseConstantContext extends ConstantContext {
		public TerminalNode FALSE() { return getToken(CarpGrammarParser.FALSE, 0); }
		public FalseConstantContext(ConstantContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterFalseConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitFalseConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitFalseConstant(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class TrueConstantContext extends ConstantContext {
		public TerminalNode TRUE() { return getToken(CarpGrammarParser.TRUE, 0); }
		public TrueConstantContext(ConstantContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterTrueConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitTrueConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitTrueConstant(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NullConstantContext extends ConstantContext {
		public TerminalNode NULL() { return getToken(CarpGrammarParser.NULL, 0); }
		public NullConstantContext(ConstantContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterNullConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitNullConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitNullConstant(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_constant);
		try {
			setState(404);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INT:
				_localctx = new IntConstantContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(398);
				match(INT);
				}
				break;
			case STRING:
				_localctx = new StringConstantContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(399);
				match(STRING);
				}
				break;
			case CHAR:
				_localctx = new CharConstantContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(400);
				match(CHAR);
				}
				break;
			case TRUE:
				_localctx = new TrueConstantContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(401);
				match(TRUE);
				}
				break;
			case FALSE:
				_localctx = new FalseConstantContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(402);
				match(FALSE);
				}
				break;
			case NULL:
				_localctx = new NullConstantContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(403);
				match(NULL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class UnaryContext extends Carp.interpreter.ScopedParserRuleContext {
		public UnaryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary; }
	 
		public UnaryContext() { }
		public void copyFrom(UnaryContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NotUnaryContext extends UnaryContext {
		public TerminalNode BANG() { return getToken(CarpGrammarParser.BANG, 0); }
		public NotUnaryContext(UnaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterNotUnary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitNotUnary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitNotUnary(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NegateUnaryContext extends UnaryContext {
		public TerminalNode MINUS() { return getToken(CarpGrammarParser.MINUS, 0); }
		public NegateUnaryContext(UnaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterNegateUnary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitNegateUnary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitNegateUnary(this);
			else return visitor.visitChildren(this);
		}
	}

	public final UnaryContext unary() throws RecognitionException {
		UnaryContext _localctx = new UnaryContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_unary);
		try {
			setState(408);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case MINUS:
				_localctx = new NegateUnaryContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(406);
				match(MINUS);
				}
				break;
			case BANG:
				_localctx = new NotUnaryContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(407);
				match(BANG);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LogicalContext extends Carp.interpreter.ScopedParserRuleContext {
		public LogicalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logical; }
	 
		public LogicalContext() { }
		public void copyFrom(LogicalContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AndLogicalContext extends LogicalContext {
		public TerminalNode AMPERSAND() { return getToken(CarpGrammarParser.AMPERSAND, 0); }
		public AndLogicalContext(LogicalContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterAndLogical(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitAndLogical(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitAndLogical(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class OrLogicalContext extends LogicalContext {
		public TerminalNode PIPE() { return getToken(CarpGrammarParser.PIPE, 0); }
		public OrLogicalContext(LogicalContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterOrLogical(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitOrLogical(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitOrLogical(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LogicalContext logical() throws RecognitionException {
		LogicalContext _localctx = new LogicalContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_logical);
		try {
			setState(412);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case AMPERSAND:
				_localctx = new AndLogicalContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(410);
				match(AMPERSAND);
				}
				break;
			case PIPE:
				_localctx = new OrLogicalContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(411);
				match(PIPE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ComparisonContext extends Carp.interpreter.ScopedParserRuleContext {
		public ComparisonContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_comparison; }
	 
		public ComparisonContext() { }
		public void copyFrom(ComparisonContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MatchComparisonContext extends ComparisonContext {
		public TerminalNode EQUALS_EQUALS() { return getToken(CarpGrammarParser.EQUALS_EQUALS, 0); }
		public MatchComparisonContext(ComparisonContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterMatchComparison(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitMatchComparison(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitMatchComparison(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class GreaterThanEqualsComparisonContext extends ComparisonContext {
		public TerminalNode GREATER_THAN_EQUALS() { return getToken(CarpGrammarParser.GREATER_THAN_EQUALS, 0); }
		public GreaterThanEqualsComparisonContext(ComparisonContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterGreaterThanEqualsComparison(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitGreaterThanEqualsComparison(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitGreaterThanEqualsComparison(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class GreaterThanComparisonContext extends ComparisonContext {
		public TerminalNode GREATER_THAN() { return getToken(CarpGrammarParser.GREATER_THAN, 0); }
		public GreaterThanComparisonContext(ComparisonContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterGreaterThanComparison(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitGreaterThanComparison(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitGreaterThanComparison(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LessThanEqualsComparisonContext extends ComparisonContext {
		public TerminalNode LESS_THAN_EQUALS() { return getToken(CarpGrammarParser.LESS_THAN_EQUALS, 0); }
		public LessThanEqualsComparisonContext(ComparisonContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterLessThanEqualsComparison(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitLessThanEqualsComparison(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitLessThanEqualsComparison(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NotMatchComparisonContext extends ComparisonContext {
		public TerminalNode NOT_EQUALS() { return getToken(CarpGrammarParser.NOT_EQUALS, 0); }
		public NotMatchComparisonContext(ComparisonContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterNotMatchComparison(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitNotMatchComparison(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitNotMatchComparison(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class LessThanComparisonContext extends ComparisonContext {
		public TerminalNode LESS_THAN() { return getToken(CarpGrammarParser.LESS_THAN, 0); }
		public LessThanComparisonContext(ComparisonContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterLessThanComparison(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitLessThanComparison(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitLessThanComparison(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ComparisonContext comparison() throws RecognitionException {
		ComparisonContext _localctx = new ComparisonContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_comparison);
		try {
			setState(420);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case EQUALS_EQUALS:
				_localctx = new MatchComparisonContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(414);
				match(EQUALS_EQUALS);
				}
				break;
			case NOT_EQUALS:
				_localctx = new NotMatchComparisonContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(415);
				match(NOT_EQUALS);
				}
				break;
			case GREATER_THAN:
				_localctx = new GreaterThanComparisonContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(416);
				match(GREATER_THAN);
				}
				break;
			case LESS_THAN:
				_localctx = new LessThanComparisonContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(417);
				match(LESS_THAN);
				}
				break;
			case GREATER_THAN_EQUALS:
				_localctx = new GreaterThanEqualsComparisonContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(418);
				match(GREATER_THAN_EQUALS);
				}
				break;
			case LESS_THAN_EQUALS:
				_localctx = new LessThanEqualsComparisonContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(419);
				match(LESS_THAN_EQUALS);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BinaryContext extends Carp.interpreter.ScopedParserRuleContext {
		public BinaryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_binary; }
	 
		public BinaryContext() { }
		public void copyFrom(BinaryContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class DivideBinaryContext extends BinaryContext {
		public TerminalNode SLASH() { return getToken(CarpGrammarParser.SLASH, 0); }
		public DivideBinaryContext(BinaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterDivideBinary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitDivideBinary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitDivideBinary(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class PowerBinaryContext extends BinaryContext {
		public TerminalNode CARET() { return getToken(CarpGrammarParser.CARET, 0); }
		public PowerBinaryContext(BinaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterPowerBinary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitPowerBinary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitPowerBinary(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MultiplicationBinaryContext extends BinaryContext {
		public TerminalNode ASTERISK_LSPACE() { return getToken(CarpGrammarParser.ASTERISK_LSPACE, 0); }
		public TerminalNode ASTERISK_BSPACE() { return getToken(CarpGrammarParser.ASTERISK_BSPACE, 0); }
		public TerminalNode ASTERISK_NSPC() { return getToken(CarpGrammarParser.ASTERISK_NSPC, 0); }
		public MultiplicationBinaryContext(BinaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterMultiplicationBinary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitMultiplicationBinary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitMultiplicationBinary(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ModulusBinaryContext extends BinaryContext {
		public TerminalNode PERCENT() { return getToken(CarpGrammarParser.PERCENT, 0); }
		public ModulusBinaryContext(BinaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterModulusBinary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitModulusBinary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitModulusBinary(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AddBinaryContext extends BinaryContext {
		public TerminalNode PLUS() { return getToken(CarpGrammarParser.PLUS, 0); }
		public AddBinaryContext(BinaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterAddBinary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitAddBinary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitAddBinary(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class SubtractBinaryContext extends BinaryContext {
		public TerminalNode MINUS() { return getToken(CarpGrammarParser.MINUS, 0); }
		public SubtractBinaryContext(BinaryContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterSubtractBinary(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitSubtractBinary(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitSubtractBinary(this);
			else return visitor.visitChildren(this);
		}
	}

	public final BinaryContext binary() throws RecognitionException {
		BinaryContext _localctx = new BinaryContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_binary);
		int _la;
		try {
			setState(428);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PLUS:
				_localctx = new AddBinaryContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(422);
				match(PLUS);
				}
				break;
			case MINUS:
				_localctx = new SubtractBinaryContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(423);
				match(MINUS);
				}
				break;
			case ASTERISK_BSPACE:
			case ASTERISK_LSPACE:
			case ASTERISK_NSPC:
				_localctx = new MultiplicationBinaryContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(424);
				_la = _input.LA(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 377957122048L) != 0)) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				break;
			case SLASH:
				_localctx = new DivideBinaryContext(_localctx);
				enterOuterAlt(_localctx, 4);
				{
				setState(425);
				match(SLASH);
				}
				break;
			case CARET:
				_localctx = new PowerBinaryContext(_localctx);
				enterOuterAlt(_localctx, 5);
				{
				setState(426);
				match(CARET);
				}
				break;
			case PERCENT:
				_localctx = new ModulusBinaryContext(_localctx);
				enterOuterAlt(_localctx, 6);
				{
				setState(427);
				match(PERCENT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ArrayContext extends Carp.interpreter.ScopedParserRuleContext {
		public TerminalNode LBRACKET() { return getToken(CarpGrammarParser.LBRACKET, 0); }
		public Expression_listContext expression_list() {
			return getRuleContext(Expression_listContext.class,0);
		}
		public TerminalNode RBRACKET() { return getToken(CarpGrammarParser.RBRACKET, 0); }
		public ArrayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterArray(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitArray(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitArray(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ArrayContext array() throws RecognitionException {
		ArrayContext _localctx = new ArrayContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_array);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(430);
			match(LBRACKET);
			setState(431);
			expression_list();
			setState(432);
			match(RBRACKET);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MapContext extends Carp.interpreter.ScopedParserRuleContext {
		public ExpressionContext expression;
		public List<ExpressionContext> keys = new ArrayList<ExpressionContext>();
		public List<ExpressionContext> values = new ArrayList<ExpressionContext>();
		public TerminalNode LBRACKET() { return getToken(CarpGrammarParser.LBRACKET, 0); }
		public List<TerminalNode> COLON() { return getTokens(CarpGrammarParser.COLON); }
		public TerminalNode COLON(int i) {
			return getToken(CarpGrammarParser.COLON, i);
		}
		public TerminalNode RBRACKET() { return getToken(CarpGrammarParser.RBRACKET, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(CarpGrammarParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(CarpGrammarParser.COMMA, i);
		}
		public MapContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_map; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterMap(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitMap(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitMap(this);
			else return visitor.visitChildren(this);
		}
	}

	public final MapContext map() throws RecognitionException {
		MapContext _localctx = new MapContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_map);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(434);
			match(LBRACKET);
			setState(435);
			((MapContext)_localctx).expression = expression(0);
			((MapContext)_localctx).keys.add(((MapContext)_localctx).expression);
			setState(436);
			match(COLON);
			setState(437);
			((MapContext)_localctx).expression = expression(0);
			((MapContext)_localctx).values.add(((MapContext)_localctx).expression);
			setState(445);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(438);
				match(COMMA);
				setState(439);
				((MapContext)_localctx).expression = expression(0);
				((MapContext)_localctx).keys.add(((MapContext)_localctx).expression);
				setState(440);
				match(COLON);
				setState(441);
				((MapContext)_localctx).expression = expression(0);
				((MapContext)_localctx).values.add(((MapContext)_localctx).expression);
				}
				}
				setState(447);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(448);
			match(RBRACKET);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ModifierContext extends Carp.interpreter.ScopedParserRuleContext {
		public ModifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_modifier; }
	 
		public ModifierContext() { }
		public void copyFrom(ModifierContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class PrivateModifierContext extends ModifierContext {
		public TerminalNode UNDERSCORE() { return getToken(CarpGrammarParser.UNDERSCORE, 0); }
		public PrivateModifierContext(ModifierContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterPrivateModifier(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitPrivateModifier(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitPrivateModifier(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ModifierContext modifier() throws RecognitionException {
		ModifierContext _localctx = new ModifierContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_modifier);
		try {
			_localctx = new PrivateModifierContext(_localctx);
			enterOuterAlt(_localctx, 1);
			{
			setState(450);
			match(UNDERSCORE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypeContext extends Carp.interpreter.ScopedParserRuleContext {
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	 
		public TypeContext() { }
		public void copyFrom(TypeContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NamedTypeContext extends TypeContext {
		public TerminalNode ID() { return getToken(CarpGrammarParser.ID, 0); }
		public NamedTypeContext(TypeContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterNamedType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitNamedType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitNamedType(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class PropertyTypeContext extends TypeContext {
		public Token main;
		public Token ID;
		public List<Token> parts = new ArrayList<Token>();
		public List<TerminalNode> ID() { return getTokens(CarpGrammarParser.ID); }
		public TerminalNode ID(int i) {
			return getToken(CarpGrammarParser.ID, i);
		}
		public List<TerminalNode> PERIOD() { return getTokens(CarpGrammarParser.PERIOD); }
		public TerminalNode PERIOD(int i) {
			return getToken(CarpGrammarParser.PERIOD, i);
		}
		public PropertyTypeContext(TypeContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterPropertyType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitPropertyType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitPropertyType(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AutoTypeContext extends TypeContext {
		public TerminalNode LET() { return getToken(CarpGrammarParser.LET, 0); }
		public AutoTypeContext(TypeContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterAutoType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitAutoType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitAutoType(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MapTypeContext extends TypeContext {
		public TypeContext key;
		public TypeContext value;
		public TerminalNode COLON() { return getToken(CarpGrammarParser.COLON, 0); }
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public MapTypeContext(TypeContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterMapType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitMapType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitMapType(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class GenericTypeContext extends TypeContext {
		public TypeContext main;
		public TypeContext type;
		public List<TypeContext> subs = new ArrayList<TypeContext>();
		public TerminalNode LESS_THAN() { return getToken(CarpGrammarParser.LESS_THAN, 0); }
		public TerminalNode GREATER_THAN() { return getToken(CarpGrammarParser.GREATER_THAN, 0); }
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(CarpGrammarParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(CarpGrammarParser.COMMA, i);
		}
		public GenericTypeContext(TypeContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterGenericType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitGenericType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitGenericType(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ListTypeContext extends TypeContext {
		public TypeContext element;
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public TerminalNode ASTERISK_RSPACE() { return getToken(CarpGrammarParser.ASTERISK_RSPACE, 0); }
		public TerminalNode ASTERISK_NSPC() { return getToken(CarpGrammarParser.ASTERISK_NSPC, 0); }
		public ListTypeContext(TypeContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterListType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitListType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitListType(this);
			else return visitor.visitChildren(this);
		}
	}

	public final TypeContext type() throws RecognitionException {
		return type(0);
	}

	private TypeContext type(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TypeContext _localctx = new TypeContext(_ctx, _parentState);
		TypeContext _prevctx = _localctx;
		int _startState = 54;
		enterRecursionRule(_localctx, 54, RULE_type, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(462);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,38,_ctx) ) {
			case 1:
				{
				_localctx = new PropertyTypeContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(453);
				((PropertyTypeContext)_localctx).main = match(ID);
				setState(456); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(454);
						match(PERIOD);
						setState(455);
						((PropertyTypeContext)_localctx).ID = match(ID);
						((PropertyTypeContext)_localctx).parts.add(((PropertyTypeContext)_localctx).ID);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(458); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,37,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			case 2:
				{
				_localctx = new NamedTypeContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(460);
				match(ID);
				}
				break;
			case 3:
				{
				_localctx = new AutoTypeContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(461);
				match(LET);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(483);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(481);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
					case 1:
						{
						_localctx = new MapTypeContext(new TypeContext(_parentctx, _parentState));
						((MapTypeContext)_localctx).key = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_type);
						setState(464);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(465);
						match(COLON);
						setState(466);
						((MapTypeContext)_localctx).value = type(7);
						}
						break;
					case 2:
						{
						_localctx = new ListTypeContext(new TypeContext(_parentctx, _parentState));
						((ListTypeContext)_localctx).element = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_type);
						setState(467);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(468);
						_la = _input.LA(1);
						if ( !(_la==ASTERISK_RSPACE || _la==ASTERISK_NSPC) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						}
						break;
					case 3:
						{
						_localctx = new GenericTypeContext(new TypeContext(_parentctx, _parentState));
						((GenericTypeContext)_localctx).main = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_type);
						setState(469);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(470);
						match(LESS_THAN);
						setState(471);
						((GenericTypeContext)_localctx).type = type(0);
						((GenericTypeContext)_localctx).subs.add(((GenericTypeContext)_localctx).type);
						setState(476);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==COMMA) {
							{
							{
							setState(472);
							match(COMMA);
							setState(473);
							((GenericTypeContext)_localctx).type = type(0);
							((GenericTypeContext)_localctx).subs.add(((GenericTypeContext)_localctx).type);
							}
							}
							setState(478);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						setState(479);
						match(GREATER_THAN);
						}
						break;
					}
					} 
				}
				setState(485);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Type_name_listContext extends Carp.interpreter.ScopedParserRuleContext {
		public TypeContext type;
		public List<TypeContext> types = new ArrayList<TypeContext>();
		public NameContext name;
		public List<NameContext> names = new ArrayList<NameContext>();
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<NameContext> name() {
			return getRuleContexts(NameContext.class);
		}
		public NameContext name(int i) {
			return getRuleContext(NameContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(CarpGrammarParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(CarpGrammarParser.COMMA, i);
		}
		public Type_name_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type_name_list; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterType_name_list(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitType_name_list(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitType_name_list(this);
			else return visitor.visitChildren(this);
		}
	}

	public final Type_name_listContext type_name_list() throws RecognitionException {
		Type_name_listContext _localctx = new Type_name_listContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_type_name_list);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(497);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LET || _la==ID) {
				{
				setState(486);
				((Type_name_listContext)_localctx).type = type(0);
				((Type_name_listContext)_localctx).types.add(((Type_name_listContext)_localctx).type);
				setState(487);
				((Type_name_listContext)_localctx).name = name();
				((Type_name_listContext)_localctx).names.add(((Type_name_listContext)_localctx).name);
				setState(494);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(488);
					match(COMMA);
					setState(489);
					((Type_name_listContext)_localctx).type = type(0);
					((Type_name_listContext)_localctx).types.add(((Type_name_listContext)_localctx).type);
					setState(490);
					((Type_name_listContext)_localctx).name = name();
					((Type_name_listContext)_localctx).names.add(((Type_name_listContext)_localctx).name);
					}
					}
					setState(496);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class NameContext extends Carp.interpreter.ScopedParserRuleContext {
		public ModifierContext modifier;
		public List<ModifierContext> modifiers = new ArrayList<ModifierContext>();
		public TerminalNode ID() { return getToken(CarpGrammarParser.ID, 0); }
		public List<ModifierContext> modifier() {
			return getRuleContexts(ModifierContext.class);
		}
		public ModifierContext modifier(int i) {
			return getRuleContext(ModifierContext.class,i);
		}
		public NameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_name; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).enterName(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof CarpGrammarListener ) ((CarpGrammarListener)listener).exitName(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof CarpGrammarVisitor ) return ((CarpGrammarVisitor<? extends T>)visitor).visitName(this);
			else return visitor.visitChildren(this);
		}
	}

	public final NameContext name() throws RecognitionException {
		NameContext _localctx = new NameContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_name);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(502);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==UNDERSCORE) {
				{
				{
				setState(499);
				((NameContext)_localctx).modifier = modifier();
				((NameContext)_localctx).modifiers.add(((NameContext)_localctx).modifier);
				}
				}
				setState(504);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(505);
			match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 16:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		case 27:
			return type_sempred((TypeContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 16);
		case 1:
			return precpred(_ctx, 14);
		case 2:
			return precpred(_ctx, 13);
		case 3:
			return precpred(_ctx, 12);
		case 4:
			return precpred(_ctx, 8);
		case 5:
			return precpred(_ctx, 3);
		case 6:
			return precpred(_ctx, 2);
		case 7:
			return precpred(_ctx, 23);
		case 8:
			return precpred(_ctx, 22);
		case 9:
			return precpred(_ctx, 20);
		case 10:
			return precpred(_ctx, 19);
		case 11:
			return precpred(_ctx, 18);
		case 12:
			return precpred(_ctx, 17);
		case 13:
			return precpred(_ctx, 5);
		case 14:
			return precpred(_ctx, 4);
		}
		return true;
	}
	private boolean type_sempred(TypeContext _localctx, int predIndex) {
		switch (predIndex) {
		case 15:
			return precpred(_ctx, 6);
		case 16:
			return precpred(_ctx, 5);
		case 17:
			return precpred(_ctx, 4);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001I\u01fc\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0001\u0000\u0005\u0000"+
		">\b\u0000\n\u0000\f\u0000A\t\u0000\u0001\u0000\u0001\u0000\u0001\u0001"+
		"\u0005\u0001F\b\u0001\n\u0001\f\u0001I\t\u0001\u0001\u0002\u0001\u0002"+
		"\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0003\u0002S\b\u0002\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003"+
		"X\b\u0003\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004"+
		"\u0001\u0004\u0001\u0004\u0001\u0004\u0003\u0004b\b\u0004\u0001\u0005"+
		"\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005"+
		"\u0005\u0005k\b\u0005\n\u0005\f\u0005n\t\u0005\u0001\u0005\u0001\u0005"+
		"\u0003\u0005r\b\u0005\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0005\u0007\u0081\b\u0007\n\u0007"+
		"\f\u0007\u0084\t\u0007\u0001\u0007\u0001\u0007\u0003\u0007\u0088\b\u0007"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0005\u0007\u0091\b\u0007\n\u0007\f\u0007\u0094\t\u0007\u0001"+
		"\u0007\u0001\u0007\u0003\u0007\u0098\b\u0007\u0003\u0007\u009a\b\u0007"+
		"\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0003\b\u00be"+
		"\b\b\u0001\t\u0001\t\u0003\t\u00c2\b\t\u0001\n\u0001\n\u0001\u000b\u0001"+
		"\u000b\u0001\f\u0001\f\u0003\f\u00ca\b\f\u0001\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\r\u0001\r\u0003\r\u00d2\b\r\u0001\u000e\u0005\u000e\u00d5\b\u000e"+
		"\n\u000e\f\u000e\u00d8\t\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0005\u000f\u00f7\b\u000f\n\u000f\f\u000f\u00fa\t\u000f"+
		"\u0003\u000f\u00fc\b\u000f\u0001\u000f\u0001\u000f\u0005\u000f\u0100\b"+
		"\u000f\n\u000f\f\u000f\u0103\t\u000f\u0001\u000f\u0001\u000f\u0001\u000f"+
		"\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0005\u000f"+
		"\u010d\b\u000f\n\u000f\f\u000f\u0110\t\u000f\u0003\u000f\u0112\b\u000f"+
		"\u0001\u000f\u0001\u000f\u0005\u000f\u0116\b\u000f\n\u000f\f\u000f\u0119"+
		"\t\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0005\u000f\u0121\b\u000f\n\u000f\f\u000f\u0124\t\u000f\u0001\u000f"+
		"\u0001\u000f\u0003\u000f\u0128\b\u000f\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0003\u0010\u013f\b\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0005\u0010\u0176\b\u0010\n\u0010\f\u0010\u0179\t\u0010\u0001"+
		"\u0011\u0001\u0011\u0001\u0011\u0005\u0011\u017e\b\u0011\n\u0011\f\u0011"+
		"\u0181\t\u0011\u0003\u0011\u0183\b\u0011\u0001\u0012\u0001\u0012\u0001"+
		"\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0003"+
		"\u0012\u018d\b\u0012\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0003\u0013\u0195\b\u0013\u0001\u0014\u0001\u0014\u0003"+
		"\u0014\u0199\b\u0014\u0001\u0015\u0001\u0015\u0003\u0015\u019d\b\u0015"+
		"\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016"+
		"\u0003\u0016\u01a5\b\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0017"+
		"\u0001\u0017\u0001\u0017\u0003\u0017\u01ad\b\u0017\u0001\u0018\u0001\u0018"+
		"\u0001\u0018\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0005\u0019"+
		"\u01bc\b\u0019\n\u0019\f\u0019\u01bf\t\u0019\u0001\u0019\u0001\u0019\u0001"+
		"\u001a\u0001\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0004"+
		"\u001b\u01c9\b\u001b\u000b\u001b\f\u001b\u01ca\u0001\u001b\u0001\u001b"+
		"\u0003\u001b\u01cf\b\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b"+
		"\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b"+
		"\u0005\u001b\u01db\b\u001b\n\u001b\f\u001b\u01de\t\u001b\u0001\u001b\u0001"+
		"\u001b\u0005\u001b\u01e2\b\u001b\n\u001b\f\u001b\u01e5\t\u001b\u0001\u001c"+
		"\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001c\u0005\u001c"+
		"\u01ed\b\u001c\n\u001c\f\u001c\u01f0\t\u001c\u0003\u001c\u01f2\b\u001c"+
		"\u0001\u001d\u0005\u001d\u01f5\b\u001d\n\u001d\f\u001d\u01f8\t\u001d\u0001"+
		"\u001d\u0001\u001d\u0001\u001d\u0000\u0002 6\u001e\u0000\u0002\u0004\u0006"+
		"\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u001e \"$&(*,."+
		"02468:\u0000\u0003\u0001\u0000\u001d\u001e\u0002\u0000#$&&\u0001\u0000"+
		"%&\u0241\u0000?\u0001\u0000\u0000\u0000\u0002G\u0001\u0000\u0000\u0000"+
		"\u0004R\u0001\u0000\u0000\u0000\u0006W\u0001\u0000\u0000\u0000\ba\u0001"+
		"\u0000\u0000\u0000\nc\u0001\u0000\u0000\u0000\fs\u0001\u0000\u0000\u0000"+
		"\u000e\u0099\u0001\u0000\u0000\u0000\u0010\u00bd\u0001\u0000\u0000\u0000"+
		"\u0012\u00bf\u0001\u0000\u0000\u0000\u0014\u00c3\u0001\u0000\u0000\u0000"+
		"\u0016\u00c5\u0001\u0000\u0000\u0000\u0018\u00c7\u0001\u0000\u0000\u0000"+
		"\u001a\u00d1\u0001\u0000\u0000\u0000\u001c\u00d6\u0001\u0000\u0000\u0000"+
		"\u001e\u0127\u0001\u0000\u0000\u0000 \u013e\u0001\u0000\u0000\u0000\""+
		"\u0182\u0001\u0000\u0000\u0000$\u018c\u0001\u0000\u0000\u0000&\u0194\u0001"+
		"\u0000\u0000\u0000(\u0198\u0001\u0000\u0000\u0000*\u019c\u0001\u0000\u0000"+
		"\u0000,\u01a4\u0001\u0000\u0000\u0000.\u01ac\u0001\u0000\u0000\u00000"+
		"\u01ae\u0001\u0000\u0000\u00002\u01b2\u0001\u0000\u0000\u00004\u01c2\u0001"+
		"\u0000\u0000\u00006\u01ce\u0001\u0000\u0000\u00008\u01f1\u0001\u0000\u0000"+
		"\u0000:\u01f6\u0001\u0000\u0000\u0000<>\u0003\u0006\u0003\u0000=<\u0001"+
		"\u0000\u0000\u0000>A\u0001\u0000\u0000\u0000?=\u0001\u0000\u0000\u0000"+
		"?@\u0001\u0000\u0000\u0000@B\u0001\u0000\u0000\u0000A?\u0001\u0000\u0000"+
		"\u0000BC\u0005\u0000\u0000\u0001C\u0001\u0001\u0000\u0000\u0000DF\u0003"+
		"\u0006\u0003\u0000ED\u0001\u0000\u0000\u0000FI\u0001\u0000\u0000\u0000"+
		"GE\u0001\u0000\u0000\u0000GH\u0001\u0000\u0000\u0000H\u0003\u0001\u0000"+
		"\u0000\u0000IG\u0001\u0000\u0000\u0000JK\u0005\u0006\u0000\u0000KL\u0003"+
		"\u0002\u0001\u0000LM\u0005\u0007\u0000\u0000MS\u0001\u0000\u0000\u0000"+
		"NO\u0005/\u0000\u0000OS\u0003 \u0010\u0000PQ\u0005/\u0000\u0000QS\u0003"+
		"\u0006\u0003\u0000RJ\u0001\u0000\u0000\u0000RN\u0001\u0000\u0000\u0000"+
		"RP\u0001\u0000\u0000\u0000S\u0005\u0001\u0000\u0000\u0000TX\u0003\u001c"+
		"\u000e\u0000UX\u0003 \u0010\u0000VX\u0003\b\u0004\u0000WT\u0001\u0000"+
		"\u0000\u0000WU\u0001\u0000\u0000\u0000WV\u0001\u0000\u0000\u0000X\u0007"+
		"\u0001\u0000\u0000\u0000Yb\u0003\n\u0005\u0000Zb\u0003\f\u0006\u0000["+
		"b\u0003\u0010\b\u0000\\b\u0003\u0012\t\u0000]b\u0003\u000e\u0007\u0000"+
		"^b\u0003\u0014\n\u0000_b\u0003\u0016\u000b\u0000`b\u0003\u0018\f\u0000"+
		"aY\u0001\u0000\u0000\u0000aZ\u0001\u0000\u0000\u0000a[\u0001\u0000\u0000"+
		"\u0000a\\\u0001\u0000\u0000\u0000a]\u0001\u0000\u0000\u0000a^\u0001\u0000"+
		"\u0000\u0000a_\u0001\u0000\u0000\u0000a`\u0001\u0000\u0000\u0000b\t\u0001"+
		"\u0000\u0000\u0000cd\u00057\u0000\u0000de\u0003 \u0010\u0000el\u0003\u0004"+
		"\u0002\u0000fg\u00059\u0000\u0000gh\u0003 \u0010\u0000hi\u0003\u0004\u0002"+
		"\u0000ik\u0001\u0000\u0000\u0000jf\u0001\u0000\u0000\u0000kn\u0001\u0000"+
		"\u0000\u0000lj\u0001\u0000\u0000\u0000lm\u0001\u0000\u0000\u0000mq\u0001"+
		"\u0000\u0000\u0000nl\u0001\u0000\u0000\u0000op\u00058\u0000\u0000pr\u0003"+
		"\u0004\u0002\u0000qo\u0001\u0000\u0000\u0000qr\u0001\u0000\u0000\u0000"+
		"r\u000b\u0001\u0000\u0000\u0000st\u0005:\u0000\u0000tu\u0003 \u0010\u0000"+
		"uv\u0003\u0004\u0002\u0000v\r\u0001\u0000\u0000\u0000wx\u00054\u0000\u0000"+
		"x\u0082\u0003\u0004\u0002\u0000yz\u00055\u0000\u0000z{\u0005\u0004\u0000"+
		"\u0000{|\u00036\u001b\u0000|}\u0003:\u001d\u0000}~\u0005\u0005\u0000\u0000"+
		"~\u007f\u0003\u0004\u0002\u0000\u007f\u0081\u0001\u0000\u0000\u0000\u0080"+
		"y\u0001\u0000\u0000\u0000\u0081\u0084\u0001\u0000\u0000\u0000\u0082\u0080"+
		"\u0001\u0000\u0000\u0000\u0082\u0083\u0001\u0000\u0000\u0000\u0083\u0087"+
		"\u0001\u0000\u0000\u0000\u0084\u0082\u0001\u0000\u0000\u0000\u0085\u0086"+
		"\u00056\u0000\u0000\u0086\u0088\u0003\u0004\u0002\u0000\u0087\u0085\u0001"+
		"\u0000\u0000\u0000\u0087\u0088\u0001\u0000\u0000\u0000\u0088\u009a\u0001"+
		"\u0000\u0000\u0000\u0089\u008a\u00054\u0000\u0000\u008a\u0092\u0003\u0004"+
		"\u0002\u0000\u008b\u008c\u00055\u0000\u0000\u008c\u008d\u00036\u001b\u0000"+
		"\u008d\u008e\u0003:\u001d\u0000\u008e\u008f\u0003\u0004\u0002\u0000\u008f"+
		"\u0091\u0001\u0000\u0000\u0000\u0090\u008b\u0001\u0000\u0000\u0000\u0091"+
		"\u0094\u0001\u0000\u0000\u0000\u0092\u0090\u0001\u0000\u0000\u0000\u0092"+
		"\u0093\u0001\u0000\u0000\u0000\u0093\u0097\u0001\u0000\u0000\u0000\u0094"+
		"\u0092\u0001\u0000\u0000\u0000\u0095\u0096\u00056\u0000\u0000\u0096\u0098"+
		"\u0003\u0004\u0002\u0000\u0097\u0095\u0001\u0000\u0000\u0000\u0097\u0098"+
		"\u0001\u0000\u0000\u0000\u0098\u009a\u0001\u0000\u0000\u0000\u0099w\u0001"+
		"\u0000\u0000\u0000\u0099\u0089\u0001\u0000\u0000\u0000\u009a\u000f\u0001"+
		"\u0000\u0000\u0000\u009b\u009c\u0005;\u0000\u0000\u009c\u009d\u0003 \u0010"+
		"\u0000\u009d\u009e\u0003\u0004\u0002\u0000\u009e\u00be\u0001\u0000\u0000"+
		"\u0000\u009f\u00a0\u0005;\u0000\u0000\u00a0\u00a1\u00036\u001b\u0000\u00a1"+
		"\u00a2\u0003:\u001d\u0000\u00a2\u00a3\u0005+\u0000\u0000\u00a3\u00a4\u0003"+
		" \u0010\u0000\u00a4\u00a5\u0003\u0004\u0002\u0000\u00a5\u00be\u0001\u0000"+
		"\u0000\u0000\u00a6\u00a7\u0005;\u0000\u0000\u00a7\u00a8\u0005\u0004\u0000"+
		"\u0000\u00a8\u00a9\u00036\u001b\u0000\u00a9\u00aa\u0003:\u001d\u0000\u00aa"+
		"\u00ab\u0005+\u0000\u0000\u00ab\u00ac\u0003 \u0010\u0000\u00ac\u00ad\u0005"+
		"\u0005\u0000\u0000\u00ad\u00ae\u0003\u0004\u0002\u0000\u00ae\u00be\u0001"+
		"\u0000\u0000\u0000\u00af\u00b0\u0005;\u0000\u0000\u00b0\u00b1\u00038\u001c"+
		"\u0000\u00b1\u00b2\u0005+\u0000\u0000\u00b2\u00b3\u0003 \u0010\u0000\u00b3"+
		"\u00b4\u0003\u0004\u0002\u0000\u00b4\u00be\u0001\u0000\u0000\u0000\u00b5"+
		"\u00b6\u0005;\u0000\u0000\u00b6\u00b7\u0005\u0004\u0000\u0000\u00b7\u00b8"+
		"\u00038\u001c\u0000\u00b8\u00b9\u0005+\u0000\u0000\u00b9\u00ba\u0003 "+
		"\u0010\u0000\u00ba\u00bb\u0005\u0005\u0000\u0000\u00bb\u00bc\u0003\u0004"+
		"\u0002\u0000\u00bc\u00be\u0001\u0000\u0000\u0000\u00bd\u009b\u0001\u0000"+
		"\u0000\u0000\u00bd\u009f\u0001\u0000\u0000\u0000\u00bd\u00a6\u0001\u0000"+
		"\u0000\u0000\u00bd\u00af\u0001\u0000\u0000\u0000\u00bd\u00b5\u0001\u0000"+
		"\u0000\u0000\u00be\u0011\u0001\u0000\u0000\u0000\u00bf\u00c1\u0005<\u0000"+
		"\u0000\u00c0\u00c2\u0003 \u0010\u0000\u00c1\u00c0\u0001\u0000\u0000\u0000"+
		"\u00c1\u00c2\u0001\u0000\u0000\u0000\u00c2\u0013\u0001\u0000\u0000\u0000"+
		"\u00c3\u00c4\u0005=\u0000\u0000\u00c4\u0015\u0001\u0000\u0000\u0000\u00c5"+
		"\u00c6\u0005>\u0000\u0000\u00c6\u0017\u0001\u0000\u0000\u0000\u00c7\u00c9"+
		"\u0005?\u0000\u0000\u00c8\u00ca\u0003 \u0010\u0000\u00c9\u00c8\u0001\u0000"+
		"\u0000\u0000\u00c9\u00ca\u0001\u0000\u0000\u0000\u00ca\u0019\u0001\u0000"+
		"\u0000\u0000\u00cb\u00cc\u0005\u0015\u0000\u0000\u00cc\u00d2\u0003 \u0010"+
		"\u0000\u00cd\u00ce\u0005\b\u0000\u0000\u00ce\u00cf\u0003 \u0010\u0000"+
		"\u00cf\u00d0\u0005\t\u0000\u0000\u00d0\u00d2\u0001\u0000\u0000\u0000\u00d1"+
		"\u00cb\u0001\u0000\u0000\u0000\u00d1\u00cd\u0001\u0000\u0000\u0000\u00d2"+
		"\u001b\u0001\u0000\u0000\u0000\u00d3\u00d5\u0003\u001a\r\u0000\u00d4\u00d3"+
		"\u0001\u0000\u0000\u0000\u00d5\u00d8\u0001\u0000\u0000\u0000\u00d6\u00d4"+
		"\u0001\u0000\u0000\u0000\u00d6\u00d7\u0001\u0000\u0000\u0000\u00d7\u00d9"+
		"\u0001\u0000\u0000\u0000\u00d8\u00d6\u0001\u0000\u0000\u0000\u00d9\u00da"+
		"\u0003\u001e\u000f\u0000\u00da\u001d\u0001\u0000\u0000\u0000\u00db\u00dc"+
		"\u00036\u001b\u0000\u00dc\u00dd\u0003:\u001d\u0000\u00dd\u00de\u0005\u0004"+
		"\u0000\u0000\u00de\u00df\u00038\u001c\u0000\u00df\u00e0\u0005\u0005\u0000"+
		"\u0000\u00e0\u00e1\u0003\u0004\u0002\u0000\u00e1\u0128\u0001\u0000\u0000"+
		"\u0000\u00e2\u00e3\u00036\u001b\u0000\u00e3\u00e4\u0003:\u001d\u0000\u00e4"+
		"\u00e5\u0005\u0004\u0000\u0000\u00e5\u00e6\u00038\u001c\u0000\u00e6\u00e7"+
		"\u0005\u0005\u0000\u0000\u00e7\u0128\u0001\u0000\u0000\u0000\u00e8\u00e9"+
		"\u00036\u001b\u0000\u00e9\u00ea\u0003:\u001d\u0000\u00ea\u00eb\u0005\n"+
		"\u0000\u0000\u00eb\u00ec\u0003 \u0010\u0000\u00ec\u0128\u0001\u0000\u0000"+
		"\u0000\u00ed\u00ee\u00036\u001b\u0000\u00ee\u00ef\u0003:\u001d\u0000\u00ef"+
		"\u0128\u0001\u0000\u0000\u0000\u00f0\u00f1\u0005@\u0000\u0000\u00f1\u00fb"+
		"\u0003:\u001d\u0000\u00f2\u00f3\u0005+\u0000\u0000\u00f3\u00f8\u00036"+
		"\u001b\u0000\u00f4\u00f5\u0005\u0003\u0000\u0000\u00f5\u00f7\u00036\u001b"+
		"\u0000\u00f6\u00f4\u0001\u0000\u0000\u0000\u00f7\u00fa\u0001\u0000\u0000"+
		"\u0000\u00f8\u00f6\u0001\u0000\u0000\u0000\u00f8\u00f9\u0001\u0000\u0000"+
		"\u0000\u00f9\u00fc\u0001\u0000\u0000\u0000\u00fa\u00f8\u0001\u0000\u0000"+
		"\u0000\u00fb\u00f2\u0001\u0000\u0000\u0000\u00fb\u00fc\u0001\u0000\u0000"+
		"\u0000\u00fc\u00fd\u0001\u0000\u0000\u0000\u00fd\u0101\u0005\u0006\u0000"+
		"\u0000\u00fe\u0100\u0003\u001c\u000e\u0000\u00ff\u00fe\u0001\u0000\u0000"+
		"\u0000\u0100\u0103\u0001\u0000\u0000\u0000\u0101\u00ff\u0001\u0000\u0000"+
		"\u0000\u0101\u0102\u0001\u0000\u0000\u0000\u0102\u0104\u0001\u0000\u0000"+
		"\u0000\u0103\u0101\u0001\u0000\u0000\u0000\u0104\u0105\u0005\u0007\u0000"+
		"\u0000\u0105\u0128\u0001\u0000\u0000\u0000\u0106\u0107\u0005A\u0000\u0000"+
		"\u0107\u0111\u0003:\u001d\u0000\u0108\u0109\u0005+\u0000\u0000\u0109\u010e"+
		"\u00036\u001b\u0000\u010a\u010b\u0005\u0003\u0000\u0000\u010b\u010d\u0003"+
		"6\u001b\u0000\u010c\u010a\u0001\u0000\u0000\u0000\u010d\u0110\u0001\u0000"+
		"\u0000\u0000\u010e\u010c\u0001\u0000\u0000\u0000\u010e\u010f\u0001\u0000"+
		"\u0000\u0000\u010f\u0112\u0001\u0000\u0000\u0000\u0110\u010e\u0001\u0000"+
		"\u0000\u0000\u0111\u0108\u0001\u0000\u0000\u0000\u0111\u0112\u0001\u0000"+
		"\u0000\u0000\u0112\u0113\u0001\u0000\u0000\u0000\u0113\u0117\u0005\u0006"+
		"\u0000\u0000\u0114\u0116\u0003\u001c\u000e\u0000\u0115\u0114\u0001\u0000"+
		"\u0000\u0000\u0116\u0119\u0001\u0000\u0000\u0000\u0117\u0115\u0001\u0000"+
		"\u0000\u0000\u0117\u0118\u0001\u0000\u0000\u0000\u0118\u011a\u0001\u0000"+
		"\u0000\u0000\u0119\u0117\u0001\u0000\u0000\u0000\u011a\u011b\u0005\u0007"+
		"\u0000\u0000\u011b\u0128\u0001\u0000\u0000\u0000\u011c\u011d\u0005C\u0000"+
		"\u0000\u011d\u011e\u0003:\u001d\u0000\u011e\u0122\u0005\u0006\u0000\u0000"+
		"\u011f\u0121\u0003:\u001d\u0000\u0120\u011f\u0001\u0000\u0000\u0000\u0121"+
		"\u0124\u0001\u0000\u0000\u0000\u0122\u0120\u0001\u0000\u0000\u0000\u0122"+
		"\u0123\u0001\u0000\u0000\u0000\u0123\u0125\u0001\u0000\u0000\u0000\u0124"+
		"\u0122\u0001\u0000\u0000\u0000\u0125\u0126\u0005\u0007\u0000\u0000\u0126"+
		"\u0128\u0001\u0000\u0000\u0000\u0127\u00db\u0001\u0000\u0000\u0000\u0127"+
		"\u00e2\u0001\u0000\u0000\u0000\u0127\u00e8\u0001\u0000\u0000\u0000\u0127"+
		"\u00ed\u0001\u0000\u0000\u0000\u0127\u00f0\u0001\u0000\u0000\u0000\u0127"+
		"\u0106\u0001\u0000\u0000\u0000\u0127\u011c\u0001\u0000\u0000\u0000\u0128"+
		"\u001f\u0001\u0000\u0000\u0000\u0129\u012a\u0006\u0010\uffff\uffff\u0000"+
		"\u012a\u013f\u0003&\u0013\u0000\u012b\u012c\u0007\u0000\u0000\u0000\u012c"+
		"\u013f\u0003 \u0010\u0015\u012d\u012e\u0003(\u0014\u0000\u012e\u012f\u0003"+
		" \u0010\u000f\u012f\u013f\u0001\u0000\u0000\u0000\u0130\u013f\u00032\u0019"+
		"\u0000\u0131\u013f\u00030\u0018\u0000\u0132\u013f\u0003:\u001d\u0000\u0133"+
		"\u0134\u0005\u0001\u0000\u0000\u0134\u013f\u0003 \u0010\u0007\u0135\u0136"+
		"\u0005\u0004\u0000\u0000\u0136\u0137\u0003 \u0010\u0000\u0137\u0138\u0005"+
		"\u0005\u0000\u0000\u0138\u013f\u0001\u0000\u0000\u0000\u0139\u013a\u0005"+
		"\u0004\u0000\u0000\u013a\u013b\u00038\u001c\u0000\u013b\u013c\u0005\u0005"+
		"\u0000\u0000\u013c\u013d\u0003\u0004\u0002\u0000\u013d\u013f\u0001\u0000"+
		"\u0000\u0000\u013e\u0129\u0001\u0000\u0000\u0000\u013e\u012b\u0001\u0000"+
		"\u0000\u0000\u013e\u012d\u0001\u0000\u0000\u0000\u013e\u0130\u0001\u0000"+
		"\u0000\u0000\u013e\u0131\u0001\u0000\u0000\u0000\u013e\u0132\u0001\u0000"+
		"\u0000\u0000\u013e\u0133\u0001\u0000\u0000\u0000\u013e\u0135\u0001\u0000"+
		"\u0000\u0000\u013e\u0139\u0001\u0000\u0000\u0000\u013f\u0177\u0001\u0000"+
		"\u0000\u0000\u0140\u0141\n\u0010\u0000\u0000\u0141\u0142\u0003.\u0017"+
		"\u0000\u0142\u0143\u0003 \u0010\u0011\u0143\u0176\u0001\u0000\u0000\u0000"+
		"\u0144\u0145\n\u000e\u0000\u0000\u0145\u0146\u0003,\u0016\u0000\u0146"+
		"\u0147\u0003 \u0010\u000f\u0147\u0176\u0001\u0000\u0000\u0000\u0148\u0149"+
		"\n\r\u0000\u0000\u0149\u014a\u0003*\u0015\u0000\u014a\u014b\u0003 \u0010"+
		"\u000e\u014b\u0176\u0001\u0000\u0000\u0000\u014c\u014d\n\f\u0000\u0000"+
		"\u014d\u014e\u0005)\u0000\u0000\u014e\u014f\u0003 \u0010\u0000\u014f\u0150"+
		"\u0005+\u0000\u0000\u0150\u0151\u0003 \u0010\r\u0151\u0176\u0001\u0000"+
		"\u0000\u0000\u0152\u0153\n\b\u0000\u0000\u0153\u0154\u0005\u0001\u0000"+
		"\u0000\u0154\u0176\u0003 \u0010\t\u0155\u0156\n\u0003\u0000\u0000\u0156"+
		"\u0157\u0005\n\u0000\u0000\u0157\u0176\u0003 \u0010\u0004\u0158\u0159"+
		"\n\u0002\u0000\u0000\u0159\u015a\u0003$\u0012\u0000\u015a\u015b\u0003"+
		" \u0010\u0003\u015b\u0176\u0001\u0000\u0000\u0000\u015c\u015d\n\u0017"+
		"\u0000\u0000\u015d\u015e\u0005\u0013\u0000\u0000\u015e\u0176\u00036\u001b"+
		"\u0000\u015f\u0160\n\u0016\u0000\u0000\u0160\u0161\u0005\u0014\u0000\u0000"+
		"\u0161\u0176\u00036\u001b\u0000\u0162\u0163\n\u0014\u0000\u0000\u0163"+
		"\u0176\u0007\u0000\u0000\u0000\u0164\u0165\n\u0013\u0000\u0000\u0165\u0166"+
		"\u0005\u0004\u0000\u0000\u0166\u0167\u0003\"\u0011\u0000\u0167\u0168\u0005"+
		"\u0005\u0000\u0000\u0168\u0176\u0001\u0000\u0000\u0000\u0169\u016a\n\u0012"+
		"\u0000\u0000\u016a\u016b\u0005\b\u0000\u0000\u016b\u016c\u0003\"\u0011"+
		"\u0000\u016c\u016d\u0005\t\u0000\u0000\u016d\u0176\u0001\u0000\u0000\u0000"+
		"\u016e\u016f\n\u0011\u0000\u0000\u016f\u0170\u0005\u0002\u0000\u0000\u0170"+
		"\u0176\u0003:\u001d\u0000\u0171\u0172\n\u0005\u0000\u0000\u0172\u0176"+
		"\u0005-\u0000\u0000\u0173\u0174\n\u0004\u0000\u0000\u0174\u0176\u0005"+
		".\u0000\u0000\u0175\u0140\u0001\u0000\u0000\u0000\u0175\u0144\u0001\u0000"+
		"\u0000\u0000\u0175\u0148\u0001\u0000\u0000\u0000\u0175\u014c\u0001\u0000"+
		"\u0000\u0000\u0175\u0152\u0001\u0000\u0000\u0000\u0175\u0155\u0001\u0000"+
		"\u0000\u0000\u0175\u0158\u0001\u0000\u0000\u0000\u0175\u015c\u0001\u0000"+
		"\u0000\u0000\u0175\u015f\u0001\u0000\u0000\u0000\u0175\u0162\u0001\u0000"+
		"\u0000\u0000\u0175\u0164\u0001\u0000\u0000\u0000\u0175\u0169\u0001\u0000"+
		"\u0000\u0000\u0175\u016e\u0001\u0000\u0000\u0000\u0175\u0171\u0001\u0000"+
		"\u0000\u0000\u0175\u0173\u0001\u0000\u0000\u0000\u0176\u0179\u0001\u0000"+
		"\u0000\u0000\u0177\u0175\u0001\u0000\u0000\u0000\u0177\u0178\u0001\u0000"+
		"\u0000\u0000\u0178!\u0001\u0000\u0000\u0000\u0179\u0177\u0001\u0000\u0000"+
		"\u0000\u017a\u017f\u0003 \u0010\u0000\u017b\u017c\u0005\u0003\u0000\u0000"+
		"\u017c\u017e\u0003 \u0010\u0000\u017d\u017b\u0001\u0000\u0000\u0000\u017e"+
		"\u0181\u0001\u0000\u0000\u0000\u017f\u017d\u0001\u0000\u0000\u0000\u017f"+
		"\u0180\u0001\u0000\u0000\u0000\u0180\u0183\u0001\u0000\u0000\u0000\u0181"+
		"\u017f\u0001\u0000\u0000\u0000\u0182\u017a\u0001\u0000\u0000\u0000\u0182"+
		"\u0183\u0001\u0000\u0000\u0000\u0183#\u0001\u0000\u0000\u0000\u0184\u018d"+
		"\u0005\u0017\u0000\u0000\u0185\u018d\u0005\u0018\u0000\u0000\u0186\u018d"+
		"\u0005\u0019\u0000\u0000\u0187\u018d\u0005\u001a\u0000\u0000\u0188\u0189"+
		"\u0005$\u0000\u0000\u0189\u018d\u0005\n\u0000\u0000\u018a\u018d\u0005"+
		"\u001b\u0000\u0000\u018b\u018d\u0005\u001c\u0000\u0000\u018c\u0184\u0001"+
		"\u0000\u0000\u0000\u018c\u0185\u0001\u0000\u0000\u0000\u018c\u0186\u0001"+
		"\u0000\u0000\u0000\u018c\u0187\u0001\u0000\u0000\u0000\u018c\u0188\u0001"+
		"\u0000\u0000\u0000\u018c\u018a\u0001\u0000\u0000\u0000\u018c\u018b\u0001"+
		"\u0000\u0000\u0000\u018d%\u0001\u0000\u0000\u0000\u018e\u0195\u0005E\u0000"+
		"\u0000\u018f\u0195\u0005H\u0000\u0000\u0190\u0195\u0005I\u0000\u0000\u0191"+
		"\u0195\u00051\u0000\u0000\u0192\u0195\u00052\u0000\u0000\u0193\u0195\u0005"+
		"3\u0000\u0000\u0194\u018e\u0001\u0000\u0000\u0000\u0194\u018f\u0001\u0000"+
		"\u0000\u0000\u0194\u0190\u0001\u0000\u0000\u0000\u0194\u0191\u0001\u0000"+
		"\u0000\u0000\u0194\u0192\u0001\u0000\u0000\u0000\u0194\u0193\u0001\u0000"+
		"\u0000\u0000\u0195\'\u0001\u0000\u0000\u0000\u0196\u0199\u0005 \u0000"+
		"\u0000\u0197\u0199\u0005\u0016\u0000\u0000\u0198\u0196\u0001\u0000\u0000"+
		"\u0000\u0198\u0197\u0001\u0000\u0000\u0000\u0199)\u0001\u0000\u0000\u0000"+
		"\u019a\u019d\u0005\u0012\u0000\u0000\u019b\u019d\u0005\u0011\u0000\u0000"+
		"\u019c\u019a\u0001\u0000\u0000\u0000\u019c\u019b\u0001\u0000\u0000\u0000"+
		"\u019d+\u0001\u0000\u0000\u0000\u019e\u01a5\u0005\u000b\u0000\u0000\u019f"+
		"\u01a5\u0005\f\u0000\u0000\u01a0\u01a5\u0005\r\u0000\u0000\u01a1\u01a5"+
		"\u0005\u000e\u0000\u0000\u01a2\u01a5\u0005\u0010\u0000\u0000\u01a3\u01a5"+
		"\u0005\u000f\u0000\u0000\u01a4\u019e\u0001\u0000\u0000\u0000\u01a4\u019f"+
		"\u0001\u0000\u0000\u0000\u01a4\u01a0\u0001\u0000\u0000\u0000\u01a4\u01a1"+
		"\u0001\u0000\u0000\u0000\u01a4\u01a2\u0001\u0000\u0000\u0000\u01a4\u01a3"+
		"\u0001\u0000\u0000\u0000\u01a5-\u0001\u0000\u0000\u0000\u01a6\u01ad\u0005"+
		"\u001f\u0000\u0000\u01a7\u01ad\u0005 \u0000\u0000\u01a8\u01ad\u0007\u0001"+
		"\u0000\u0000\u01a9\u01ad\u0005!\u0000\u0000\u01aa\u01ad\u0005(\u0000\u0000"+
		"\u01ab\u01ad\u0005\"\u0000\u0000\u01ac\u01a6\u0001\u0000\u0000\u0000\u01ac"+
		"\u01a7\u0001\u0000\u0000\u0000\u01ac\u01a8\u0001\u0000\u0000\u0000\u01ac"+
		"\u01a9\u0001\u0000\u0000\u0000\u01ac\u01aa\u0001\u0000\u0000\u0000\u01ac"+
		"\u01ab\u0001\u0000\u0000\u0000\u01ad/\u0001\u0000\u0000\u0000\u01ae\u01af"+
		"\u0005\b\u0000\u0000\u01af\u01b0\u0003\"\u0011\u0000\u01b0\u01b1\u0005"+
		"\t\u0000\u0000\u01b11\u0001\u0000\u0000\u0000\u01b2\u01b3\u0005\b\u0000"+
		"\u0000\u01b3\u01b4\u0003 \u0010\u0000\u01b4\u01b5\u0005+\u0000\u0000\u01b5"+
		"\u01bd\u0003 \u0010\u0000\u01b6\u01b7\u0005\u0003\u0000\u0000\u01b7\u01b8"+
		"\u0003 \u0010\u0000\u01b8\u01b9\u0005+\u0000\u0000\u01b9\u01ba\u0003 "+
		"\u0010\u0000\u01ba\u01bc\u0001\u0000\u0000\u0000\u01bb\u01b6\u0001\u0000"+
		"\u0000\u0000\u01bc\u01bf\u0001\u0000\u0000\u0000\u01bd\u01bb\u0001\u0000"+
		"\u0000\u0000\u01bd\u01be\u0001\u0000\u0000\u0000\u01be\u01c0\u0001\u0000"+
		"\u0000\u0000\u01bf\u01bd\u0001\u0000\u0000\u0000\u01c0\u01c1\u0005\t\u0000"+
		"\u0000\u01c13\u0001\u0000\u0000\u0000\u01c2\u01c3\u0005*\u0000\u0000\u01c3"+
		"5\u0001\u0000\u0000\u0000\u01c4\u01c5\u0006\u001b\uffff\uffff\u0000\u01c5"+
		"\u01c8\u0005D\u0000\u0000\u01c6\u01c7\u0005\u0002\u0000\u0000\u01c7\u01c9"+
		"\u0005D\u0000\u0000\u01c8\u01c6\u0001\u0000\u0000\u0000\u01c9\u01ca\u0001"+
		"\u0000\u0000\u0000\u01ca\u01c8\u0001\u0000\u0000\u0000\u01ca\u01cb\u0001"+
		"\u0000\u0000\u0000\u01cb\u01cf\u0001\u0000\u0000\u0000\u01cc\u01cf\u0005"+
		"D\u0000\u0000\u01cd\u01cf\u0005B\u0000\u0000\u01ce\u01c4\u0001\u0000\u0000"+
		"\u0000\u01ce\u01cc\u0001\u0000\u0000\u0000\u01ce\u01cd\u0001\u0000\u0000"+
		"\u0000\u01cf\u01e3\u0001\u0000\u0000\u0000\u01d0\u01d1\n\u0006\u0000\u0000"+
		"\u01d1\u01d2\u0005+\u0000\u0000\u01d2\u01e2\u00036\u001b\u0007\u01d3\u01d4"+
		"\n\u0005\u0000\u0000\u01d4\u01e2\u0007\u0002\u0000\u0000\u01d5\u01d6\n"+
		"\u0004\u0000\u0000\u01d6\u01d7\u0005\u000e\u0000\u0000\u01d7\u01dc\u0003"+
		"6\u001b\u0000\u01d8\u01d9\u0005\u0003\u0000\u0000\u01d9\u01db\u00036\u001b"+
		"\u0000\u01da\u01d8\u0001\u0000\u0000\u0000\u01db\u01de\u0001\u0000\u0000"+
		"\u0000\u01dc\u01da\u0001\u0000\u0000\u0000\u01dc\u01dd\u0001\u0000\u0000"+
		"\u0000\u01dd\u01df\u0001\u0000\u0000\u0000\u01de\u01dc\u0001\u0000\u0000"+
		"\u0000\u01df\u01e0\u0005\r\u0000\u0000\u01e0\u01e2\u0001\u0000\u0000\u0000"+
		"\u01e1\u01d0\u0001\u0000\u0000\u0000\u01e1\u01d3\u0001\u0000\u0000\u0000"+
		"\u01e1\u01d5\u0001\u0000\u0000\u0000\u01e2\u01e5\u0001\u0000\u0000\u0000"+
		"\u01e3\u01e1\u0001\u0000\u0000\u0000\u01e3\u01e4\u0001\u0000\u0000\u0000"+
		"\u01e47\u0001\u0000\u0000\u0000\u01e5\u01e3\u0001\u0000\u0000\u0000\u01e6"+
		"\u01e7\u00036\u001b\u0000\u01e7\u01ee\u0003:\u001d\u0000\u01e8\u01e9\u0005"+
		"\u0003\u0000\u0000\u01e9\u01ea\u00036\u001b\u0000\u01ea\u01eb\u0003:\u001d"+
		"\u0000\u01eb\u01ed\u0001\u0000\u0000\u0000\u01ec\u01e8\u0001\u0000\u0000"+
		"\u0000\u01ed\u01f0\u0001\u0000\u0000\u0000\u01ee\u01ec\u0001\u0000\u0000"+
		"\u0000\u01ee\u01ef\u0001\u0000\u0000\u0000\u01ef\u01f2\u0001\u0000\u0000"+
		"\u0000\u01f0\u01ee\u0001\u0000\u0000\u0000\u01f1\u01e6\u0001\u0000\u0000"+
		"\u0000\u01f1\u01f2\u0001\u0000\u0000\u0000\u01f29\u0001\u0000\u0000\u0000"+
		"\u01f3\u01f5\u00034\u001a\u0000\u01f4\u01f3\u0001\u0000\u0000\u0000\u01f5"+
		"\u01f8\u0001\u0000\u0000\u0000\u01f6\u01f4\u0001\u0000\u0000\u0000\u01f6"+
		"\u01f7\u0001\u0000\u0000\u0000\u01f7\u01f9\u0001\u0000\u0000\u0000\u01f8"+
		"\u01f6\u0001\u0000\u0000\u0000\u01f9\u01fa\u0005D\u0000\u0000\u01fa;\u0001"+
		"\u0000\u0000\u0000-?GRWalq\u0082\u0087\u0092\u0097\u0099\u00bd\u00c1\u00c9"+
		"\u00d1\u00d6\u00f8\u00fb\u0101\u010e\u0111\u0117\u0122\u0127\u013e\u0175"+
		"\u0177\u017f\u0182\u018c\u0194\u0198\u019c\u01a4\u01ac\u01bd\u01ca\u01ce"+
		"\u01dc\u01e1\u01e3\u01ee\u01f1\u01f6";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}