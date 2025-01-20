using ClassLibraryES.semantic_es;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryES.logic_es;

public class Consent
{
    public Guid Id { get; set; }

    public string Object { get; set; }

    public string Who { get; set; }

    public Consent(string obj, string who)
    {
        Id = Guid.NewGuid();
        Object = obj;
        Who = who;
    }

    public bool DelId(Guid id)
    {

    }

    public override string ToString()
    {
        return $"{Object} - {Who}";
    }
}
