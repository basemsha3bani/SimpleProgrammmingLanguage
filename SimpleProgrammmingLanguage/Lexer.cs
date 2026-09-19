using SimpleProgrammmingLanguage;
using SimpleProgrammmingLanguage.Parsing;
using System;
using System.Collections.Generic;


namespace SimpleProgrammmingLanguage
{

    public partial class Lexer
    {
        private List<Token> _tokens;
        public List<Token> tokens { get
            {
                return _tokens;
            }
        }
        private void Analyze(string s)
        {
            List<Token> result = new List<Token>();
            int i = 0;

            while (i < s.Length)
            {
                char c = s[i];

                // 1. Skip whitespace
                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }
                
                string remaining = s.Substring(i);

                // 2. Numbers: ^[0-9]+
                if (Matcher.MatchNumber(remaining, out string numVal))
                {
                    result.Add(new Token { Type = TokensEnum.Number, Value = numVal });
                    i += numVal.Length;
                    continue;
                }
                if (remaining.StartsWith("print"))
                {
                    result.Add(new Token { Type = TokensEnum.Print, Value = "print" });
                    i += "print".Length;
                    continue;
                }
                // 3. Identifiers + Keywords: ^_?[a-zA-Z][a-zA-Z0-9]*
                if (Matcher.MatchIdentifier(remaining, out string idVal))
                {
                    TokensEnum type = idVal == "int" ? TokensEnum.Integer : TokensEnum.Identifier;
                    result.Add(new Token { Type = type, Value = idVal });
                    i += idVal.Length;
                    continue;
                }
                
                // 4. Single character tokens
                switch (c)
                {
                    case '=':
                        result.Add(new Token { Type = TokensEnum.Assignment, Value = "=" });
                        i++;
                        break;
                    case ';':
                        result.Add(new Token { Type = TokensEnum.Semicolon, Value = ";" });
                        i++;
                        break;
                    case '+':
                        result.Add(new Token { Type = TokensEnum.Plus, Value = "+" });
                        i++;
                        break;
                    case '-':
                        result.Add(new Token { Type = TokensEnum.Minus, Value = "-" });
                        i++;
                        break;
                    case '*':
                        result.Add(new Token { Type = TokensEnum.Multiply, Value = "*" });
                        i++;
                        break;
                    case '/':
                        result.Add(new Token { Type = TokensEnum.Divide, Value = "/" });
                        i++;
                        break;
                    case '(':
                        result.Add(new Token { Type = TokensEnum.LParen, Value = "(" });
                        i++;
                        break;
                    case ')':
                        result.Add(new Token { Type = TokensEnum.RParen, Value = ")" });
                        i++;
                        break;
                   

                    default:
                        result.Add(new Token { Type = TokensEnum.Unknown, Value = c.ToString() });
                        i++;
                        break;

                }
            }
            _tokens = result;
        }
        public bool  CheckUnknownTokens(string expression)
        {

            this.Analyze(expression);
            bool hasUnknown = _tokens.Any(a => a.Type == TokensEnum.Unknown);
            if (hasUnknown)
                Console.WriteLine("LexerHandler: Failed - Found Unknown token");
            return !hasUnknown;
        }
    }
   
    }

