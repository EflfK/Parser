using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Delimiters;
using Kamradt.Parser.Values;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Kamradt.Parser.Trees
{
    public abstract class Leaf<t1, t2, t3> : ILeaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public string Formula { get; private set; }

        public Leaf(string Formula)
        {
            this.Formula = Formula;
        }

        public Leaf(ILeaf<t1, t2, t3> AnotherLeaf)
        {
            this.Formula = AnotherLeaf.Formula;
        }

        #region ILeaf Members

        public abstract IComparable Solve(t1 Variables);

        public abstract IEnumerable<t2> RequiredVariables { get; }

        #endregion

        public virtual t4 Solve<t4>(t1 Variables)
            where t4 : IComparable
        {
            IComparable val = this.Solve(Variables);

            if (val == null)
                return default(t4);

            return (t4)Convert.ChangeType(val, typeof(t4));
        }

        public abstract void ShiftKeys(Func<t2, t2> GenerateKey);
        public abstract object Clone();

        public override int GetHashCode()
        {
            return this.Formula.GetHashCode();
        }
    }
}
