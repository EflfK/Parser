using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Trees;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Functions
{
    public static class Extensions
    {
        public static t4 GetLeafValue<t1, t2, t3, t4>(this ILeaf<t1, t2, t3> Leaf, t1 Variables)
            where t1 : IVariableCollection<t2>
            where t2 : IVariableCollectionKey
            where t3 : IRequiredVariables<t1, t2>
            where t4 : IComparable
        {
            IComparable val = Leaf.Solve(Variables);

            return (t4)val;
        }
    }
}
