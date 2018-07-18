using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Trees;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Functions
{
    public abstract class Function<t1, t2, t3> : IFunction<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public Function() { }

        #region IFunction Members

        public abstract string FunctionName { get; }

        public abstract int RequiredParameterCount { get; }

        #endregion

        public abstract IComparable Value(List<ILeaf<t1, t2, t3>> Leaves, t1 Variables);


        public virtual IEnumerable<t2> AdditionalContainedVariables(List<ILeaf<t1, t2, t3>> Leaves)
        {
            return new t2[] { };
        }
    }
}