namespace ClassLibraryES.semantic_es
{
    using Newtonsoft.Json;
    using TRelEnt = Tuple<RelationType, Entity>;
    public class Entity
    {
        public Entity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Dictionary<Guid, Association> Associations { get; } = [];

        public void AddRelation(TRelEnt rel_)
        {
            var idRel = rel_.Item1.Id;
            if (!Associations.ContainsKey(idRel))
                Associations.Add(idRel, new(rel_.Item1));
            Associations[idRel].Add(rel_.Item2);
        }

        public void RemoveRelation(KeyLink key_)
        {
            Associations[key_.Relative].Remove(key_.Slave);
            if (Associations[key_.Relative].Entities.Count == 0)
                Associations.Remove(key_.Relative);
        }
    }
}