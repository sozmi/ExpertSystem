using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace ClassLibraryES.Semantic
{
    using TRelEnt = Tuple<Relation, Entity>;
    public class Entity
    {
        public Entity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        private Dictionary<Relation, List<Entity>> Relations { get; } = [];

        public void AddRelation(TRelEnt rel)
        {
            if (!Relations.ContainsKey(rel.Item1))
                Relations.Add(rel.Item1, []);
            Relations[rel.Item1].Add(rel.Item2);
        }
    }
}