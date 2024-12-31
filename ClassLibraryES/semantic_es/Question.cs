namespace ClassLibraryES.semantic_es;

public class Fact
{
    public Fact() { }
    public Entity From { get; set; }

    public RelationType Relation { get; set; }

    public Entity To { get; set; }

    public Fact(Entity from_, RelationType relation_, Entity to_)
    {
        From = from_;
        Relation = relation_;
        To = to_;
    }
}
public class Case
{
    public Case(string name_)
    {
        Name = name_;
    }
    public List<Fact>? Facts { get; set; }
    public List<Question>? SubQuestions { get; set; }
    public bool AskContinue { get; set; }
    public string Name {  get; set; }
    public Case(Fact fact_, bool continueAsk_ = true)
    {
        Facts = [];
        Facts.Add(fact_);
        AskContinue = continueAsk_;
    }

    public Case(List<Question> list_, bool oneAnswer_ = true)
    {
        SubQuestions = list_;
        AskContinue = oneAnswer_;
    }
}

public class Question
{
    public Question()
    {

    }

    public Question(string text)
    {
       Text = text;
    }

    public Guid Id { get; set; }
    public string Text { get; set; }

    public List<Case> Cases { get; set; } = [];

    public void AddCase(string name, Case case_)
    {
        case_.Name = name;
        Cases.Add(case_);
    }
}