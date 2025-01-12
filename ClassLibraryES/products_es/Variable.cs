using System;
namespace ClassLibraryES.Products
{
    public class Variable
    {
        public Guid Id { get; private set; }
        public string? Name { get; set; }
        public Domain? Domain { get; set; }

        public Variable()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Обновляет свойства переменной
        /// </summary>
        public void Update(string? name, Domain? domain)
        {
            Name = name;
            Domain = domain;
        }
    }
}