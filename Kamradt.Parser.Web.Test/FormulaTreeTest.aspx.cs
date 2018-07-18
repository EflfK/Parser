using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kamradt.Parser.Web.controls;

namespace Kamradt.Parser.Web.Test
{
    public partial class FormulaTreeTest : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            TestStandardTree.EnsureFieldDictionary += TestStandardTree_EnsureFieldDictionary;
        }

        private void TestStandardTree_EnsureFieldDictionary(object sender, TreeEventArgs e)
        {
            e.FieldFormulaDictionary = new Dictionary<string, string>()
            {
                {"a", "b+c"},
                {"b", "q/7"},
                {"c", "5+4"},
                {"q", "10-z"},
                {"z", "2"}
            };
        }
    }
}