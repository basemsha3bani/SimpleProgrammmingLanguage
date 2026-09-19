using SimpleProgrammmingLanguage.GrammarChecking;
using SimpleProgrammmingLanguage.GrammarChecking.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammmingLanguage.Parsing.Implementation
{

    public class MathematicalExpressionParser : Parser
    {
        private int _pos;
       
        public Dictionary<string, int> SymbolTable { get; } = new();
        public List<string> Output { get; private set; } = new List<string>();

        public override bool Parse(string expression)
        {
            if (!base.CheckUnknownTokens(expression)) return false;

            _grammarHandler = new NumberAssignmentHandler();
            _grammarHandler.EvaluateExpression(_tokens);
            _pos = 0;

            try
            {
                // ROUTER — this is your new handlers chain
                if (_tokens[0].Type == TokensEnum.Print)
                    return ParsePrint();
                else if (_tokens[0].Type == TokensEnum.Integer)
                    return ParseVarDeclaration();
                else
                    return false;
            }
            catch { return false; }
        }

        private bool ParsePrint()
        {
            // print ( expr ) ;
            _pos = 1; // after print
            if (_tokens[_pos++].Type != TokensEnum.LParen) return false;
            int value = ParseExpression(); // reuses your existing logic!
            if (_tokens[_pos++].Type != TokensEnum.RParen) return false;
            if (_tokens[_pos].Type != TokensEnum.Semicolon) return false;

            Output.Add(value.ToString());
            return true;
        }

        private bool ParseVarDeclaration()
        {
            if (_tokens[_pos++].Type != TokensEnum.Integer) return false;
            var id = _tokens[_pos++];
            if (_tokens[_pos++].Type != TokensEnum.Assignment) return false;
            int value = ParseExpression();
            if (_tokens[_pos].Type != TokensEnum.Semicolon) return false;
            SymbolTable[id.Value] = value;
            return true;
        }

        private int ParseFactor()
        {
            var t = _tokens[_pos];
            if (t.Type == TokensEnum.Number) { _pos++; return int.Parse(t.Value); }
            if (t.Type == TokensEnum.Identifier) { _pos++; return SymbolTable[t.Value]; } // for x = id*3
            if (t.Type == TokensEnum.LParen) { _pos++; int v = ParseExpression(); _pos++; /* expect ) */ return v; }
            throw new Exception($"Unexpected {t.Type}");
        }
        private int ParseExpression() // handles + -
        {
            int val = ParseTerm();
            while (_pos < _tokens.Count && (_tokens[_pos].Type == TokensEnum.Plus || _tokens[_pos].Type == TokensEnum.Minus))
            {
                var op = _tokens[_pos++].Type;
                int right = ParseTerm();
                val = op == TokensEnum.Plus ? val + right : val - right;
            }
            return val;
        }

        private int ParseTerm() // handles * /
        {
            int val = ParseFactor();
            while (_pos < _tokens.Count && (_tokens[_pos].Type == TokensEnum.Multiply || _tokens[_pos].Type == TokensEnum.Divide))
            {
                var op = _tokens[_pos++].Type;
                int right = ParseFactor();
                val = op == TokensEnum.Multiply ? val * right : val / right;
            }
            return val;
        }
    }
    
}

