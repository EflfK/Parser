using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using System.Web.UI;

namespace Kamradt.Parser.Values
{
    public class VariableValue<t1, t2> : IValue<t1, t2>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
    {
        public string VariableName { get; private set; }
        public t2 VariableKey { get; internal set; }

        public VariableValue(string VariableName, Func<string, t2> GenerateKey)
        {
            this.VariableName = VariableName;
            this.VariableKey = GenerateKey(VariableName);
        }

        public VariableValue(VariableValue<t1, t2> AnotherVariableValue)
        {
            this.VariableName = AnotherVariableValue.VariableName;
            this.VariableKey = AnotherVariableValue.VariableKey;
        }

        public IComparable Result(t1 Variables)
        {
            return Variables[this.VariableKey].ConvertToCalcType();
        }


        public IEnumerable<t2> RequiredVariables
        {
            get { return new t2[] { VariableKey }; }
        }

        public override bool Equals(object obj)
        {
            VariableValue<t1, t2> tempValue = obj as VariableValue<t1, t2>;

            if (tempValue == null)
                return false;

            return tempValue.VariableName.Equals(this.VariableName) && tempValue.VariableKey.Equals(this.VariableKey);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new VariableValue<t1, t2>(this);
        }

        public override string ToString()
        {
            return VariableKey.ToString();
        }

        public string RawValue
        {
            get { return VariableName.ToString(); }
        }
    }
}