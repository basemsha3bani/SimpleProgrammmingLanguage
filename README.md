# Mini-C# Interpreter — Facade + Chain of Responsibility

Supports:
int id=1+1;
print(id*3); // -> 6


Architecture: ProgramHandler (Facade L2) -> MathematicalExpressionParser (Facade L1) -> CoR Handlers
- Lexer: tokenizes int, print, if, { } ( ) ; + - * / > < ==
- Parser: hides lexer, SymbolTable + Output, routes to handlers

- TDD: MSTest

