using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using Kamradt.Parser;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;
using Kamradt.Parser.Delimiters;
using Kamradt.Parser.Values;
using Kamradt.Parser.Functions;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Kamradt.Parser.Web.controls
{
    public abstract class TreeFormula<t1, t2, t3, t4> : BaseTreeFormula, INamingContainer
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
        where t4 : Parser<t1, t2, t3>
    {

        protected abstract t4 CreateParser(string Field);
        protected abstract KeyValuePair<string, t4> CreateParser(t2 Key);

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            if (!String.IsNullOrEmpty(this.StartingField))
            {
                t4 parser = this.CreateParser(this.StartingField);

                this.GenerateFromTemplate(this, this.HeaderTemplate, null);

                this.GenerateFromTemplate(this, this.FormulaTemplate, new ParserDataItem<t1, t2, t3>(parser.RootLeaf, this.StartingField));

                IEnumerable<KeyValuePair<string, t4>> parsers = parser.RequiredVariables.Select(rv => this.CreateParser(rv));

                foreach (KeyValuePair<string, t4> subParser in parsers)
                    if (subParser.Value == null)
                        this.GenerateFromTemplate(this, this.MissingFormulaTemplate, new ParserDataItem<t1, t2, t3>(null, subParser.Key));
                    else
                        this.GenerateFromTemplate(this, this.SubFormulaTemplate, new ParserDataItem<t1, t2, t3>(subParser.Value.RootLeaf, subParser.Key));

                this.GenerateFromTemplate(this, this.FooterTemplate, null);

                this.DataBind();
            }
        }
    }
}
