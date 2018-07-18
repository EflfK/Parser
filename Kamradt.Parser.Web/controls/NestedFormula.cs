using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Kamradt.Parser.Web.controls
{
    public class NestedFormula : WebControl, IDataItemContainer
    {
        public string FormulaLookup { get; set; }
        public string Formula
        {
            get
            {
                return DataBinder.Eval(this.DataItem, this.FormulaLookup).ToString();
            }
        }

        internal void AddFormulaControl(BaseFormattedFormula BaseFormula)
        {
            BaseFormattedFormula formattedFormula = (BaseFormattedFormula)BaseFormula.CreateDuplicate(this.Formula);
            this.Controls.Add(formattedFormula);
        }

        public object DataItem { get; set; }
        public int DataItemIndex { get; set; }
        public int DisplayIndex { get; set; }
    }
}
