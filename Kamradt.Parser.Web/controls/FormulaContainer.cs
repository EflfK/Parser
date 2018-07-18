using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Kamradt.Parser.Web.controls
{
    public class FormulaContainer : WebControl, IFormulaControl, IDataItemContainer, INamingContainer
    {
        public object DataItem { get; set; }
        public int DataItemIndex { get; set; }
        public int DisplayIndex { get; set; }

        protected override void AddedControl(Control control, int index)
        {
            base.AddedControl(control, index);

            if (control is IFormulaControl)
                (control as IFormulaControl).DataItem = this.DataItem;
        }
    }
}