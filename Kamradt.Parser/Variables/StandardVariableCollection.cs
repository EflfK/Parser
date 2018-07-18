using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kamradt.Parser.Variables
{
    public class StandardVariableCollection : Dictionary<string, IComparable>, IVariableCollection<StandardVariableCollectionKey>
    {
        public StandardVariableCollection(Dictionary<string, IComparable> Variables)
        {
            foreach (KeyValuePair<string, IComparable> kvp in Variables)
                this.Add(kvp.Key, kvp.Value);
        }

        public StandardVariableCollection()
        {

        }

        public IComparable this[StandardVariableCollectionKey Key]
        {
            get
            {
                if (!this.ContainsKey(Key.Key))
                    return null;

                return this[Key.Key];
            }
        }

        public bool ContainsKey(StandardVariableCollectionKey Key)
        {
            return this.ContainsKey(Key.Key);
        }

        public void Add(StandardVariableCollectionKey Key, IComparable Value)
        {
            this.Add(Key.Key, Value);
        }

        public List<StandardVariableCollectionKey> VariableCollectionKeys
        {
            get { return this.Keys.Select(k => new StandardVariableCollectionKey(k)).ToList(); }
        }

        public IVariableCollection<StandardVariableCollectionKey> GetSubCollection(IEnumerable<StandardVariableCollectionKey> SubKeys)
        {
            return new StandardVariableCollection(SubKeys.ToDictionary(k => k.ToString(), k => this[k]));
        }
    }
}