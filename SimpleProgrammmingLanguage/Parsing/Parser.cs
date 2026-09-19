using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammmingLanguage.Parsing
{
    using SimpleProgrammmingLanguage.GrammarChecking;
    using SimpleProgrammmingLanguage.GrammarChecking.Implementation;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;
    using System.Linq;
    using System.Text.RegularExpressions;

    
   
    public abstract class Parser
    {
        protected GrammarHandler _grammarHandler;
        protected Lexer lexer = new Lexer();


        public abstract bool Parse(string expression);

        protected bool CheckUnknownTokens(string expression)
        {
            bool NoUknwnTokens= lexer.CheckUnknownTokens(expression);
            _tokens = lexer.tokens;
            return NoUknwnTokens;
        }

        public List<Token> tokens
        {
            get
            {
                return _tokens;
            }
        }
        protected List<Token> _tokens;
    }

 







}
