using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Kamradt.Parser.Variables
{
    public class StandardRequiredVariables : List<StandardVariableCollectionKey>, IRequiredVariables<StandardVariableCollection, StandardVariableCollectionKey>
    {
        public bool ContainsRequiredVariables(StandardVariableCollection VariableCollection)
        {
            return this.Any(v => !VariableCollection.ContainsKey(v));
        }

        public void Add(IRequiredVariables<StandardVariableCollection, StandardVariableCollectionKey> collection)
        {
            foreach (StandardVariableCollectionKey key in collection)
                this.Add(key);
        }
    }
}