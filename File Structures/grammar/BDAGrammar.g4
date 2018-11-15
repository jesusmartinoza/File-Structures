grammar BDAGrammar;


options {							
    language= CSharp2;
}


/*
 * Parser Rules
 */
query: 'SELECT' SEP (ATTRS | '*' ) SEP 'FROM' SEP ID SEP OP;

/*
 * Lexer Rules
 */
ATTRS: ID | (ID ',')+;
ID: ('a'..'z'|'A'..'Z')+;
SEP:(' ' |'\t')+;
OP: '<' | '>' | '=' | 'NOT' | '!';
//END: 'END';