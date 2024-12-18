namespace ClassLibraryES.semantic_es;

public class Answer
{
    public Answer() { }
    public Entity From { get; set; }

    public RelationType Relation { get; set; }

    public Entity To { get; set; }

    public Answer(Entity from_, RelationType relation_, Entity to_)
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

    }
    public Answer? Answer { get; set; }
    public List<Question>? SubQuestions { get; set; }
    public bool OneAnswer { get; set; }

    public Case(Answer answer_, bool oneAnswer_ = true)
    {
        Answer = answer_;
        OneAnswer = oneAnswer_;
    }

    public Case(List<Question> list_, bool oneAnswer_ = true)
    {
        SubQuestions = list_;
        OneAnswer = oneAnswer_;
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

    public Case? TrueCase { get; set; }
    public Case? FalseCase { get; set; }

    public Case? UnknownCase { get; set; }
}