using ClassLibraryES.Managers;
using ClassLibraryES.system;
using Newtonsoft.Json;

namespace ClassLibraryES.semantic_es
{
    public class SemanticDB : IKnowledgeBase
    {
        public SemanticDB()
        {
        }
        public SemanticDB(bool isTest = false) : base()
        {
            if (isTest)
            {
                //TODO: перенести создание в Test
                RelationType it = new("это", "Нужно определить %obj% это что(кто)?");
                Create(it);

                RelationType can = new("может", "Нужно учитывать что может делать %obj%?");
                Create(can);

                RelationType cannot = new("не может", "Нужно учитывать что не может делать %obj%?");
                Create(cannot);

                RelationType has = new("имеет", "Нужно учитывать что имеет %obj?");
                Create(has);

                Entity fly = new("Летать");
                Create(fly);

                Entity wings = new("Крылья");
                Create(wings);

                Entity paws = new("Лапы");
                Create(paws);

                Entity bird = new("Птица");
                Create(bird);

                Entity sneg = new("Снегирь");
                Create(sneg);

                Entity grach = new("Грач");
                Create(grach);

                Entity straus = new("Страус");
                Create(straus);

                AddLink(new(bird.Id, fly.Id, can.Id));
                AddLink(new(sneg.Id, bird.Id, it.Id));
                AddLink(new(grach.Id, bird.Id, it.Id));
                AddLink(new(straus.Id, fly.Id, cannot.Id));
                AddLink(new(straus.Id, bird.Id, it.Id));
                AddLink(new(bird.Id, wings.Id, has.Id));
                AddLink(new(bird.Id, paws.Id, has.Id));
            }
        }

        /// <summary>
        /// Словарь содержащий информацию о сущностях БЗ
        /// </summary>
        [JsonProperty]
        private Dictionary<Guid, Entity> Entities { get; set; } = [];

        /// <summary>
        /// Словарь содержащий информацию о типах отношений в БЗ
        /// </summary>
        [JsonProperty]
        public Dictionary<Guid, RelationType> Relations { get; set; } = [];

        /// <summary>
        /// Словарь содержащий информацию о связях в БЗ
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(CustomDictionaryConverter<KeyLink, Link>))]
        private Dictionary<KeyLink, Link> Links { get; set; } = [];

        #region Interface
        public bool Open()
        {
            foreach (var pair in Links)
            {
                Link link = pair.Value;
                KeyLink key = pair.Key;
                //восстанавливаем содержимое связей
                link.Relation = Get(key.Relative);
                link.Entity = GetEntity(key.Slave);
                //добавляем к главной сущности
                GetEntity(key.Id).AddLink(link);
            }

            return true;
        }
        public void Close()
        {
            Relations.Clear();
            Entities.Clear();
            Links.Clear();
        }
        #endregion

        #region Relation
        /// <summary>
        /// Получение типа связи по идентификатору
        /// </summary>
        /// <param name="id_">Идентификатор</param>
        /// <returns>в случае успеха ссылку на отношение, иначе выбрасывает исключение</returns>
        private RelationType Get(Guid id_) => Relations[id_];

        /// <summary>
        /// Получение списка отношений
        /// </summary>
        /// <returns>Список отношений</returns>
        public List<RelationType> GetRelations() => [.. Relations.Values];
        #endregion

        #region Entity
        /// <summary>
        /// Получение сущности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns></returns>
        public Entity GetEntity(Guid id) => Entities[id];

        /// <summary>
        /// Получение списка сущностей
        /// </summary>
        /// <returns>Список сущностей</returns>
        public List<Entity> GetEntities() => [.. Entities.Values];
        #endregion

        #region Edit Entity
        /// <summary>
        /// Создание новой сущности
        /// </summary>
        /// <param name="newObj_"></param>
        public void Create(Entity newObj_)
        {
            Entities.Add(newObj_.Id, newObj_);
        }

        /// <summary>
        /// Редактирование существующей сущности
        /// </summary>
        /// <param name="newObj_">Новая сущность</param>
        public void Edit(Entity newObj_, HashSet<KeyRelative> newKeys_)
        {
            var old = GetEntity(newObj_.Id);
            var oldKeys = old.GetKeysRelative();
            old.Name = newObj_.Name;
            var id = newObj_.Id;
            foreach (var key in newKeys_)
            {
                if (!oldKeys.Contains(key))
                {
                    //если в старой сущности нет такой связя, нужно её добавить,
                    //иначе можно ничего не делать 
                    AddLink(new(id, key));
                }
                oldKeys.Remove(key); //удаляем новые и неизменившиеся связи, чтобы остались только удаленные
            }

            foreach (var key in oldKeys)
                RemoveLink(new(id, key));
        }

        /// <summary>
        /// Удаление существующей сущности
        /// </summary>
        /// <param name="id_">Идентификатор сущности</param>
        public void RemoveEntity(Guid id_)
        {
            foreach (var key in GetEntity(id_).GetKeysRelations())
            {
                //если объект является главным в связи,
                //достаточно удалить только ключ
                Links.Remove(key);
            }

            foreach (var key in Links.Keys)
            {
                if (key.Slave == id_)
                {
                    //если объект является подчиненным в связи,
                    //необходимо удалить связь из главного объекта
                    Entities[key.Id].RemoveLink(key);
                    Links.Remove(key);
                }
            }
            Entities.Remove(id_);
        }
        #endregion

        #region Edit RelationType
        public void Create(RelationType newObj_)
        {
            Relations.Add(newObj_.Id, newObj_);
        }

        public void Edit(RelationType newObj_)
        {
            Relations[newObj_.Id] = newObj_;
        }

        public void RemoveRelationType(Guid id_)
        {
            Relations.Remove(id_);
            foreach (var key in Links.Keys)
            {
                if (key.Relative != id_)
                    continue;
                RemoveLink(key);
            }
        }
        #endregion

        #region Links
        /// <summary>
        /// Удаляем связь по ключу, зачищаем хвосты
        /// </summary>
        /// <param name="key_">Ключ связи</param>
        public void RemoveLink(KeyLink key_)
        {
            Entities[key_.Id].RemoveLink(key_);
            Links.Remove(key_);
        }

        /// <summary>
        /// Создание связи по ключу
        /// </summary>
        /// <param name="key_">Ключ связи</param>
        /// <returns>Связь</returns>
        public Link AddLink(KeyLink key_)
        {
            var target = Entities[key_.Id];
            var slave = Entities[key_.Slave];
            var relation = Relations[key_.Relative];

            Link link = new(relation, slave);
            Links.Add(key_, link);
            target.AddLink(link);
            return link;
        }

        public Link GetLink(KeyLink key_)
        {
            return Links[key_];
        }

        public void EditLink(KeyLink key_, Link newLink_)
        {
            var old = GetLink(key_);
            old.Relation = newLink_.Relation;
            old.Entity = newLink_.Entity;
        }
        #endregion
    }
}
