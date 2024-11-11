using System.Data;

namespace ClassLibraryES.Semantic
{
    public class Relation
    {
        public Relation() {
            Id = new();
            Name = "";
        }
        public Relation(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Relation(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
