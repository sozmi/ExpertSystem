namespace ClassLibraryES.semantic_es
{
    /// <summary>
    /// Класс с информацией о видах связи
    /// </summary>
    public class RelationType
    {
        /// <summary>
        /// Создание пустой связи с уникальным id
        /// </summary>
        public RelationType()
        {
            Id = Guid.NewGuid();
            Name = "";
            QuestionFrom = "";
            QuestionTo = "";
        }

        /// <summary>
        /// Создание связи с известными параметрами и уникальным id
        /// </summary>
        /// <param name="name">Наименование связи</param>
        public RelationType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            QuestionFrom = "";
            QuestionTo = "";
        }

        /// <summary>
        /// Создание связи с известными параметрами и уникальным id
        /// </summary>
        /// <param name="name">Наименование связи</param>
        /// <param name="question">Вопрос для связи</param>
        public RelationType(string name, string question)
        {
            Id = Guid.NewGuid();
            Name = name;
            QuestionFrom = "";
            QuestionTo = "";
        }

        /// <summary>
        /// Создание связи с известными параметрами
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <param name="Name">Наименование</param>
        public RelationType(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            this.QuestionFrom = "";
            this.QuestionTo = "";
        }

        /// <summary>
        /// Идентификатор связи
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Наименование связи
        /// </summary>
        public string Name { get; set; }
        public string QuestionFrom { get; set; }
        public string QuestionTo { get; set; }
    }
}
