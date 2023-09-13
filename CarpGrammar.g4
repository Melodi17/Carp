grammar CarpGrammar;

options {
    contextSuperClass = Carp.interpreter.ScopedParserRuleContext;   
}

ELIPSIS : '..'  ;
INDENT : ';' ;
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

BANG : '!' ;
PLUS_EQUALS : '+=' ;
MINUS_EQUALS : '-=' ;
ASTERISK_EQUALS : '*=' ;
SLASH_EQUALS : '/=' ;
CARET_EQUALS : '^=' ;
PLUS_PLUS : '++' ;
MINUS_MINUS : '--' ;
PLUS : '+' ;
MINUS : '-' ;
SLASH : '/' ;
ASTERISK_BSPACE : ' * ' ;
ASTERISK_LSPACE : ' *' ;
ASTERISK_RSPACE : '* ' ;
ASTERISK_NSPC : '*' ;
BACKSLASH : '\\' ;

CARET : '^' ;
QUESTION_MARK : '?' ;
UNDERSCORE : '_' ;
COLON : ':' ;
COLON_COLON : '::' ;
ARROW : '->' ;
WIND : '%' ;
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

ID : [a-zA-Z][a-zA-Z0-9_]* ;
STRING : '\'' (~['\\])* '\'' ;
INT : '-'? ( [0-9]+ | [0-9]+ '.' [0-9]+ | '.' [0-9]+ ) ;
WS : [ \t\r\n]+ -> skip ;
COMMENT : '#' .*? [\n] -> skip ;

program : block EOF ;

block : (INDENT* statements+=statement)* ;

generic_block
    : '{' block '}' # enclosedBlock
    | '->' expression # lambdaExpressionBlock
    | '->' statement # lambdaBlock
    ;

statement
    : definition # definitionStatement
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

definition
    : type name '=' value=expression # initializedVariableDefinition
    | type name # variableDefinition
    | rtype=type name '(' values=type_name_list ')' body=generic_block # functionDefinition
    | rtype=type name '(' values=type_name_list ')' # emptyFunctionDefinition
    | CLASS name '{' definitions+=definition* '}' # classDefinition
    | STRUCT name '{' definitions+=definition* '}' # structDefinition
    ;

expression
    : constant # constantExpression
    | token=('++'|'--') expr=expression # infixExpression
    | expr=expression token=('++'|'--') # postfixExpression
    | obj=expression '.' value=name # propertyExpression
    | left=expression op=binary right=expression # binaryExpression
    | op=unary left=expression # unaryExpression
    | left=expression op=comparison right=expression # comparisonExpression
    | left=expression op=logical right=expression # logicalExpression
    | condition=expression '?' left=expression ':' right=expression # ternaryExpression
    | map # mapExpression
    | array # arrayExpression
    | name # variableExpression
//    | expression '%' # windExpression
    | left=expression ELIPSIS right=expression # rangeExpression 
    | ELIPSIS right=expression # endRangeExpression
    | obj=expression '(' parameters=expression_list ')' # callExpression
    | obj=expression '[' parameters=expression_list ']' # indexExpression
    | '(' obj=expression ')' # parenthesizedExpression
    | left=expression '=' right=expression # assignmentExpression
    // add += -= *= /= %= ^=
    | left=expression op=compoundAssignment right=expression # compoundAssignmentExpression
    ;

expression_list
    : (expressions+=expression (',' expressions+=expression)*)?
    ;
    
compoundAssignment
    : PLUS_EQUALS # addCompound
    | MINUS_EQUALS # subtractCompound
    | ASTERISK_EQUALS # multiplyCompound
    | SLASH_EQUALS # divideCompound
    | CARET_EQUALS # powerCompound
    ;

constant
    : INT # intConstant
    | STRING # stringConstant
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
    | element=type ASTERISK_RSPACE # listType
    | ID # namedType
    | LET # autoType
    ;

type_name_list
    : (types+=type names+=name (',' types+=type names+=name)*)?
    ;

name : modifiers+=modifier* ID ;