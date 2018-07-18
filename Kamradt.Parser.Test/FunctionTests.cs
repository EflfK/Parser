using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kamradt.Parser;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Test
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void IfTest()
        {
            StandardParser formula = new StandardParser("if(7==8,0,1)");
            decimal result = formula.Solve<decimal>(new StandardVariableCollection());
            Assert.AreEqual(result, Convert.ToDecimal(1));
        }
    }
}
