using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Delimiters;
using Kamradt.Parser.Values;
using System.Web.UI;

namespace Kamradt.Parser.Trees
{
    public class EndLeaf<t1, t2, t3> : Leaf<t1, t2, t3>, ILeaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public IValue<t1, t2> Value { get; private set; }

        public EndLeaf(string Formula, Func<string, t2> GenerateKey)
            : base(Formula)
        {
            this.Value = ConvertFormula(Formula, GenerateKey);
        }

        public EndLeaf(EndLeaf<t1, t2, t3> AnotherEndLeaf) : base(AnotherEndLeaf)
        {
            this.Value = AnotherEndLeaf.Value.Clone() as IValue<t1, t2>;
        }

        public override IEnumerable<t2> RequiredVariables
        {
            get
            {
                return Value.RequiredVariables;
            }
        }

        public override IComparable Solve(t1 Variables)
        {
            return this.Value.Result(Variables);
        }

        private IValue<t1, t2> ConvertFormula(string Formula, Func<string, t2> GenerateKey)
        {
            if (Formula == null || Formula.ToString().Equals("null"))
                return new StaticValue<t1, t2>();

            if (Formula.StartsWith("'") && Formula.EndsWith("'"))
                return new StaticValue<t1, t2>(Formula.Substring(1, Formula.Length - 2));

            decimal d;

            if (decimal.TryParse(Formula, out d))
                return new StaticValue<t1, t2>(d);

            bool b;

            if (bool.TryParse(Formula, out b))
                return new StaticValue<t1, t2>(b);

            return new VariableValue<t1, t2>(Formula, GenerateKey);
        }

        public override t4 Solve<t4>(t1 Variables)
        {
            IComparable val = this.Solve(Variables);

            if (val == null)
                return default(t4);

            return (t4)Convert.ChangeType(val, typeof(t4));
        }

        public override void ShiftKeys(Func<t2, t2> GenerateKey)
        {
            VariableValue<t1, t2> varVal = this.Value as VariableValue<t1, t2>;
            if (varVal != null)
                varVal.VariableKey = GenerateKey(varVal.VariableKey);
        }

        public override bool Equals(object obj)
        {
            EndLeaf<t1, t2, t3> tempLeaf = obj as EndLeaf<t1, t2, t3>;

            if (tempLeaf == null)
                return false;
            
            return tempLeaf.Value.Equals(this.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object Clone()
        {
            return new EndLeaf<t1, t2, t3>(this);
        }
    }
}
