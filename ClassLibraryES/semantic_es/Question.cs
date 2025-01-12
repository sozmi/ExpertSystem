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
    public Case()
    {
        Name = string.Empty;
    }
    public Case(string name_, bool continueAsk_ = true)
    {
        Name = name_;
        AskContinue = continueAsk_;
    }
    public List<Fact> Facts { get; set; } = [];
    public List<Question> Questions { get; set; } = [];
    /// <summary>
    /// Продолжить опрос по текущей иерархии, или вернуться на уровень выше. True - продолжить
    /// </summary>
    public bool AskContinue { get; set; }
    public string Name {  get; set; }
    public Case(string name_, Fact fact_, bool continueAsk_ = true) : this(name_, continueAsk_)
    {
        Facts.Add(fact_);
    }

    public Case(string name_, Question question_, bool continueAsk_ = true) : this(name_, continueAsk_)
    {
        Questions.Add(question_);
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

    public string Text { get; set; }

    public List<Case> Cases { get; set; } = [];

    public void AddCase(Case case_)
    {
        Cases.Add(case_);
    }
}