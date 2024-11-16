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

        public Domain()
        {
            Id = Guid.NewGuid();
            Values = new();
        }
    }
}