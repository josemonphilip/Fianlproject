using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.ServiceLayer
{
    public class BrokenBusinessRules
    {
        public BrokenBusinessRules(string property,string rule)
        {
            this.Property = property;
            this.Rule = rule;
        }
        public string Property { get; set; }
        public string Rule { get; set; }
    }
}
