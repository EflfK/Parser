using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Delimiters;
using Kamradt.Parser.Variables;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Kamradt.Parser.Trees
{
    public abstract class BranchingLeaf<t1, t2, t3> : Leaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public ILeaf<t1, t2, t3> LHS { get; set; }
        public ILeaf<t1, t2, t3> RHS { get; set; }

        public BranchingLeaf(String Formula, ILeaf<t1, t2, t3> LHS, ILeaf<t1, t2, t3> RHS)
            : base(Formula)
        {
            this.LHS = LHS;
            this.RHS = RHS;
        }

        public override IComparable Solve(t1 Variables)
        {
            IComparable lhs = LHS.Solve(Variables);
            IComparable rhs = RHS.Solve(Variables);

            return this.GetBranchingValue(lhs, rhs);
        }

        protected abstract IComparable GetBranchingValue(IComparable LHS, IComparable RHS);

        public override IEnumerable<t2> RequiredVariables
        {
            get
            {
                return LHS.RequiredVariables.Concat(RHS.RequiredVariables);
            }
        }

        public override void ShiftKeys(Func<t2, t2> ShiftKey)
        {
            LHS.ShiftKeys(ShiftKey);
            RHS.ShiftKeys(ShiftKey);
        }

        public override bool Equals(object obj)
        {
            BranchingLeaf<t1, t2, t3> tempLeaf = obj as BranchingLeaf<t1, t2, t3>;

            if (tempLeaf == null || !obj.GetType().Equals(this.GetType()))
                return false;

            return LHS.Equals(tempLeaf.LHS) && RHS.Equals(tempLeaf.RHS);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object Clone()
        {
            return Activator.CreateInstance(this.GetType(), this.Formula, LHS.Clone(), RHS.Clone());
        }
    }
}