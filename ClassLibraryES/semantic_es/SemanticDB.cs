using ClassLibraryES.Managers;
using Newtonsoft.Json.Linq;

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
                RelationType it = new("это");
                Relations.Add(it.Id, it);
                it = Relations[it.Id];

                RelationType can = new("может");
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
                AddRelation(new(bird.Id, sneg.Id, it.Id));
            }
        }
        public Dictionary<Guid, Entity> Entities { get; set; } = [];
        public Dictionary<Guid, RelationType> Relations { get; set; } = [];
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

            Tuple<RelationType, Entity> tuple = new(relation, slave);
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

        public List<RelationType> GetRelations()
        {
            return [.. Relations.Values];
        }

        public List<Entity> GetEntities()
        {
            return [.. Entities.Values];
        }

        #region Edit Entity

        public void Create(Entity newObj)
        {
            Entities.Add(newObj.Id, newObj);
        }

        public void Edit(Entity newObj)
        {
            Entities[newObj.Id] = newObj;
        }

        public void DeleteEntity(Guid id)
        {
            Entities.Remove(id);
            foreach (var key in Links.ToArray())
            {
                if (key.Id == id)
                {
                    //если объект является главным в связи,
                    //достаточно удалить только ключ
                    Links.Remove(key);
                }
                else if (key.Slave == id)
                {
                    //если объект является подчиненным в связи,
                    //необходимо удалить связь из главного объекта
                    Entities[key.Id].RemoveRelation(key);
                    Links.Remove(key);
                }
            }
        }
        #endregion

        #region Edit RelationType
        public void Create(RelationType newObj)
        {
            Relations.Add(newObj.Id, newObj);
        }

        public void Edit(RelationType newObj)
        {
            Relations[newObj.Id] = newObj;
        }

        public void DeleteRelationType(Guid id)
        {
            Relations.Remove(id);
            foreach (var key in Links.ToArray())
            {
                if (key.Relative != id)
                    continue;
                Entities[key.Id].RemoveRelationType(key.Relative);
                Links.Remove(key);
            }
        }
        #endregion
    }
}
