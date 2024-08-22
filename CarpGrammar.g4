grammar CarpGrammar;

options {
    contextSuperClass = Carp.interpreter.ScopedParserRuleContext;
}

ELIPSIS : '..'  ;
PERIOD : '.' ;
COMMA : ',' ;

LPAREN : '(' ;
RPAREN : ')' ;
LBRACE : '{' ;
RBRACE : '}' ;
LBRACKET : '[' ;
RBRACKET : ']' ;

EQUALS : '=' ;
EQUALS_EQUALS : '==' ;
NOT_EQUALS : '!=' | '<>' ;
GREATER_THAN : '>' ;
LESS_THAN : '<' ;
LESS_THAN_EQUALS : '<=' ;
GREATER_THAN_EQUALS : '>=' ;
PIPE : '|' ;
AMPERSAND : '&' ;
TILDE : '~' ;
TILDE_TILDE : '~~' ;
AT : '@' ;

BANG : '!' ;
PLUS_EQUALS : '+=' ;
MINUS_EQUALS : '-=' ;
ASTERISK_EQUALS : '*=' ;
SLASH_EQUALS : '/=' ;
CARET_EQUALS : '^=' ;
PERCENT_EQUALS : '%=' ;
PLUS_PLUS : '++' ;
MINUS_MINUS : '--' ;
PLUS : '+' ;
MINUS : '-' ;
SLASH : '/' ;
PERCENT : '%' ;
ASTERISK_BSPACE : ' * ' ;
ASTERISK_LSPACE : ' *' ;
ASTERISK_RSPACE : '* ' ;
ASTERISK_NSPC : '*' ;
BACKSLASH : '\\' ;

CARET : '^' ;
QUESTION_MARK : '?' ;
UNDERSCORE : '_' ;
COLON : ':' ;
SEMICOLON : ';' ;
COLON_COLON : '::' ;
SEMICOLON_SEMICOLON : ';;' ;
ARROW : '->' ;
HASH : '#' ;

TRUE : 'true' ;
FALSE : 'false' ;
NULL : 'null' ;

TRY: 'try' ;
CATCH: 'catch' ;
FINALLY: 'finally' ;
IF : 'if' ;
ELSE : 'else' ;
ELSE_IF : 'else if' ;
WHILE : 'while' ;
ITER : 'for' ;
RETURN : 'return' ;
BREAK : 'break' ;
CONTINUE : 'continue' ;
YIELD : 'yield' ;
CLASS : 'class' ;
STRUCT : 'struct' ;
LET : 'let' ;
FIXED : 'fixed' ;
//IMPORT : 'import' ;

ID : [a-zA-Z][a-zA-Z0-9_]* ;
//STRING : '\'' (~['\\])* '\'' ;
INT : '-'? ( [0-9]+ | [0-9]+ '.' [0-9]+ | '.' [0-9]+ ) ;
WS : [ \t\r\n]+ -> skip ;
COMMENT : '#' .*? [\n] -> skip ;
STRING : '\'' SHORT_STRING_ITEM_FOR_SINGLE_QUOTE* '\'' ;
CHAR : '`' . ;
    
