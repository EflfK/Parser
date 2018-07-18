using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;

namespace Kamradt.Parser.Functions
{
    public interface IFunction<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        string FunctionName { get; }
        IEnumerable<t2> AdditionalContainedVariables(List<ILeaf<t1, t2, t3>> Leaves);
        IComparable Value(List<ILeaf<t1, t2, t3>> Leaves, t1 Variables);
        int RequiredParameterCount { get; }
    }
}
