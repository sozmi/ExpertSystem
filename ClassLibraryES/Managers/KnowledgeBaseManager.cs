// Managers/KnowledgeBaseManager.cs
using System;
using System.IO;
using System.Collections.Generic;

namespace ExpertSystem.Managers
{
    public class KnowledgeBaseManager
    {
        private string _pathToDirectory;
        private string _expertSystemName;

        // Список для хранения баз знаний
        private List<IKnowledgeBase> _knowledgeBases = new List<IKnowledgeBase>();

        // Конструктор
        public KnowledgeBaseManager(string pathToDirectory, string expertSystemName)
        {
            _pathToDirectory = pathToDirectory;
            _expertSystemName = expertSystemName;
        }

        // Метод создания новой базы знаний
        public void Create(string path, string name)
        {
            var filePath = Path.Combine(_pathToDirectory, $"{name}.txt");

            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("{");
                    sw.WriteLine($"\"name\": \"{name}\",");
                    sw.WriteLine("\"knowledges\": []");
                    sw.WriteLine("}");
                }
                Console.WriteLine($"Файл создан: {filePath}");
            }
            else
            {
                Console.WriteLine("Файл уже существует.");
            }
        }

        // Метод загрузки данных из файла
        public void Load(string path)
        {
            var filePath = Path.Combine(_pathToDirectory, $"{_expertSystemName}.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    // Здесь можно добавить логику обработки каждой строки
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }

        // Метод сохранения изменений в файле
        public void Save()
        {
            var filePath = Path.Combine(_pathToDirectory, $"{_expertSystemName}.txt");

            if (File.Exists(filePath))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("{");
                    sw.WriteLine($"\"name\": \"{_expertSystemName}\",");
                    sw.WriteLine("\"knowledges\": []");
                    sw.WriteLine("}");
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