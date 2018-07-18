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
    public class VariableTests
    {
        [TestMethod]
        public void TestVariable()
        {
            StandardParser parser = new StandardParser("so91");
            decimal val = 453.444m;
            StandardVariableCollection vars = new StandardVariableCollection();
            vars.Add("so91", val);

            Assert.AreEqual(val, parser.Solve<decimal>(vars));
        }

        [TestMethod]
        public void TestMissingVariable()
        {
            StandardParser parser = new StandardParser("so91>so92");
            parser.OnSolveError += parser_OnSolveError;
            decimal val = 453.444m;
            StandardVariableCollection vars = new StandardVariableCollection();
            vars.Add("so91", val);
            vars.Add("so92", "'a'");

            Assert.AreEqual(val, parser.Solve<decimal>(vars));
        }

        private void parser_OnSolveError(object sender, Exceptions.FormulaExceptionEventArgs<StandardVariableCollection, StandardVariableCollectionKey, StandardRequiredVariables> e)
        {
            var a = "";
        }
    }
}
