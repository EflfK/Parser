using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kamradt.Parser.Variables
{
    public class StandardVariableCollectionKey : IVariableCollectionKey
    {
        public string Key { get; set; }

        public StandardVariableCollectionKey(string Key)
        {
            this.Key = Key;
        }

        public int CompareTo(object obj)
        {
            if (obj is StandardVariableCollectionKey)
                return this.Key.CompareTo(obj as string);

            throw new ArgumentException("Wrong data type.");
        }

        public int Compare(IVariableCollectionKey x, IVariableCollectionKey y)
        {
            if (x is StandardVariableCollectionKey)
                return (x as StandardVariableCollectionKey).CompareTo(y);

            throw new ArgumentException("Wrong data type.");
        }
    }
}
