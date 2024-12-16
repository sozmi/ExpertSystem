using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.logic_es
{
    public class Consent
    {
        public string Object { get; set; }

        public string Who { get; set; }

        public Consent(string obj, string who)
        {
            Object = obj;
            Who = who;
        }

        public override string ToString()
        {
            return $"{Object} - {Who}";
        }
    }
}
