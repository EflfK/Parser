using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Web.UI;
using System.ComponentModel;

namespace Kamradt.Parser.Web.controls
{
    public class FormulaEntryNode
    {
        [PersistenceMode(PersistenceMode.Attribute)]
        public string Name { get; set; }
        
        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(FormulaContainer))]
        public ITemplate EntryTempalte { get; set; }
    }
}
