﻿using ClassLibraryES.Managers;
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
                RelationType it = new("это");
                Create(it);
                it = Relations[it.Id];

                RelationType can = new("может");
                Create(can);
                can = Relations[can.Id];

                RelationType has = new("имеет");
                Create(has);
                has = Relations[has.Id];

                Entity fly = new("Летать");
                Create(fly);
                fly = Entities[fly.Id];

                Entity wings = new("Крылья");
                Create(wings);
                wings = Entities[wings.Id];

                Entity paws = new("Лапы");
                Create(paws);
                paws = Entities[paws.Id];

                Entity bird = new("Птица");
                Entities.Add(bird.Id, bird);
                bird = Entities[bird.Id];


                Entity sneg = new("Снегирь");
                Entities.Add(sneg.Id, sneg);

                AddLink(new(sneg.Id, bird.Id, it.Id));
                AddLink(new(bird.Id, fly.Id, can.Id));
                AddLink(new(bird.Id, sneg.Id, it.Id));
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
        public void Edit(Entity newObj_)
        {
            Entities[newObj_.Id] = newObj_;
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
        #endregion
    }
}
