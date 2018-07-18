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
    public abstract class BaseTreeFormula : FormulaControl
    {
        #region Events
        public delegate void EnsureStartingFieldEventHandler(object sender, EventArgs e);

        public event EnsureStartingFieldEventHandler EnsureStartingField;
        #endregion

        private BaseTreeFormula BaseTreeFormulaParent
        {
            get
            {
                return this.MatchingParent<BaseTreeFormula>();
            }
        }

        #region Templates
        private ITemplate _HeaderTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate HeaderTemplate
        {
            get
            {
                if (this._HeaderTemplate == null && this.BaseTreeFormulaParent != null)
                    return BaseTreeFormulaParent.HeaderTemplate;

                return this._HeaderTemplate;
            }
            set
            {
                this._HeaderTemplate = value;
            }
        }

        private ITemplate _FormulaTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate FormulaTemplate
        {
            get
            {
                if (this._FormulaTemplate == null && this.BaseTreeFormulaParent != null)
                        return BaseTreeFormulaParent.FormulaTemplate;

                return this._FormulaTemplate;
            }
            set
            {
                this._FormulaTemplate = value;
            }
        }

        private ITemplate _SubFormulaTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate SubFormulaTemplate
        {
            get
            {
                if (this._SubFormulaTemplate == null && this.BaseTreeFormulaParent != null)
                    return BaseTreeFormulaParent.SubFormulaTemplate;

                return this._SubFormulaTemplate;
            }
            set
            {
                this._SubFormulaTemplate = value;
            }
        }

        private ITemplate _MissingFormulaTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate MissingFormulaTemplate
        {
            get
            {
                if (this._MissingFormulaTemplate == null && this.BaseTreeFormulaParent != null)
                    return BaseTreeFormulaParent.MissingFormulaTemplate;

                return this._MissingFormulaTemplate;
            }
            set
            {
                this._MissingFormulaTemplate = value;
            }
        }

        private ITemplate _FooterTemplate;
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate FooterTemplate
        {
            get
            {
                if (this._FooterTemplate == null && this.BaseTreeFormulaParent != null)
                    return BaseTreeFormulaParent.FooterTemplate;

                return this._FooterTemplate;
            }
            set
            {
                this._FooterTemplate = value;
            }
        }
        #endregion

        private string _StartingField;
        public string StartingField
        {
            get
            {
                if (this.EnsureStartingField != null)
                    this.EnsureStartingField(this, EventArgs.Empty);

                return this._StartingField;
            }
            set
            {
                this._StartingField = value;
            }
        }
    }
}
