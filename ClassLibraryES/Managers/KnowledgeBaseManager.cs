using ClassLibraryES.frame_es;
using ClassLibraryES.semantic_es;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Linq;

namespace ClassLibraryES.Managers
{
    /// <summary>
    /// Класс для управления базой знаний экспертной системы.
    /// </summary>
    public class KnowledgeBaseManager
    {
        public string PATH_TO_DIR;
        private static KnowledgeBaseManager? knowledgeBaseManager = null;
        // Список для хранения баз знаний
        private string NameES { get; set; } = "";
        private object?[] Bases = new object?[4]; //TODO: удалить неопределенность

        private KnowledgeBaseManager()
        {
            Bases[(int)ETypeDB.eLogical] = null;
            Bases[(int)ETypeDB.eProducts] = null;
            Bases[(int)ETypeDB.eSemantic] = new SemanticDB(true);//TODO: это тест удалить true
            Bases[(int)ETypeDB.eFrame] = null;

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
            var filePath = Path.Combine(PATH_TO_DIR, $"{name}.es"); // Формируем путь до файла

            if (File.Exists(filePath)) // Проверяем существование файла
                throw new FileLoadException("Такая экспертная система уже существует");

            // Если файл не существует, сохраняем
            NameES = name;
            Save(filePath);
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
            int i = 0;
            foreach (var knowledge in data.Knowledges)
                Bases[i] = knowledge;
        }

        /// <summary>
        /// Сохраняет изменения в базе знаний.
        /// </summary>
        public void Save(string filePath)
        {
            using StreamWriter sw = File.CreateText(filePath);
            var jsonData = new
            {
                Name = NameES,
                Knowledges = Bases
            };

            // Сериализуем объект в JSON и записываем в файл
            sw.Write(JsonConvert.SerializeObject(jsonData, Formatting.Indented));
        }
    }
}