using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Trees;
using System.Web.UI.HtmlControls;

namespace Kamradt.Parser.Functions
{
    public class If<t1, t2, t3> : FunctionLeaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public If(string Formula, List<ILeaf<t1, t2, t3>> Leaves) : base(Formula, Leaves) { }

        protected override IComparable GetFunctionValue(t1 Variables)
        {
            return Leaves[0].Solve<bool>(Variables) ? Leaves[1].Solve(Variables) : Leaves[2].Solve(Variables);
        }

        public override int RequiredParameterCount
        {
            get { return 3; }
        }
    }
}
