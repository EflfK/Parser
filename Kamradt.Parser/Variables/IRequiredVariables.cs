using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kamradt.Parser.Variables
{
    public interface IRequiredVariables<t1, t2> : IList<t2>
        where t1: IVariableCollection<t2>
        where t2: IVariableCollectionKey
    {
        void AddRange(IEnumerable<t2> collection);
        bool ContainsRequiredVariables(t1 VariableCollection);
        void Add(IRequiredVariables<t1, t2> collection);
    }
}