using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser.Values
{
    public class StaticValue<t1, t2> : IValue<t1, t2>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
    {
        public IComparable Value { get; set; }

        public StaticValue(IComparable Value)
        {
            this.Value = Value;
        }

        public StaticValue() { }

        public StaticValue(StaticValue<t1, t2> AnotherStaticValue)
        {
            this.Value = AnotherStaticValue.Value;
        }

        public IComparable Result(t1 Variables)
        {
            return this.Value;
        }

        public IEnumerable<t2> RequiredVariables
        {
            get { return new t2[] { }; }
        }

        public override bool Equals(object obj)
        {
            StaticValue<t1, t2> tempValue = obj as StaticValue<t1, t2>;

            return tempValue != null && tempValue.Value.Equals(this.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new StaticValue<t1, t2>(this);
        }

        public override string ToString()
        {
            return Value.ToString();
        }


        public string RawValue
        {
            get { return Value.ToString(); }
        }
    }
}
