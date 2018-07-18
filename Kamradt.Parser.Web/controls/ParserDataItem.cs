using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;

namespace Kamradt.Parser.Web.controls
{
    public class ParserDataItem<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public ParserDataItem(ILeaf<t1, t2, t3> TreeLeaf, string Field)
        {
            this.TreeLeaf = TreeLeaf;
            this.Field = Field;
        }

        public ILeaf<t1, t2, t3> TreeLeaf { get; private set; }
        public string Field { get; private set; }
        public string Formula
        {
            get
            {
                return TreeLeaf.Formula;
            }
        }
    }
}
