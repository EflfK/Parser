using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;

namespace Kamradt.Parser.Functions
{
    public class Substring<t1, t2, t3> : FunctionLeaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public Substring(string Formula, List<ILeaf<t1, t2, t3>> Leaves) : base(Formula, Leaves) { }

        public override int RequiredParameterCount
        {
            get { return 3; }
        }

        protected override IComparable GetFunctionValue(t1 Variables)
        {
            string val = Leaves[0].Solve<string>(Variables);

            if (string.IsNullOrEmpty(val))
                return null;

            int startIndex = Leaves[1].Solve<int>(Variables);
            int length = Leaves[2].Solve<int>(Variables);

            if (String.IsNullOrEmpty(val)
                || val.Length <= startIndex
                || length + startIndex > val.Length
                )
                return null;

            return String.Format("{0}", val.Substring(startIndex, length));
        }
    }
}
