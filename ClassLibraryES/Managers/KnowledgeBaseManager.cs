using ClassLibraryES.frame_es;
using ClassLibraryES.semantic_es;
using Newtonsoft.Json;
using System.Reflection;

namespace ClassLibraryES.Managers
{
    /// <summary>
    /// Класс для управления базой знаний экспертной системы.
    /// </summary>
    public class KnowledgeBaseManager
    {
        public string PATH_TO_DIR = "";
        public string PATH_TO_FILE = "";
        private static KnowledgeBaseManager? knowledgeBaseManager = null;
        // Список для хранения баз знаний
        private string NameES { get; set; } = "";
        private object?[] Bases = new object?[4]; //TODO: удалить неопределенность
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
        private KnowledgeBaseManager()
        {
            Bases[(int)ETypeDB.eLogical] = null;
            Bases[(int)ETypeDB.eProducts] = null;
            Bases[(int)ETypeDB.eSemantic] = new SemanticDB(true);
            Bases[(int)ETypeDB.eFrame] = new FrameDB();

            PATH_TO_DIR = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Экспертные системы";
            Directory.CreateDirectory(PATH_TO_DIR);
        }


        public static KnowledgeBaseManager Get()
        {
            knowledgeBaseManager ??= new();
            return knowledgeBaseManager;
        }

        /// <summary>
        /// Создает новую базу знаний.
        /// </summary>
        /// <param name="name">Имя создаваемой базы знаний.</param>
        public void Create(string name)
        {
            PATH_TO_FILE = Path.Combine(PATH_TO_DIR, $"{name}.es"); // Формируем путь до файла
            
            if (File.Exists(PATH_TO_FILE))
                throw new FileLoadException("Такая экспертная система уже существует");

            // Если файл не существует, сохраняем
            NameES = name;
            Save();
        }

        /// <summary>
        /// Загружает данные из указанного файла.
        /// </summary>
        /// <param name="name">Имя базы знаний для загрузки.</param>
        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Указанный файл не найден");

            // Читаем содержимое файла
            string jsonContent = File.ReadAllText(filePath);
            // Десериализация JSON в динамический объект
            dynamic? data = JsonConvert.DeserializeObject(jsonContent) ?? throw new FileLoadException("Ошибка в формате данных");
            NameES = data.Name;
            for(int i = (int)ETypeDB.eLogical; i < (int)ETypeDB.eCommonCount; i++ )
            {
                Bases[i] = GetBase((ETypeDB)i, data.KnowledgeBases[i]);
                (Bases[i] as IKnowledgeBase)?.Open();
            }
        }

        /// <summary>
        /// Сохраняет изменения в базе знаний.
        /// </summary>
        public void Save()
        {
            using StreamWriter sw = File.CreateText(PATH_TO_FILE);
            var jsonData = new
            {
                Name = NameES,
                KnowledgeBases = Bases
            };

            // Сериализуем объект в JSON и записываем в файл
            sw.Write(JsonConvert.SerializeObject(jsonData, Formatting.Indented));
        }

        public T? GetBase<T>() where T : class
        {
            foreach (var db in Bases)
                if (db is T)
                    return db as T;
            return null;
        }
    }
}