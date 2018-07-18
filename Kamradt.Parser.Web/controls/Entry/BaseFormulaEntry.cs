using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Collections;
using System.Drawing.Design;

namespace Kamradt.Parser.Web.controls
{
    public class BaseFormulaEntry : FormulaControl
    {
        [DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty)]
        public NodeTypeCollection Nodes { get; set; }
    }
}