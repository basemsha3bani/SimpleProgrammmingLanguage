using System.Text.RegularExpressions;


namespace SimpleProgrammmingLanguage
{
    public partial class Lexer
    {
        internal static class Matcher
        {
            // Matches from the beginning of the string ^
            internal static bool MatchNumber(string s, out string value)
            {
                Match m = Regex.Match(s, @"^[0-9]+");
                value = m.Success ? m.Value : "";
                return m.Success;
            }

            internal static bool MatchIdentifier(string s, out string value)
            {
                Match m = Regex.Match(s, @"^_?[a-zA-Z][a-zA-Z0-9]*");
                value = m.Success ? m.Value : "";
                return m.Success;
            }
            
        }
    }
}


