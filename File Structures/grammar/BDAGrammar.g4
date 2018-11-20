grammar BDAGrammar;


options {							
    language= CSharp2;
}


/*
 * Parser Rules
 */
query: 'SELECT' SEP ((ID | (ID ',')+) | '*' ) SEP 'FROM' SEP ID filter?;
filter: SEP 'WHERE' SEP OP (NUM | ID);

/*
 * Lexer Rules
 */
ID: ('a'..'z'|'A'..'Z')+;
NUM: ('0'..'9')+;
SEP:(' ' |'\t')+;
OP: '<' | '>' | '=' | 'NOT' | '!';
//END: 'END';