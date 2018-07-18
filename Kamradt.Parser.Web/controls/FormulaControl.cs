using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Kamradt.Parser.Web.controls
{
    public class FormulaControl : WebControl, INamingContainer, IDataItemContainer, IFormulaControl
    {
        public virtual object DataItem { get; set; }
        public int DataItemIndex { get; set; }
        public int DisplayIndex { get; set; }

        protected t5 MatchingParent<t5>()
            where t5: FormulaControl
        {
            Control searchControl = this;
            while (searchControl != null && searchControl != this.Page)
            {
                searchControl = searchControl.NamingContainer;

                if (searchControl is t5)
                    return searchControl as t5;
            }
            return default(t5);
        }

        public override ControlCollection Controls
        {
            get
            {
                this.EnsureChildControls();
                return base.Controls;
            }
        }

        public override void DataBind()
        {
            this.OnDataBinding(EventArgs.Empty);
            this.EnsureChildControls();
            this.DataBindChildren();
        }

        protected void GenerateFromTemplate(Control Parent, ITemplate Template, object DataItem)
        {
            FormulaContainer container = new FormulaContainer();
            container.DataItem = DataItem;
            Parent.Controls.Add(container);
            Template.InstantiateIn(container);
        }
    }
}
