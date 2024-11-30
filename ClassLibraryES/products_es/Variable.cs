using System;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Переменная продукционной системы - описывает характеристику или свойство,
    /// которое может принимать значения из определенного домена
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Уникальный идентификатор переменной.
        /// Генерируется автоматически при создании переменной.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Наименование переменной.
        /// Nullable, так как может быть установлено после создания объекта.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Домен переменной - множество допустимых значений.
        /// Nullable, так как может быть установлен после создания объекта.
        /// </summary>
        public Domain? Domain { get; set; }

        public Variable()
        {
            Id = Guid.NewGuid();
        }
    }
}