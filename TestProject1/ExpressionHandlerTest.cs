using SimpleProgrammmingLanguage.Parsing.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class ExpressionHandlerTest
    {
        [TestMethod]
        public void TestExpressionHandler()
        {
            string expression = "int id=1+1;";
           
            var exprHandler = new MathematicalExpressionParser();
           
         
           var evaluation= exprHandler.Parse(expression);
            Assert.AreEqual(2, exprHandler.SymbolTable["id"]);
        }
    }
}
