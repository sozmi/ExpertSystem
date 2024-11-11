using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.Semantic
{
    public class SemanticDB
    {
        public SemanticDB() { }
        public SemanticDB(bool isTest = false) 
        {
            if(isTest)
            {
                Relation it = new("это");
                relations.Add(it.Id, it);
                it = relations[it.Id];

                Relation can = new("может");
                relations.Add(can.Id, can);
                can = relations[can.Id];

                Entity fly = new("Летать");
                entities.Add(fly.Id, fly);
                fly = entities[fly.Id];

                Entity bird = new("Птица");
                bird.AddRelation(new(can, fly));
                entities.Add(bird.Id,bird);
                bird = entities[bird.Id];

                Entity sneg = new("Снегирь");
                sneg.AddRelation(new(it, bird));
                entities.Add(sneg.Id, sneg);
                bird.AddRelation(new(it, sneg));//Неправильное заключение, но нужно проверить циклы
            }
        }
        public Dictionary<Guid, Entity> entities { get; set; } = [];
        public Dictionary<Guid, Relation> relations { get; set; } = [];
        void Load()
        {

        }
    }
}
