using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json; // Подключаем библиотеку для работы с JSON

namespace ExpertSystem.Managers
{
    /// <summary>
    /// Класс для управления базой знаний экспертной системы.
    /// </summary>
    public class KnowledgeBaseManager
    {
        private readonly string _pathToDirectory;   // Путь к директории, где хранятся файлы баз знаний
        private readonly string _expertSystemName;  // Имя текущей экспертной системы

        // Список для хранения баз знаний
        private List<IKnowledgeBase> _knowledgeBases = new List<IKnowledgeBase>();

        /// <summary>
        /// Конструктор класса KnowledgeBaseManager.
        /// </summary>
        /// <param name="pathToDirectory">Путь к директории с базами знаний.</param>
        /// <param name="expertSystemName">Имя экспертной системы.</param>
        public KnowledgeBaseManager(string pathToDirectory, string expertSystemName)
        {
            _pathToDirectory = pathToDirectory;
            _expertSystemName = expertSystemName;
        }

        /// <summary>
        /// Создает новую базу знаний.
        /// </summary>
        /// <param name="name">Имя создаваемой базы знаний.</param>
        public void Create(string name)
        {
            var filePath = Path.Combine(_pathToDirectory, $"{name}.json"); // Формируем путь до файла

            if (!File.Exists(filePath)) // Проверяем существование файла
            {
                // Если файл не существует, создаем новый JSON-файл
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    var jsonData = new
                    {
                        Name = name,
                        Knowledges = new List<string>()
                    };

                    // Сериализуем объект в JSON и записываем в файл
                    sw.Write(JsonConvert.SerializeObject(jsonData, Formatting.Indented));
                }

                Console.WriteLine($"Файл создан: {filePath}");
            }
            else
            {
                Console.WriteLine("Файл уже существует.");
            }
        }

        /// <summary>
        /// Загружает данные из указанного файла.
        /// </summary>
        /// <param name="name">Имя базы знаний для загрузки.</param>
        public void Load(string name)
        {
            var filePath = Path.Combine(_pathToDirectory, $"{name}.json");

            if (File.Exists(filePath)) // Проверка существования файла
            {
                // Читаем содержимое файла
                string jsonContent = File.ReadAllText(filePath);

                try
                {
                    // Десериализация JSON в динамический объект
                    dynamic data = JsonConvert.DeserializeObject(jsonContent);

                    // Обработка загруженных данных
                    Console.WriteLine($"Загружена база знаний: {data.Name}");
                    foreach (var knowledge in data.Knowledges)
                    {
                        Console.WriteLine(knowledge); // Выводим каждое знание
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        /// <summary>
        /// Сохраняет изменения в базе знаний.
        /// </summary>
        public void Save()
        {
            var filePath = Path.Combine(_pathToDirectory, $"{_expertSystemName}.json");

            if (File.Exists(filePath)) // Проверка существования файла
            {
                // Создаем объект для записи в файл
                var jsonData = new
                {
                    Name = _expertSystemName,
                    Knowledges = new List<string>() // Здесь должны быть реальные знания
                };

                // Запись данных в файл
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(JsonConvert.SerializeObject(jsonData, Formatting.Indented));
                }

                Console.WriteLine($"Файл сохранен: {filePath}");
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
    }
}