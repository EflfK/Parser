using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kamradt.Parser.Delimiters
{
    public abstract class Delimiter : IDelimiter
    {
        public Delimiter() { }

        #region IDelimiter Members

        public abstract string Delim { get; }

        protected abstract IComparable Predicate(IComparable LHS, IComparable RHS);

        public IComparable Value(IComparable LHS, IComparable RHS)
        {
            return Predicate(LHS, RHS);
        }

        #endregion
    }
}
