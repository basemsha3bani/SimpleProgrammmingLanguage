namespace SimpleProgrammmingLanguage
{
    public class Token
    {
        public TokensEnum Type { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"[{Type}: '{Value}']";
        }
    }
}
// Test it
