using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kamradt.Parser.Variables;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.ComponentModel;

namespace Kamradt.Parser.Web.controls
{
    [ParseChildren(true), PersistChildren(false), Bindable(false)]
    public class StandardFormattedFormula : FormattedFormula<StandardVariableCollection, StandardVariableCollectionKey, StandardRequiredVariables, StandardParser>
    {
        public StandardFormattedFormula() { }

        protected override StandardParser CreateParser(string Formula)
        {
            return new StandardParser(Formula) { };
        }

        protected override bool IsVariable(string Field)
        {
            return true;
        }
    }
}