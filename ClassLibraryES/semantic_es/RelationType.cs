namespace ClassLibraryES.semantic_es
{
    public class RelationType
    {
        public RelationType()
        {
            Id = new();
            Name = "";
        }
        public RelationType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public RelationType(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
