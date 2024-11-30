using Newtonsoft.Json;

namespace ClassLibraryES.semantic_es
{
    /// <summary>
    /// Класс с информацией о связи между сущностями
    /// </summary>
    public class Link
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Тип связи
        /// </summary>
        [JsonIgnore]
        public RelationType Relation { get; set; } = new("Связь не указана");

        /// <summary>
        /// Вопрос
        /// </summary>
        public string Explanation { get; set; } = "Неизвестно";

        /// <summary>
        /// Подчиненная сущность
        /// </summary>
        [JsonIgnore]
        public Entity Entity { get; set; } = new("Сущность не выбрана");

        /// <summary>
        /// Создание пустой связи
        /// </summary>
        public Link()
        {
        }

        /// <summary>
        /// Создание связи с известными параметрами
        /// </summary>
        /// <param name="relation">Тип связи</param>
        /// <param name="entity">Подчиненная сущность</param>
        public Link(RelationType relation, Entity entity)
        {
            Relation = relation;
            Entity = entity;
        }

        /// <summary>
        /// Получение пары идентификаторов (сущность, тип связи)
        /// </summary>
        /// <returns>Ключ отношения</returns>
        public KeyRelative GetKey() => new(Entity.Id, Relation.Id); 
    }
}
