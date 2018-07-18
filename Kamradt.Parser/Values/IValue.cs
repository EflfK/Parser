using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Values
{
    public interface IValue<t1, t2> : ICloneable
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
    {
        IComparable Result(t1 Variables);
        IEnumerable<t2> RequiredVariables { get; }
        string ToString();
        string RawValue { get; }
    }
}
