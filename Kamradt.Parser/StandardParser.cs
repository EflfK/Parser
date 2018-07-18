using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Variables;

namespace Kamradt.Parser
{
    public class StandardParser : Parser<StandardVariableCollection, StandardVariableCollectionKey, StandardRequiredVariables>
    {
        public StandardParser(string Formula) : base(Formula, f => new StandardVariableCollectionKey(f)) { }
    }
}
