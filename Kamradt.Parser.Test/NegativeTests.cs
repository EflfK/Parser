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
    public class NegativeTests
    {
        [TestMethod]
        public void BasicNegativeTest()
        {
            StandardParser formula = new StandardParser("(7+6)+-4");
            decimal compare = (Convert.ToDecimal(7) + Convert.ToDecimal(6)) + Convert.ToDecimal(-4);
            decimal result = formula.Solve<decimal>(new StandardVariableCollection());
            Assert.AreEqual(compare, result);
        }
    }
}
