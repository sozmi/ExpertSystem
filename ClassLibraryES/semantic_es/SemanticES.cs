using ClassLibraryES.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.semantic_es
{
    public class SemanticES
    {
        Entity find = new(Guid.Empty,"Поиск цели");

        public static List<Tuple<Guid, string>> GetTargetConsult()
        {
            List<Tuple<Guid, string>>  targets = [];
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null)
                return [];
            foreach (var item in db.GetEntities())
                    targets.Add(new(item.Id,item.Name));
            return targets;
        }
        public List<Tuple<Guid, string>> Answers {  get; set; } = GetTargetConsult();
        public string Question { get; set; } = "Выберите цель консультации";

        public void StartConsult(Guid id)
        {
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null)
                return;

            var start = db.GetEntity(id);
            if (start == null) 
                return;
            
            foreach(var rel in start.GetRelationTypes())
            {
                Question = "Нам нужно определить" + rel.QuestionFrom.Replace("%link%", rel.Name).Replace("%obj", start.Name);
                Answers = new();
            }
        }

        public void Next()
        {

        }
    }
}
