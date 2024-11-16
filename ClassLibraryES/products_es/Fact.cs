using System;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Факт продукционной системы
    /// </summary>
    public class Fact
    {
        /// <summary>
        /// Уникальный идентификатор факта
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Переменная факта
        /// </summary>
        public Variable Variable { get; set; }

        /// <summary>
        /// Значение переменной
        /// </summary>
        public string Value { get; set; }

        public Fact()
        {
            Id = Guid.NewGuid();
        }

        public Fact(Variable variable, string value)
        {
            Id = Guid.NewGuid();
            Variable = variable;
            Value = value;
        }


        //public override bool Equals(object obj)
        //{
        //    if (obj is Fact other)
        //    {
        //        return Variable.Id == other.Variable.Id && Value == other.Value;
        //    }
        //    return false;
        //}

    }
}