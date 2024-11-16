
using System.Text.Json.Serialization;

namespace ClassLibraryES.semantic_es
{
    public class Association
    {
        public Association(RelationType relation)
        {
            Relation = relation;
        }

        public RelationType Relation { get; set; }

        /// <summary>
        /// Словарь связанных сущностей [id сущности] = сущность
        /// </summary>
        public Dictionary<Guid, Entity> Entities { get; set; } = [];

        /// <summary>
        /// Добавление ассоциативной сущности
        /// </summary>
        /// <param name="item">Сущность</param>
        public void Add(Entity item)
        {
            Entities.Add(item.Id, item);
        }

        /// <summary>
        /// Удаление ассоциативной сущности
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        internal void Remove(Guid id)
        {
            Entities.Remove(id);
        }
    }
}
