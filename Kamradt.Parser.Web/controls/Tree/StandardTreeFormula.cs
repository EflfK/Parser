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
    public class TreeEventArgs : EventArgs
    {
        public Dictionary<string, string> FieldFormulaDictionary
        {
            get
            {
                return Tree.FieldDictionary;
            }
            set
            {
                this.Tree.FieldDictionary = value;
            }
        }

        private StandardTreeFormula Tree { get; set; }
        
        public TreeEventArgs(StandardTreeFormula Tree)
        {
            this.Tree = Tree;
        }
    }

    [ParseChildren(true), PersistChildren(false), Bindable(false)]
    public class StandardTreeFormula : TreeFormula<StandardVariableCollection, StandardVariableCollectionKey, StandardRequiredVariables, StandardParser>
    {
        private StandardTreeFormula StandardTreeFormulaParent
        {
            get
            {
                return this.MatchingParent<StandardTreeFormula>();
            }
        }

        public Dictionary<string, string> FieldFormulaDictionary { get; set; }

        #region Events
        public delegate void FormattedFormulaEventHandler(object sender, TreeEventArgs e);

        public event FormattedFormulaEventHandler EnsureFieldDictionary;
        #endregion

        protected override StandardParser CreateParser(string Field)
        {
            return new StandardParser(this.FieldDictionary[Field]) { };
        }

        protected override KeyValuePair<string, StandardParser> CreateParser(StandardVariableCollectionKey Key)
        {
            return  new KeyValuePair<string,StandardParser>(Key.Key, CreateParser(Key.Key));
        }

        private Dictionary<string, string> _FieldDictionary;
        public Dictionary<string, string> FieldDictionary
        {
            get
            {
                if (this.EnsureFieldDictionary != null)
                    this.EnsureFieldDictionary(this, new TreeEventArgs(this));

                if (this._FieldDictionary == null && this.StandardTreeFormulaParent != null)
                    return this.StandardTreeFormulaParent.FieldDictionary;

                return this._FieldDictionary;
            }
            set
            {
                this._FieldDictionary = value;
            }
        }
    }
}
