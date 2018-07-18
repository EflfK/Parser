using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kamradt.Parser.Variables
{
    public interface IVariableCollection<t1>
        where t1: IVariableCollectionKey
    {
        IComparable this[t1 Key] { get; }
        bool ContainsKey(t1 Key);
        void Add(t1 Key, IComparable Value);
        List<t1> VariableCollectionKeys { get; }
        IVariableCollection<t1> GetSubCollection(IEnumerable<t1> SubKeys);
    }
}