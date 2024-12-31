namespace ClassLibraryES.semantic_es;

public class UseCase
{
    public UseCase()
    {
        Id = Guid.NewGuid();
        Name = "";
    }
    public UseCase(Guid id_, string name_)
    {
        Id = id_;
        Name = name_;
    }
    public UseCase(string name_)
    {
        Id = Guid.NewGuid();
        Name = name_;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Question> Questions { get; set; } = [];
    public List<Fact> Facts { get; set; } = [];
}