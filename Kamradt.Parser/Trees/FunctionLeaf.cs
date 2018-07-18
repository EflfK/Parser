using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Functions;
using Kamradt.Parser.Variables;
using Kamradt.Parser.Delimiters;

namespace Kamradt.Parser.Trees
{
    public abstract class FunctionLeaf<t1, t2, t3> : Leaf<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public List<ILeaf<t1, t2, t3>> Leaves { get; set; }

        public FunctionLeaf(String Formula, List<ILeaf<t1, t2, t3>> Leaves)
            : base(Formula)
        {
            this.Leaves = Leaves;
        }

        public override IComparable Solve(t1 Variables)
        {
            if (this.Leaves.Count < this.RequiredParameterCount)
                throw new Exception("Not enough parameters");

            if (Enumerable.Range(0, this.RequiredParameterCount).Any(i => this.Leaves[i] == null))
                throw new Exception("Leaf can not be null");
               
            return this.GetFunctionValue(Variables);
        }

        protected abstract IComparable GetFunctionValue(t1 Variables);

        public abstract int RequiredParameterCount { get; }

        public override IEnumerable<t2> RequiredVariables
        {
            get
            {
                return this.Leaves.SelectMany(l => l.RequiredVariables);
            }
        }

        public override void ShiftKeys(Func<t2, t2> ShiftKey)
        {
            Leaves.ForEach(delegate(ILeaf<t1, t2, t3> l)
            {
                l.ShiftKeys(ShiftKey);
            });
        }

        public override bool Equals(object obj)
        {
            FunctionLeaf<t1, t2, t3> tempLeaf = obj as FunctionLeaf<t1, t2, t3>;

            if (tempLeaf == null || tempLeaf.Leaves.Count != this.Leaves.Count || !tempLeaf.GetType().Equals(this.GetType()))
                return false;

            for (int i = 0; i < this.Leaves.Count; i++)
                if (!this.Leaves[i].Equals(tempLeaf.Leaves[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object Clone()
        {
            object[] args = new object[] { this.Formula, this.Leaves.Select(l => (ILeaf<t1, t2, t3>)l.Clone()).ToList() };
            Type instanceType = this.GetType();

            return Activator.CreateInstance(instanceType, args);
        }
    }
}