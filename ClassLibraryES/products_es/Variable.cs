using System;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Переменная продукционной системы
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Уникальный идентификатор переменной
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Наименование переменной
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Домен переменной
        /// </summary>
        public Domain Domain { get; set; }

        public Variable()
        {
            Id = Guid.NewGuid();
        }

        public Variable(string name, Domain domain)
        {
            Id = Guid.NewGuid();
            Name = name;
            Domain = domain;
        }
    }
}