using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kamradt.Parser.Web.Test
{
    public partial class FormulaParserTest : System.Web.UI.Page
    {
        protected string Stuff(string VariableName)
        {

            if (VariableName == "firstVariable")
                return "yes";
            else return "no";
        }
    }
}