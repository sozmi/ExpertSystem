using ClassLibraryES.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.semantic_es;

public class SemanticES
{
    static Case target;
    int idxQuestion = 0;
    public static List<UseCase> GetTargetConsult()
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null)
            return [];
        return db.GetUseCases();
    }

    public string Question { get; set; } = "Выберите цель консультации";

    public static Question? StartConsult(Guid id)
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null)
            return null;
        target = db.GetUseCase(id);
        KnowledgeFacts.Push(target.Facts);
        Queue<Question> questions = new();

        foreach (var q in target.Questions)
            questions.Enqueue(q);
        HistoryQuestions.Push(questions);

        return target.Questions.FirstOrDefault();
    }
    static Stack<List<Fact>> KnowledgeFacts { get; set; } = [];
    static Stack<Queue<Question>> HistoryQuestions { get; set; } = [];
    static Stack<Case> HistoryCases { get; set; } = [];
    public static Question? Next(Case c)
    {
        if (c == null) 
            return null;

        //запоминаем ответ
        HistoryCases.Push(c);

        //если в варианте ответа установлены факты запомним их
        var f = c.Facts;
        KnowledgeFacts.Push(f);

        //выбираем следующий вопрос
        var subQuestions = c.Questions;

        //если в этой ветке подчиненных вопросов больше нет, 
        //но в ответе стоит галка продолжения опроса,
        //переходим к следующему вопросу в той же иерархии
        if (subQuestions.Count == 0 && c.AskContinue)
        {
            var ierarh_q=HistoryQuestions.Peek();
            //если на том же уровне есть вопросы, 
            //вернем первый из очереди
            if(ierarh_q.Count != 0)
                return ierarh_q.Dequeue();

            //иначе поднимаемся вверх, пока не найдем вопрос
            return Up();
        }
        //если в этой ветке подчиненных вопросов больше нет, 
        //и в ответе не нужно продолжать опрос в текущей иерархии,
        //переходим к следующему вопросу выше по иерархии
        else if (subQuestions.Count == 0 && !c.AskContinue)
        {
            return Up();
        }
        //иначе остались подчиненные вопросы
        //и спрашивать будем их
        else
        {
            Queue<Question> questions = new();
            foreach (var w in target.Questions)
                questions.Enqueue(w);
            HistoryQuestions.Push(questions);
            var ierarh_q = HistoryQuestions.Peek();
            return ierarh_q.Dequeue();
        }
    }
    public void Previous()
    {

    }

    private static Question? Up()
    {
        if (HistoryQuestions.Count == 0)
            return null;
        
        //поднимаемся на уровень выше
        HistoryQuestions.Pop();
        HistoryCases.Pop();

        if (HistoryQuestions.Count == 0)
            return null;

        if (HistoryCases.Count == 0) 
            return null;

        //если на этом уровне для этого ответа
        //была установлена галка продолжения опроса
        //вернем следующий вопрос из иерархии, если таковых нет
        //попробуем подняться на уровень выше
        if (HistoryCases.Peek().AskContinue)
        {
            var ierarh_q = HistoryQuestions.Peek();
            if(ierarh_q.Count == 0)
                return Up();
            return ierarh_q.Dequeue();
        }
        //иначе можем сразу переходить выше по иерархии
        return Up();
    }

    private static string FindGraph()
    {
        
        while(KnowledgeFacts.Count > 0)
        {
            KnowledgeFacts.Pop();
        }
        return "не найден";
    }
    public static string EndConsult()
    {
        string text = "Искомый ответ";
        
        return text + FindGraph();
    }
}
