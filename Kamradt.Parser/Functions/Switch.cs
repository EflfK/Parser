using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Functions
{
    public class Switch : Function
    {

        #region IFunction Members

        public override string FunctionName
        {
            get { return "switch"; }
        }

        public override IComparable Value(IComparable[] Parameters, IVariableCollection Variables)
        {
            if (Parameters.Length % 2 != 1)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < Parameters.Length - 1; i += 2)
                if (Convert.ToBoolean(Parameters[i]))
                    return Parameters[i + 1];

            return Parameters[Parameters.Length - 1];
        }

        #endregion
    }
}
