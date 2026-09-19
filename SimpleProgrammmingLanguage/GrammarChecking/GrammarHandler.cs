using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammmingLanguage.GrammarChecking
{
    public abstract class GrammarHandler
    {
      
        public abstract bool EvaluateExpression(List<Token> tokens);
       
    }
}
