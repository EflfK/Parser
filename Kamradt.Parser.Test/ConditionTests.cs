using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kamradt.Parser;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ConditionTests
    {
        [TestMethod]
        public void EqualsNullTest()
        {
            StandardParser formula = new StandardParser("a==null");
            decimal compare = Convert.ToDecimal(10) - Convert.ToDecimal(0) - Convert.ToDecimal(200);

            StandardVariableCollection vars = new StandardVariableCollection();
            vars.Add("a", null);

            Assert.IsTrue(formula.Solve<bool>(vars));
        }

        [TestMethod]
        public void ConditionNegativeTest()
        {
            StandardParser formula = new StandardParser("a<=-0.12");
            decimal compare = Convert.ToDecimal(10) - Convert.ToDecimal(0) - Convert.ToDecimal(200);

            StandardVariableCollection vars = new StandardVariableCollection();
            vars.Add("a", -111m);

            Assert.IsTrue(formula.Solve<bool>(vars));
        }
    }
}
