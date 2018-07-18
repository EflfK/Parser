using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using Kamradt.Parser.Trees;
using System.ComponentModel;

namespace Kamradt.Parser.Web.controls
{
    public abstract class BaseFormattedFormula : FormulaControl
    {
        private BaseFormattedFormula BaseFormattedFormulaParent
        {
            get
            {
                return this.MatchingParent<BaseFormattedFormula>();
            }
        }

        #region Templates
        private ITemplate _StaticValueTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate StaticValueTemplate
        {
            get
            {
                if (this._StaticValueTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.StaticValueTemplate;

                return this._StaticValueTemplate;
            }
            set
            {
                this._StaticValueTemplate = value;
            }
        }

        private ITemplate _VariableTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate VariableTemplate
        {
            get
            {
                if (this._VariableTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.VariableTemplate;

                return this._VariableTemplate;
            }
            set
            {
                this._VariableTemplate = value;
            }
        }

        private ITemplate _NonVariableTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate NonVariableTemplate
        {
            get
            {
                if (this._NonVariableTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.NonVariableTemplate;

                return this._NonVariableTemplate;
            }
            set
            {
                this._NonVariableTemplate = value;
            }
        }

        private ITemplate _AndTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate AndTemplate
        {
            get
            {
                if (this._AndTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.AndTemplate;

                return this._AndTemplate;
            }
            set
            {
                this._AndTemplate = value;
            }
        }

        private ITemplate _IfTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate IfTemplate
        {
            get
            {
                if (this._IfTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.IfTemplate;

                return this._IfTemplate;
            }
            set
            {
                this._IfTemplate = value;
            }
        }

        private ITemplate _IfNullTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate IfNullTemplate
        {
            get
            {
                if (this._IfNullTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.IfNullTemplate;

                return this._IfNullTemplate;
            }
            set
            {
                this._IfNullTemplate = value;
            }
        }

        private ITemplate _InTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate InTemplate
        {
            get
            {
                if (this._InTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.InTemplate;

                return this._InTemplate;
            }
            set
            {
                this._InTemplate = value;
            }
        }

        private ITemplate _LenTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate LenTemplate
        {
            get
            {
                if (this._LenTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.LenTemplate;

                return this._LenTemplate;
            }
            set
            {
                this._LenTemplate = value;
            }
        }

        private ITemplate _SubstringTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate SubstringTemplate
        {
            get
            {
                if (this._SubstringTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.SubstringTemplate;

                return this._SubstringTemplate;
            }
            set
            {
                this._SubstringTemplate = value;
            }
        }

        private ITemplate _DivideTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate DivideTemplate
        {
            get
            {
                if (this._DivideTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.DivideTemplate;

                return this._DivideTemplate;
            }
            set
            {
                this._DivideTemplate = value;
            }
        }

        private ITemplate _EqualsTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate EqualsTemplate
        {
            get
            {
                if (this._EqualsTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.EqualsTemplate;

                return this._EqualsTemplate;
            }
            set
            {
                this._EqualsTemplate = value;
            }
        }

        private ITemplate _GreaterThanTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate GreaterThanTemplate
        {
            get
            {
                if (this._GreaterThanTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.GreaterThanTemplate;

                return this._GreaterThanTemplate;
            }
            set
            {
                this._GreaterThanTemplate = value;
            }
        }

        private ITemplate _GreaterThanOrEqualTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate GreaterThanOrEqualTemplate
        {
            get
            {
                if (this._GreaterThanOrEqualTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.GreaterThanOrEqualTemplate;

                return this._GreaterThanOrEqualTemplate;
            }
            set
            {
                this._GreaterThanOrEqualTemplate = value;
            }
        }

        private ITemplate _LessThanTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate LessThanTemplate
        {
            get
            {
                if (this._LessThanTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.LessThanTemplate;

                return this._LessThanTemplate;
            }
            set
            {
                this._LessThanTemplate = value;
            }
        }

        private ITemplate _LessThanOrEqualTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate LessThanOrEqualTemplate
        {
            get
            {
                if (this._LessThanOrEqualTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.LessThanOrEqualTemplate;

                return this._LessThanOrEqualTemplate;
            }
            set
            {
                this._LessThanOrEqualTemplate = value;
            }
        }

        private ITemplate _MinusTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate MinusTemplate
        {
            get
            {
                if (this._MinusTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.MinusTemplate;

                return this._MinusTemplate;
            }
            set
            {
                this._MinusTemplate = value;
            }
        }

        private ITemplate _MultiplyTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate MultiplyTemplate
        {
            get
            {
                if (this._MultiplyTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.MultiplyTemplate;

                return this._MultiplyTemplate;
            }
            set
            {
                this._MultiplyTemplate = value;
            }
        }

        private ITemplate _NotEqualTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate NotEqualTemplate
        {
            get
            {
                if (this._NotEqualTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.NotEqualTemplate;

                return this._NotEqualTemplate;
            }
            set
            {
                this._NotEqualTemplate = value;
            }
        }

        private ITemplate _OrTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate OrTemplate
        {
            get
            {
                if (this._OrTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.OrTemplate;

                return this._OrTemplate;
            }
            set
            {
                this._OrTemplate = value;
            }
        }

        private ITemplate _PlusTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate PlusTemplate
        {
            get
            {
                if (this._PlusTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.PlusTemplate;

                return this._PlusTemplate;
            }
            set
            {
                this._PlusTemplate = value;
            }
        }

        private ITemplate _PowerTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate PowerTemplate
        {
            get
            {
                if (this._PowerTemplate == null && this.BaseFormattedFormulaParent != null)
                    return this.BaseFormattedFormulaParent.PowerTemplate;

                return this._PowerTemplate;
            }
            set
            {
                this._PowerTemplate = value;
            }
        }
        #endregion

        public abstract string Formula { get; set; }
        internal abstract ITemplate TemplateLookup(Type TreeLeafType);

        protected abstract bool IsVariable(string Field);
    }
}
