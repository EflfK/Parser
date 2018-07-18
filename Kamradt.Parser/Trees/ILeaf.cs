using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Delimiters;
using System.Web.UI;


namespace Kamradt.Parser.Trees
{
    public interface ILeaf<t1, t2, t3> : ICloneable
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        IComparable Solve(t1 Variables);
        string Formula { get; }
        IEnumerable<t2> RequiredVariables { get; }
        t4 Solve<t4>(t1 Variables)
            where t4 : IComparable;
        void ShiftKeys(Func<t2, t2> ShiftKey);
    }
}