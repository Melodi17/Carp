grammar CarpGrammar;

options {
    contextSuperClass = Carp.interpreter.Context;
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
LEFT_SHIFT : '<<' ;
RIGHT_SHIFT : '>>' ;
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

IMPORT : 'import ' .*? ([\n] | EOF);
ID : [a-zA-Z][a-zA-Z0-9_]* ;
//STRING : '\'' (~['\\])* '\'' ;
INT : ( [0-9]+ | [0-9]+ '.' [0-9]+ | '.' [0-9]+ ) ;
WS : [ \t\r\n]+ -> skip ;
DOCSTRING : '#:' .*? ([\n] | EOF) ;
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
    : IMPORT # importStatement
    | wrapped_definition # definitionStatement
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
    : TRY try_block=generic_block (CATCH '(' catch_types+=type catch_names+=ID ')' catch_blocks+=generic_block)* (FINALLY finally_block=generic_block)?
    | TRY try_block=generic_block (CATCH catch_types+=type catch_names+=ID catch_blocks+=generic_block)* (FINALLY finally_block=generic_block)?
    ;

iter_statement
    : ITER iter=expression body=generic_block # iterStatement
    | ITER type ID ':'  iter=expression body=generic_block # iterAsStatement
    | ITER '(' type ID ':'  iter=expression ')' body=generic_block # iterAsStatement
    | ITER type_name_list ':'  iter=expression body=generic_block # iterAsUnpackedStatement
    | ITER '(' type_name_list ':'  iter=expression ')' body=generic_block # iterAsUnpackedStatement
    ;

return_statement : RETURN value=expression? ;
break_statement : BREAK ;
continue_statement : CONTINUE ;
yield_statement : YIELD value=expression? ;

attribute
    : '@' obj=expression
    | '[' obj=expression ']'
    ;
    
wrapped_definition
    : docs+=DOCSTRING* attrs+=attribute* modifiers+=modifier* def=definition
    ;

definition
    : rtype=type key=ID '(' values=type_name_list ')' body=generic_block? # functionDefinition
    | rtype=type key=ID ('=' value=expression)? # variableDefinition
    | CLASS key=ID (':' inherits+=type (',' inherits+=type)*)? '{' definitions+=wrapped_definition* '}' # classDefinition
    | STRUCT key=ID (':' inherits+=type (',' inherits+=type)*)? '{' definitions+=wrapped_definition* '}' # structDefinition
    | FIXED key=ID '{' (keys+=ID ':' value+=expression (',' keys+=ID ':' value+=expression)*)? '}' # enumDefinition
    | FIXED key=ID '{' (keys+=ID (',' keys+=ID)*)? '}' # enumDefinitionAutoValues
    ;

expression
    : constant # constantExpression
    | obj=expression op=(TILDE_TILDE|'~>') dest=type # compareTypeExpression
    | token=('++'|'--') expr=expression # infixExpression
    | expr=expression token=('++'|'--') # postfixExpression
    | obj=expression '(' parameters=expression_list ')' # callExpression // Side effects
    | obj=expression '[' parameters=expression_list ']' # indexExpression
    | obj=expression '.' member=ID '.' op=meta # metaMemberExpression
    | member=ID '.' op=meta # metaObjExpression
    | obj=expression '.' path=ID # propertyExpression
    | op=unary left=expression # unaryExpression
    | left=expression op=binary_geometric right=expression # binaryGeometricExpression // Geometric
    | left=expression op=binary_arithmatic right=expression # binaryArithmaticExpression // Arithmatic
    | left=expression op=binary_bitwise_shift right=expression # binaryBitwiseShiftExpression // Bitwise shifts
    | left=expression op=comparison_compare right=expression # comparisonCompareExpression // Comparing
    | left=expression op=comparison_match right=expression # comparisonMatchExpression // Matching
    | left=expression op=logical right=expression # logicalExpression
    | condition=expression '?' left=expression ':' right=expression # ternaryExpression // Side effects
    | map # mapExpression
    | array # arrayExpression
    | ID # variableExpression
    | left=expression ELIPSIS right=expression # rangeExpression 
    | ELIPSIS right=expression # endRangeExpression
    | '(' obj=expression ')' # parenthesizedExpression
    | inner=expression '::' # windExpression
    | inner=expression ':~' dest=type # windCastExpression
    | inner=expression ';;' # filterExpression
    | obj=expression '~' dest=type # castExpression
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

comparison_compare
    : GREATER_THAN # greaterThanComparison
    | LESS_THAN # lessThanComparison
    | GREATER_THAN_EQUALS # greaterThanEqualsComparison
    | LESS_THAN_EQUALS # lessThanEqualsComparison
    ;
    
comparison_match
    : EQUALS_EQUALS # matchComparison
    | NOT_EQUALS # notMatchComparison
    ;

binary_geometric
    : (ASTERISK_LSPACE | ASTERISK_BSPACE | ASTERISK_NSPC) # multiplicationBinary
    | SLASH # divideBinary
    | CARET # powerBinary
    | PERCENT # modulusBinary
    ;
    
binary_arithmatic
    : PLUS # addBinary
    | MINUS # subtractBinary
    ;
    
binary_bitwise_shift
    : LEFT_SHIFT # leftShiftBinary
    | RIGHT_SHIFT # rightShiftBinary
    ;
    
meta
    : 'doc' # docMeta
    | 'annotations' # annotationsMeta
    ;

array : '[' expression_list ']' ;
map : '[' keys+=expression ':' values+=expression (',' keys+=expression ':' values+=expression)* ']' ;

modifier
    : 'private' # privateModifier
    | 'static' # staticModifier
    | 'protected' # protectedModifier
    | 'abstract' # abstractModifier
    | 'final' # finalModifier
    ;

type
    : key=type ':' value=type # mapType
    | element=type (ASTERISK_RSPACE | ASTERISK_NSPC) # listType
    //| element=type '?' # nullableType
    | main=type '<' subs+=type (',' subs+=type)* '>' # genericType
    | main=ID ('.' parts+=ID)+ # propertyType
    | ID # namedType
    | LET # autoType
    ;

type_name_list
    : (types+=type names+=ID (',' types+=type names+=ID)*)?
    ;