using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Trees;
using Kamradt.Parser.Variables;
using Kamradt.Parser;

namespace Kamradt.Parser.Exceptions
{
    public class FormulaExceptionEventArgs<t1, t2, t3> : EventArgs
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public Parser<t1, t2, t3> ErroredParser { get; private set; }
        public t1 VariableCollection { get; private set; }
        public Exception Error { get; private set; }

        public IVariableCollection<t2> RequiredVariableCollection
        {
            get
            {
                return this.RequiredVariableCollection.GetSubCollection(this.ErroredParser.RequiredVariables);
            }
        }
        

        public FormulaExceptionEventArgs(Parser<t1, t2, t3> ErroredParser, t1 VariableCollection, Exception Error)
        {
            this.ErroredParser = ErroredParser;
            this.VariableCollection = VariableCollection;
            this.Error = Error;
        }
    }
}
