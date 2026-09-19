using SimpleProgrammmingLanguage.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{

    [TestClass]
    public class ProgramHandlerTest
    {
        [TestMethod]
        public void TestProgram()
        {
            string program = "int id=1+1;print (id*3);";
            var prog = new ProgramHandler();

            bool ok = prog.Interpret(program);

            Assert.IsTrue(ok);
            Assert.AreEqual(2, prog.SymbolTable["id"]);
            Assert.AreEqual("6", prog.Output[0]); // id*3
        }
    }
}
