using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using Kamradt.Parser;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;
using Kamradt.Parser.Delimiters;
using Kamradt.Parser.Values;
using Kamradt.Parser.Functions;

namespace Kamradt.Parser.Web.controls
{
    public abstract class FormattedFormula<t1, t2, t3, t4> : BaseFormattedFormula, INamingContainer
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
        where t4 : Parser<t1, t2, t3>
    {
        public FormattedFormula() { }

        #region Events
        public delegate void FormattedFormulaEventHandler(object sender, EventArgs e);

        public event FormattedFormulaEventHandler PreControlsCreated;
        #endregion

        protected virtual ITemplate AdditionalTemplateLookup(Type TreeLeafType)
        {
            return null;
        }

        internal override ITemplate TemplateLookup(Type TreeLeafType)
        {
            if (TreeLeafType.Equals(typeof(And<t1, t2, t3>)))
                return this.AndTemplate;

            if (TreeLeafType.Equals(typeof(If<t1, t2, t3>)))
                return this.IfTemplate;

            if (TreeLeafType.Equals(typeof(Divide<t1, t2, t3>)))
                return this.DivideTemplate;

            if (TreeLeafType.Equals(typeof(Equals<t1, t2, t3>)))
                return this.EqualsTemplate;

            if (TreeLeafType.Equals(typeof(GreaterThan<t1, t2, t3>)))
                return this.GreaterThanTemplate;

            if (TreeLeafType.Equals(typeof(GreaterThanOrEqual<t1, t2, t3>)))
                return this.GreaterThanOrEqualTemplate;

            if (TreeLeafType.Equals(typeof(LessThan<t1, t2, t3>)))
                return this.LessThanTemplate;

            if (TreeLeafType.Equals(typeof(LessThanOrEqual<t1, t2, t3>)))
                return this.LessThanOrEqualTemplate;

            if (TreeLeafType.Equals(typeof(Minus<t1, t2, t3>)))
                return this.MinusTemplate;

            if (TreeLeafType.Equals(typeof(Multiply<t1, t2, t3>)))
                return this.MultiplyTemplate;

            if (TreeLeafType.Equals(typeof(NotEqual<t1, t2, t3>)))
                return this.NotEqualTemplate;

            if (TreeLeafType.Equals(typeof(Or<t1, t2, t3>)))
                return this.OrTemplate;

            if (TreeLeafType.Equals(typeof(Plus<t1, t2, t3>)))
                return this.PlusTemplate;

            if (TreeLeafType.Equals(typeof(Power<t1, t2, t3>)))
                return this.PowerTemplate;

            if (TreeLeafType.Equals(typeof(IfNull<t1, t2, t3>)))
                return this.IfNullTemplate;

            if (TreeLeafType.Equals(typeof(In<t1, t2, t3>)))
                return this.InTemplate;

            if (TreeLeafType.Equals(typeof(Len<t1, t2, t3>)))
                return this.LenTemplate;

            if (TreeLeafType.Equals(typeof(Substring<t1, t2, t3>)))
                return this.SubstringTemplate;

            ITemplate template = this.AdditionalTemplateLookup(TreeLeafType);
            if (template != null)
                return template;

            return null;
        }

        private t4 _FormulaParser;
        protected t4 FormulaParser {
            get
            {
                return this._FormulaParser;
            }
            set
            {
                this._FormulaParser = value;
                this.CreateChildControls();
            }
        }

        private string _Formula = "";
        public override string Formula
        {
            get
            {
                return this._Formula;
            }
            set
            {
                if (this._Formula != value)
                {
                    this._Formula = value;
                    this.FormulaParser = this.CreateParser(value);
                }
            }
        }

        public string DataBindFormulaPath { get; set; }

        public override object DataItem
        {
            get
            {
                return base.DataItem;
            }
            set
            {
                base.DataItem = value;
                if (value != null && !String.IsNullOrEmpty(this.DataBindFormulaPath))
                    this.Formula = DataBinder.Eval(value, this.DataBindFormulaPath).ToString();
            }
        }

        protected abstract t4 CreateParser(string Formula);

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

        private void GenerateControl(Control Parent, ILeaf<t1, t2, t3> TreeLeaf)
        {
            if (TreeLeaf is EndLeaf<t1, t2, t3>)
            {
                this.GenerateEndLeafControl(Parent, TreeLeaf as EndLeaf<t1, t2, t3>);
            }
            else
            {
                ITemplate template = this.TemplateLookup(TreeLeaf.GetType());

                if (template == null)
                    Parent.Controls.Add(new Label() { Text = TreeLeaf.Formula });
                else
                    this.GenerateFromTemplate(Parent, template, TreeLeaf);
            }
        }

        private void GenerateEndLeafControl(Control Parent, EndLeaf<t1, t2, t3> TreeLeaf)
        {
            ITemplate template = TreeLeaf.Value.GetType().Equals(typeof(StaticValue<t1, t2>)) ? this.StaticValueTemplate : this.IsVariable(TreeLeaf.Formula) ? this.VariableTemplate : this.NonVariableTemplate;

            if (template == null)
                Parent.Controls.Add(new Label() { Text = TreeLeaf.Formula });
            else
                this.GenerateFromTemplate(Parent, template, TreeLeaf.Value);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (String.IsNullOrEmpty(this.Formula) && (String.IsNullOrEmpty(this.DataBindFormulaPath) || this.DataItem == null))
                throw new Exception("Dataitem and BindPath or Formula must be set.");

            this.Controls.Clear();

            if (this.PreControlsCreated != null)
                this.PreControlsCreated(this, EventArgs.Empty);

            this.GenerateControl(this, this.FormulaParser.RootLeaf);
            this.DataBind();
        }
    }
}