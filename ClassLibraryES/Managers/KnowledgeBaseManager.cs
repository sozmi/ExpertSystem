using ClassLibraryES.frame_es;
using ClassLibraryES.Products;
using ClassLibraryES.products_es;
using ClassLibraryES.semantic_es;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace ClassLibraryES.Managers
{
    /// <summary>
    /// Класс для управления базой знаний экспертной системы.
    /// </summary>
    public class KnowledgeBaseManager : IModelChanged
    {
        /// <summary>
        /// Путь к директории, где хранятся файлы экспертных систем.
        /// </summary>
        public string PATH_TO_DIR = "";

        /// <summary>
        /// Путь к файлу текущей экспертной системы.
        /// </summary>
        public string PATH_TO_FILE = "";

        /// <summary>
        /// Экземпляр класса KnowledgeBaseManager, который создается и используется только один раз (синглтон).
        /// </summary>
        private static KnowledgeBaseManager? knowledgeBaseManager = null;

        // Список для хранения баз знаний

        /// <summary>
        /// Имя текущей экспертной системы.
        /// </summary>
        private string NameES { get; set; } = "";

        /// <summary>
        /// Список для хранения различных баз знаний.
        /// </summary>
        private object?[] Bases = new object?[4];

        /// <summary>
        /// Флаг, показывающий, были ли сделаны изменения.
        /// </summary>
        private bool _changesMade;

        /// <summary>
        /// Флаг, показывающий, загружена ли текущая база знаний.
        /// </summary>
        private bool _loaded;

        /// <summary>
        /// Свойство, отражающее состояние изменений в базе знаний.
        /// </summary>
        public bool ChangesMade => _changesMade;

        /// <summary>
        /// Свойство, отражающее состояние загрузки базы знаний.
        /// </summary>
        public bool Loaded => _loaded;

        /// <summary>
        /// Конструктор класса, инициализирующий базовые объекты.
        /// </summary>
        private KnowledgeBaseManager()
        {
            // Инициализация баз знаний
            Bases[(int)ETypeDB.eLogical] = null;
            Bases[(int)ETypeDB.eProducts] = new ProductionDB(true); //Продукционая база знаний
            Bases[(int)ETypeDB.eSemantic] = new SemanticDB(true);   //Логическая база знаний
            Bases[(int)ETypeDB.eFrame] = new FrameDB();             //Фреймовая база знаний

            // Определение пути к папке для хранения экспертных систем
            PATH_TO_DIR = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Экспертные системы";
            Directory.CreateDirectory(PATH_TO_DIR); // Создаем директорию, если ее нет
        }

        /// <summary>
        /// Метод для получения синглтонного экземпляра менеджера базы знаний.
        /// </summary>
        /// <returns>Экземпляр класса KnowledgeBaseManager.</returns>
        public static KnowledgeBaseManager Get()
        {
            // Ленивая инициализация синглтонна(создаётся не в самом начале, а лишь когда будет получено первое обращение к нему)
            knowledgeBaseManager ??= new();
            return knowledgeBaseManager;
        }

        /// <summary>
        /// Метод для создания новой экспертной системы.
        /// </summary>
        /// <param name="name">Имя создаваемой экспертной системы.</param>
        public void Create(string name)
        {
            // Формируем путь к новому файлу экспертной системы
            PATH_TO_FILE = Path.Combine(PATH_TO_DIR, $"{name}.es");

            // Проверяем, существует ли такой файл
            if (File.Exists(PATH_TO_FILE))
                throw new FileLoadException("Такая экспертная система уже существует");

            // Устанавливаем имя экспертной системы и сохраняем её
            NameES = name;
            Save();
            _loaded = true;
        }

        /// <summary>
        /// Метод для загрузки существующей экспертной системы из файла.
        /// </summary>
        /// <param name="filePath">Путь к файлу экспертной системы.</param>
        public void Load(string filePath)
        {
            // Проверка существования файла
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Указанный файл не найден");

            // Чтение содержимого файла
            string jsonContent = File.ReadAllText(filePath);
            dynamic? data = JsonConvert.DeserializeObject(jsonContent) ?? throw new FileLoadException("Ошибка в формате данных");

            // Получение имени экспертной системы из JSON
            NameES = data.Name;

            // Загрузка баз знаний из JSON
            for (int i = (int)ETypeDB.eLogical; i < (int)ETypeDB.eCommonCount; i++)
            {
                Bases[i] = GetBase((ETypeDB)i, data.KnowledgeBases[i]);
                (Bases[i] as IKnowledgeBase)?.Open(); // Открытие базы знаний, если возможно
            }
            _loaded = true;
        }

        /// <summary>
        /// Метод для сохранения текущей экспертной системы в файл.
        /// </summary>
        public void Save()
        {
            using StreamWriter sw = File.CreateText(PATH_TO_FILE);
            var jsonData = new
            {
                Name = NameES,
                KnowledgeBases = Bases
            };

            // Запись данных в файл в формате JSON
            sw.Write(JsonConvert.SerializeObject(jsonData, Formatting.Indented));
            _changesMade = false;
        }

        /// <summary>
        /// Метод для получения конкретной базы знаний по типу.
        /// </summary>
        /// <typeparam name="T">Тип базы знаний.</typeparam>
        /// <returns>База знаний указанного типа, либо null, если не найдена.</returns>
        public T? GetBase<T>() where T : class
        {
            foreach (var db in Bases)
                if (db is T)
                    return db as T;
            return null;
        }

        /// <summary>
        /// Метод для обработки глобальных изменений в системе.
        /// </summary>
        public void OnGlobalChanged()
        {
            _changesMade = true;
        }

        /// <summary>
        /// Метод для закрытия всех открытых баз знаний.
        /// </summary>
        public void Close()
        {
            foreach (object? baseObj in Bases)
            {
                if (baseObj is IKnowledgeBase kb)
                {
                    kb.Close(); // Закрываем базу знаний, если она поддерживает закрытие
                }
            }
            _loaded = false;
        }

        /// <summary>
        /// Внутренний метод для преобразования динамического объекта в нужную базу знаний.
        /// </summary>
        /// <param name="eType">Тип базы знаний.</param>
        /// <param name="db">Динамический объект, содержащий данные базы знаний.</param>
        /// <returns>Объект соответствующей базы знаний.</returns>
        private static object GetBase(ETypeDB eType, dynamic db)
        {
            switch (eType)
            {
                case ETypeDB.eLogical:
                case ETypeDB.eProducts:
                    return db.ToObject<object>();
                case ETypeDB.eSemantic:
                    return db.ToObject<SemanticDB>();
                case ETypeDB.eFrame:
                    return db.ToObject<FrameDB>();
                case ETypeDB.eCommonCount:
                default:
                    throw new ArgumentException("Не указан тип базы знаний или дошли до конца перечисления.");
            }
        }
    }
}