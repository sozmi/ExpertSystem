using ClassLibraryES.frame_es;
using ClassLibraryES.semantic_es;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;

namespace ClassLibraryES.Managers
{
    public class KnowledgeBaseManager : IModelChanged
    {
        public string PATH_TO_DIR = "";
        public string PATH_TO_FILE = "";
        private static KnowledgeBaseManager? knowledgeBaseManager = null;
        // Список для хранения баз знаний
        private string NameES { get; set; } = "";
        private object?[] Bases = new object?[4];
        private bool _changesMade = false;
        private bool _loaded = false;

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

        public void Create(string name)
        {
            PATH_TO_FILE = Path.Combine(PATH_TO_DIR, $"{name}.es");

            if (File.Exists(PATH_TO_FILE))
                throw new FileLoadException("Такая экспертная система уже существует");

            NameES = name;
            Save();
            _loaded = true;
        }

        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Указанный файл не найден");

            string jsonContent = File.ReadAllText(filePath);
            dynamic? data = JsonConvert.DeserializeObject(jsonContent) ?? throw new FileLoadException("Ошибка в формате данных");
            NameES = data.Name;
            for (int i = (int)ETypeDB.eLogical; i < (int)ETypeDB.eCommonCount; i++)
            {
                Bases[i] = GetBase((ETypeDB)i, data.KnowledgeBases[i]);
                (Bases[i] as IKnowledgeBase)?.Open();
            }
            _loaded = true;
        }

        public void Save()
        {
            using StreamWriter sw = File.CreateText(PATH_TO_FILE);
            var jsonData = new
            {
                Name = NameES,
                KnowledgeBases = Bases
            };

            sw.Write(JsonConvert.SerializeObject(jsonData, Formatting.Indented));
            _changesMade = false;
        }

        public T? GetBase<T>() where T : class
        {
            foreach (var db in Bases)
                if (db is T)
                    return db as T;
            return null;
        }

        public void OnGlobalChanged()
        {
            _changesMade = true;
        }

        public void Close()
        {
            foreach (object? baseObj in Bases)
            {
                if (baseObj is IKnowledgeBase kb)
                {
                    kb.Close();
                }
            }
            _loaded = false;
        }

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