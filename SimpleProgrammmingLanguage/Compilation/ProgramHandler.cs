using SimpleProgrammmingLanguage.Parsing.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammmingLanguage.Compilation
{
    public class ProgramHandler
    {
        MathematicalExpressionParser _exprHandler = new();
        public Dictionary<string, int> SymbolTable => _exprHandler.SymbolTable;
        public List<string> Output => _exprHandler.Output;

        public bool Interpret(string program)
        {
            Lexer lexer = new Lexer();
             

            lexer.CheckUnknownTokens(program);
            List<Token> allTokens = lexer.tokens;
            int start;
            start = 0;
           

            while (start < allTokens.Count)
            {
                // 2. Find next semicolon
                int end = allTokens.FindIndex(start, t => t.Type == TokensEnum.Semicolon);
                if (end == -1) break;

                var stmtTokens = allTokens.GetRange(start, end - start + 1); // include ;
                string statement = string.Join(" ", stmtTokens.Select(s => s.Value)).Trim();
                // 3. Reuse your existing logic
                if (!_exprHandler.Parse(statement))
                    return false; // fail fast

                start = end + 1;
            }
            return true;
        }




    }
    
}
   
