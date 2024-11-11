using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace ClassLibraryES.Semantic
{
    using TRelEnt = Tuple<Relation, Entity>;
    public class Entity
    {
        public Entity(string name, ) { }
        public Entity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        private List<TRelEnt> relations { get; } = [];

        public void AddRelation(TRelEnt rel)
        {
            relations.Add(rel);
        }
    }
}