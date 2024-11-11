using ClassLibraryES.Managers;
using ClassLibraryES.Semantic;

namespace ClassLibraryES.semantic_es
{
    [Serializable]
    public class SemanticDB : IKnowledgeBase
    {
        public SemanticDB() { }
        public SemanticDB(bool isTest = false)
        {
            if (isTest)
            {
                Relation it = new("это");
                Relations.Add(it.Id, it);
                it = Relations[it.Id];

                Relation can = new("может");
                Relations.Add(can.Id, can);
                can = Relations[can.Id];

                Entity fly = new("Летать");
                Entities.Add(fly.Id, fly);
                fly = Entities[fly.Id];

                Entity bird = new("Птица");
                Entities.Add(bird.Id, bird);
                bird = Entities[bird.Id];

                Entity sneg = new("Снегирь");
                Entities.Add(sneg.Id, sneg);

                AddRelation(new(sneg.Id, bird.Id, it.Id));
                AddRelation(new(bird.Id, fly.Id, can.Id));
                AddRelation(new(bird.Id, sneg.Id, it.Id)); //Неправильное заключение, но нужно проверить циклы
            }
        }
        public Dictionary<Guid, Entity> Entities { get; set; } = [];
        public Dictionary<Guid, Relation> Relations { get; set; } = [];
        public List<KeyLink> Links { get; set; } = [];

        public void Close()
        {
            throw new NotImplementedException();
        }
        public void AddRelation(KeyLink key)
        {
            Links.Add(key);
            AddRelationNoKey(key);
        }
        private void AddRelationNoKey(KeyLink key)
        {
            var target = Entities[key.Id];
            var slave = Entities[key.Slave];
            var relation = Relations[key.Relative];

            Tuple<Relation, Entity> tuple = new(relation, slave);
            target.AddRelation(tuple);
        }
        public bool Open()
        {
            foreach (var key in Links)
            {
                AddRelationNoKey(key);
            }

            return true;
        }
    }
}
