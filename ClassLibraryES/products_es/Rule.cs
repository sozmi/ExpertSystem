using System;
using System.Collections.Generic;
namespace ClassLibraryES.products_es;

public class Rule
{
    public Guid Id { get; private set; }
    public string? Name { get; set; }
    public List<Fact> Premises { get; private set; }
    public Fact? Result { get; set; }

    public Rule()
    {
        Id = Guid.NewGuid();
        Premises = new();
    }

    public void AddPremise(Fact premise)
    {
        if (!Premises.Contains(premise))
        {
            Premises.Add(premise);
        }
    }

    /// <summary>
    /// Обновляет свойства правила
    /// </summary>
    public void Update(string? name, Fact? result, IEnumerable<Fact> premises)
    {
        Name = name;
        Result = result;
        Premises.Clear();
        foreach (var premise in premises)
        {
            AddPremise(premise);
        }
    }

    public bool CheckPremises(ICollection<Fact> facts)
    {
        foreach (var premise in Premises)
        {
            if (!facts.Contains(premise))
                return false;
        }
        return true;
    }
}