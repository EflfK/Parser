using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;

namespace Kamradt.Parser.Functions
{
    public class Len<t1, t2, t3> : FunctionLeaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public Len(string Formula, List<ILeaf<t1, t2, t3>> Leaves) : base(Formula, Leaves) { }

        public override int RequiredParameterCount
        {
            get { return 1; }
        }

        protected override IComparable GetFunctionValue(t1 Variables)
        {
            string val = Leaves[0].Solve<string>(Variables);

            if (String.IsNullOrEmpty(val))
                return 0;

            return Convert.ToDecimal(val.Length);
        }
    }
}
