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
    public class MathTests
    {
        [TestMethod]
        public void TestBasicMath()
        {
            StandardParser formula = new StandardParser("(7+6)+4");
            decimal compare = (Convert.ToDecimal(7) + Convert.ToDecimal(6)) + Convert.ToDecimal(4);
            decimal result = formula.Solve<decimal>(new StandardVariableCollection());
            Assert.AreEqual(compare, result);
        }

        [TestMethod]
        public void DoubleSubtractionTest()
        {
            StandardParser formula = new StandardParser("10-0-200");
            decimal compare = Convert.ToDecimal(10) - Convert.ToDecimal(0) - Convert.ToDecimal(200);
            decimal result = formula.Solve<decimal>(new StandardVariableCollection());
            Assert.AreEqual(compare, result);
        }
    }
}
