using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web.UI;

namespace Kamradt.Parser.Web.controls
{
    public class NodeTypeCollection : IList, ICollection, IEnumerable
    {
        private ArrayList Nodes;

        public NodeTypeCollection()
		{
			this.Nodes = new ArrayList();
		}

		public FormulaEntryNode this[int index]
		{
			get
			{
				return (FormulaEntryNode)this.Nodes[index];
			}
		}

		object IList.this[int index]
		{
			get
			{
				return this.Nodes[index];
			}
			set
			{
				this.Nodes[index] = (FormulaEntryNode)value;
			}
		}

		public int Capacity
		{
			get
			{
				return this.Nodes.Capacity;
			}
			set
			{
				this.Nodes.Capacity = value;
			}
		}

		public int Count
		{
			get
			{
				return this.Nodes.Count;
			}
		}

		bool IList.IsFixedSize
		{
			get
			{
				return false;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return this.Nodes.IsReadOnly;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return this.Nodes.IsSynchronized;
			}
		}

		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		public void Add(FormulaEntryNode Node)
		{
            this.Nodes.Add(Node);
            /*
			if (this.marked)
			{
                Node.Dirty = true;
			}*/
		}

		int IList.Add(object item)
		{
            FormulaEntryNode node = (FormulaEntryNode)item;
            int result = this.Nodes.Add(node);
            /*
			if (this.marked)
			{
				listItem.Dirty = true;
			}*/
			return result;
		}

        public void AddRange(FormulaEntryNode[] Nodes)
		{
            if (Nodes == null)
			{
                throw new ArgumentNullException("Node");
			}
            for (int i = 0; i < Nodes.Length; i++)
			{
                FormulaEntryNode item = Nodes[i];
				this.Add(item);
			}
		}

		public void Clear()
		{
			this.Nodes.Clear();
		}

        public bool Contains(FormulaEntryNode Node)
		{
            return this.Nodes.Contains(Node);
		}

		bool IList.Contains(object Node)
		{
			return this.Contains((FormulaEntryNode)Node);
		}

		public void CopyTo(Array array, int index)
		{
			this.Nodes.CopyTo(array, index);
		}
        
        public IEnumerator GetEnumerator()
		{
			return this.Nodes.GetEnumerator();
		}

        public int IndexOf(FormulaEntryNode Node)
		{
			return this.Nodes.IndexOf(Node);
		}

		int IList.IndexOf(object item)
		{
            return this.IndexOf((FormulaEntryNode)item);
		}

        public void Insert(int index, FormulaEntryNode Node)
		{
			this.Nodes.Insert(index, Node);
		}

		void IList.Insert(int Index, object Node)
		{
            this.Insert(Index, (FormulaEntryNode)Node);
		}

		public void RemoveAt(int index)
		{
			this.Nodes.RemoveAt(index);
		}

        public void Remove(FormulaEntryNode Node)
		{
            int num = this.IndexOf(Node);
			if (num >= 0)
			{
				this.RemoveAt(num);
			}
		}

		void IList.Remove(object Node)
		{
            this.Remove((FormulaEntryNode)Node);
		}
    }
}
