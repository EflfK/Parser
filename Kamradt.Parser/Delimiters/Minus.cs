using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Trees;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Delimiters
{
    public class Minus<t1, t2, t3> : BranchingLeaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public Minus(String Formula, ILeaf<t1, t2, t3> LHS, ILeaf<t1, t2, t3> RHS)
            : base(Formula, LHS, RHS) { }

        protected override IComparable GetBranchingValue(IComparable LHS, IComparable RHS)
        {
            if (RHS == null || LHS == null)
                return null;

            decimal lhs = 0, rhs = 0;

            decimal.TryParse(LHS.ToString(), out lhs);
            
            if (!decimal.TryParse(RHS.ToString(), out rhs))
                return null;

            return lhs - rhs;
        }
    }
}
