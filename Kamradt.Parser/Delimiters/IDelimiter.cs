using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kamradt.Parser.Delimiters
{
    public interface IDelimiter
    {
        string Delim { get; }
        IComparable Value(IComparable LHS, IComparable RHS);
    }
}