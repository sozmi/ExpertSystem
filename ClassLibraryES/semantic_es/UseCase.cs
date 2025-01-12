namespace ClassLibraryES.semantic_es;

public class UseCase : Case
{
    public UseCase()
    {
        Id = Guid.NewGuid();
        Name = "";
        Description = "";
        AskContinue = true;
    }
    public UseCase(Guid id_, string name_)
    {
        Id = id_;
        Name = name_;
        Description = "";
        AskContinue = true;
    }
    public UseCase(string name_)
    {
        Id = Guid.NewGuid();
        Name = name_;
        Description = "";
        AskContinue = true;
    }
    public Guid Id { get; set; }

    public string Description { get; set; }
}