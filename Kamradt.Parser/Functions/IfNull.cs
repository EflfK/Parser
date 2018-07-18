using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;

namespace Kamradt.Parser.Functions 
{
    public class IfNull<t1, t2, t3> : FunctionLeaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public IfNull(string Formula, List<ILeaf<t1, t2, t3>> Leaves) : base(Formula, Leaves) { }

        protected override IComparable GetFunctionValue(t1 Variables)
        {
            return Leaves[0].Solve(Variables) ?? Leaves[1].Solve(Variables);
        }

        public override int RequiredParameterCount
        {
            get { return 2; }
        }
    }
}
