using System;
using System.Collections.Generic;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Правило продукционной системы - состоит из списка фактов-предпосылок
    /// и одного факта-результата
    /// </summary>
    public class Rule
    {
        /// <summary>
        /// Уникальный идентификатор правила.
        /// Генерируется автоматически при создании правила.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Наименование правила.
        /// Nullable, так как может быть установлено после создания объекта.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Список фактов-предпосылок, которые должны быть истинны 
        /// для срабатывания правила.
        /// </summary>
        public List<Fact> Premises { get; private set; }

        /// <summary>
        /// Факт-результат, который становится истинным при срабатывании правила.
        /// Nullable, так как может быть установлен после создания объекта.
        /// </summary>
        public Fact? Result { get; set; }

        public Rule()
        {
            Id = Guid.NewGuid();
            Premises = new();
        }

        /// <summary>
        /// Добавляет новый факт-предпосылку в правило.
        /// Предпосылка добавляется только если она еще не существует в списке.
        /// </summary>
        /// <param name="premise">Факт-предпосылка</param>
        public void AddPremise(Fact premise)
        {
            if (!Premises.Contains(premise))
            {
                Premises.Add(premise);
            }
        }

        /// <summary>
        /// Проверяет, выполняются ли все предпосылки правила
        /// в заданном наборе фактов.
        /// </summary>
        /// <param name="facts">Набор фактов для проверки</param>
        /// <returns>true, если все предпосылки найдены в наборе фактов; иначе false</returns>
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