fragment SHORT_STRING_ITEM_FOR_SINGLE_QUOTE : SHORT_STRING_CHAR_NO_SINGLE_QUOTE | ('\\' .);
fragment SHORT_STRING_CHAR_NO_SINGLE_QUOTE : ~[\\'];

//PATH : [a-zA-Z0-9_\-.]+ ;

program : (statements+=statement)* EOF ;

block : (statements+=statement)* ;

generic_block
    : '{' block '}' # enclosedBlock
    | '->' expression # lambdaExpressionBlock
    | '->' statement # lambdaBlock
    ;

statement
//    : IMPORT loc+=(ID | PERIOD | MINUS | SLASH | UNDERSCORE | INT)* (':' ver+=(ID | PERIOD | MINUS | SLASH | UNDERSCORE | INT | COLON)+)? ';' # importStatement
    : definition_with_attr # definitionStatement
    | expression # expressionStatement
    | flow_control # flowControlStatement
    ;

flow_control
    : if_statement
    | while_statement
    | iter_statement
    | return_statement
    | try_statement
    | break_statement
    | continue_statement
    | yield_statement
    ;

if_statement
    : IF cond=expression body=generic_block (ELSE_IF elif_expressions+=expression elif_blocks+=generic_block)* (ELSE else_block=generic_block)?
    ;

while_statement
    : WHILE cond=expression body=generic_block
    ;
    
try_statement
    : TRY try_block=generic_block (CATCH '(' catch_types+=type catch_names+=name ')' catch_blocks+=generic_block)* (FINALLY finally_block=generic_block)?
    | TRY try_block=generic_block (CATCH catch_types+=type catch_names+=name catch_blocks+=generic_block)* (FINALLY finally_block=generic_block)?
    ;

iter_statement
    : ITER iter=expression body=generic_block # iterStatement
    | ITER type name ':'  iter=expression  body=generic_block # iterAsStatement
    | ITER '(' type name ':'  iter=expression ')'  body=generic_block # iterAsStatement
    | ITER type_name_list ':'  iter=expression  body=generic_block # iterAsUnpackedStatement
    | ITER '(' type_name_list ':'  iter=expression ')'  body=generic_block # iterAsUnpackedStatement
    ;

return_statement : RETURN value=expression? ;
break_statement : BREAK ;
continue_statement : CONTINUE ;
yield_statement : YIELD value=expression? ;

attribute
    : '@' obj=expression
    | '[' obj=expression ']'
    ;
    
definition_with_attr
    : attrs+=attribute* def=definition
    ;

definition
    : rtype=type name '(' values=type_name_list ')' body=generic_block # functionDefinition
    | rtype=type name '(' values=type_name_list ')' # emptyFunctionDefinition
    | type name '=' value=expression # initializedVariableDefinition
    | type name # variableDefinition
    | CLASS name (':' interhits+=type (',' inherits+=type)*)? '{' definitions+=definition_with_attr* '}' # classDefinition
    | STRUCT name (':' interhits+=type (',' inherits+=type)*)? '{' definitions+=definition_with_attr* '}' # structDefinition
    | FIXED key=name '{' values+=name* '}' # enumDefinition
    ;

expression
    : constant # constantExpression
    | obj=expression '~' dest=type # castExpression
    | obj=expression TILDE_TILDE dest=type # compareTypeExpression
    | token=('++'|'--') expr=expression # infixExpression
    | expr=expression token=('++'|'--') # postfixExpression
    | obj=expression '(' parameters=expression_list ')' # callExpression // Side effects
    | obj=expression '[' parameters=expression_list ']' # indexExpression
    | obj=expression '.' value=name # propertyExpression
    | left=expression op=binary right=expression # binaryExpression
    | op=unary left=expression # unaryExpression
    | left=expression op=comparison right=expression # comparisonExpression
    | left=expression op=logical right=expression # logicalExpression
    | condition=expression '?' left=expression ':' right=expression # ternaryExpression // Side effects
    | map # mapExpression
    | array # arrayExpression
    | name # variableExpression
    | left=expression ELIPSIS right=expression # rangeExpression 
    | ELIPSIS right=expression # endRangeExpression
    | '(' obj=expression ')' # parenthesizedExpression
    | inner=expression '::' # windExpression
    | inner=expression ';;' # filterExpression
    | left=expression '=' right=expression # assignmentExpression // Side effects
    // add += -= *= /= %= ^=
    | left=expression op=compoundAssignment right=expression # compoundAssignmentExpression // Side effects
    | '(' values=type_name_list ')' body=generic_block # lambdaExpression
    ;

expression_list
    : (expressions+=expression (',' expressions+=expression)*)?
    ;
    
compoundAssignment
    : PLUS_EQUALS # addCompound
    | MINUS_EQUALS # subtractCompound
    | ASTERISK_EQUALS # multiplyCompound
    | SLASH_EQUALS # divideCompound
    | ASTERISK_LSPACE EQUALS # multiplyCompound
    | CARET_EQUALS # powerCompound
    | PERCENT_EQUALS # modulusCompound
    ;

constant
    : INT # intConstant
    | STRING # stringConstant
    | CHAR # charConstant
    | TRUE # trueConstant
    | FALSE # falseConstant
    | NULL # nullConstant
    ;

unary
    : MINUS # negateUnary
    | BANG # notUnary
    ;

logical
    : AMPERSAND # andLogical
    | PIPE # orLogical
    ;

comparison
    : EQUALS_EQUALS # matchComparison
    | NOT_EQUALS # notMatchComparison
    | GREATER_THAN # greaterThanComparison
    | LESS_THAN # lessThanComparison
    | GREATER_THAN_EQUALS # greaterThanEqualsComparison
    | LESS_THAN_EQUALS # lessThanEqualsComparison
    ;

binary
    : PLUS # addBinary
    | MINUS # subtractBinary
    | (ASTERISK_LSPACE | ASTERISK_BSPACE | ASTERISK_NSPC) # multiplicationBinary
    | SLASH # divideBinary
    | CARET # powerBinary
    | PERCENT # modulusBinary
    ;

array : '[' expression_list ']' ;
map : '[' keys+=expression ':' values+=expression (',' keys+=expression ':' values+=expression)* ']' ;

// variables that end with * are lists
// variables that start with _ are private
// variables that start with :: are static
// variables that start with # are constants

// int* myarr = [1, 2, 3]

// :mystatic = f -> 5

modifier
    : '_' # privateModifier
//    | '::' # staticModifier
//    | '#' # constantModifier
    ;

type
    : key=type ':' value=type # mapType
    | element=type (ASTERISK_RSPACE | ASTERISK_NSPC) # listType
    | main=type '<' subs+=type (',' subs+=type)* '>' # genericType
    | main=ID ('.' parts+=ID)+ # propertyType
    | ID # namedType
    | LET # autoType
    ;

type_name_list
    : (types+=type names+=name (',' types+=type names+=name)*)?
    ;

name : modifiers+=modifier* ID ;