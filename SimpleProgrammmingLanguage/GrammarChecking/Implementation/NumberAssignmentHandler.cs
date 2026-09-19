namespace SimpleProgrammmingLanguage.GrammarChecking.Implementation
{
    public class NumberAssignmentHandler : GrammarHandler
    {
       

        public override bool EvaluateExpression(List<Token> tokens)
        {
            bool isValid = false;
           
           
            if (tokens.Count != 5)
            {
                Console.WriteLine($"GrammarHandler: Failed - Expected 5 tokens, got {tokens.Count}");
                return isValid;
            }

            isValid = tokens[0].Type == TokensEnum.Integer &&
                           tokens[1].Type == TokensEnum.Identifier &&
                           tokens[2].Type == TokensEnum.Assignment &&
                           tokens[3].Type == TokensEnum.Number &&
                           tokens[4].Type == TokensEnum.Semicolon;

            if (!isValid)
                Console.WriteLine("GrammarHandler: Failed - Token pattern doesn't match 'int id = num ;'");

            return isValid;
        }
    }
}
