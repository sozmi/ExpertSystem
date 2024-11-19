using System;
using System.Collections.Generic;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Домен - множество допустимых значений для переменной
    /// </summary>
    public class Domain
    {
        /// <summary>
        /// Уникальный идентификатор домена
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Наименование домена
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список допустимых значений домена
        /// </summary>
        public List<string> Values { get; private set; }

        /// <summary>
        /// Создает новый экземпляр домена с указанным именем
        /// </summary>
        /// <param name="name">Имя домена</param>
        /// <exception cref="ArgumentException">Выбрасывается, если имя пустое или null</exception>
        public Domain(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));

            Id = Guid.NewGuid();
            Name = name;
            Values = new();
        }
    }
}