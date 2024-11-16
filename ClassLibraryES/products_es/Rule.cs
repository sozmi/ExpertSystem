using System;
using System.Collections.Generic;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Правило продукционной системы
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Уникальный идентификатор правила
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Наименование правила
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список фактов-предпосылок
        /// </summary>
        public List<Fact> Premises { get; private set; }

        /// <summary>
        /// Факт-результат
        /// </summary>
        public Fact Result { get; set; }

        public Rule()
        {
            Id = Guid.NewGuid();
            Premises = new();
        }

        public Rule(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        /// <summary>
        /// Добавить факт-предпосылку
        /// </summary>
        public void AddPremise(Fact premise)
        {
            if (!Premises.Contains(premise))
            {
                Premises.Add(premise);
            }
        }

        /// <summary>
        /// Проверить, выполняются ли все предпосылки
        /// </summary>
        public bool CheckPremises(ICollection<Fact> facts)
        {
            foreach (var premise in Premises)
            {
                if (!facts.Contains(premise))
                    return false;
            }
            return true;
        }
    }
}