using System;
using System.Collections.Generic;
using ClassLibraryES.Managers;

namespace ClassLibraryES.products_es
{
    /// <summary>
    /// Продукционная база знаний - хранилище всех элементов 
    /// продукционной системы (доменов, переменных, фактов, правил)
    /// </summary>
    public class ProductionDB : IKnowledgeBase
    {
        public ProductionDB() { }

        public ProductionDB(bool isTest = false)
        {
            if (isTest)
            {
                // Создаем домены
                Domain colorDomain = new("Цвет");
                colorDomain.Values.Add("красный");
                colorDomain.Values.Add("серый");
                Domains.Add(colorDomain.Id, colorDomain);

                Domain sizeDomain = new("Размер");
                sizeDomain.Values.Add("маленький");
                sizeDomain.Values.Add("средний");
                Domains.Add(sizeDomain.Id, sizeDomain);

                // Создаем переменные
                Variable birdColor = new() { Name = "Цвет птицы", Domain = colorDomain };
                Variables.Add(birdColor.Id, birdColor);

                Variable birdSize = new() { Name = "Размер птицы", Domain = sizeDomain };
                Variables.Add(birdSize.Id, birdSize);

                // Создаем факты
                Fact colorFact = new()
                {
                    Variable = birdColor,
                    Value = "красный"
                };
                Facts.Add(colorFact.Id, colorFact);

                Fact sizeFact = new()
                {
                    Variable = birdSize,
                    Value = "маленький"
                };
                Facts.Add(sizeFact.Id, sizeFact);

                // Создаем правило: ЕСЛИ (цвет красный И размер маленький) ТО это снегирь
                Rule birdRule = new() { Name = "Определение снегиря" };
                birdRule.Premises.Add(colorFact);
                birdRule.Premises.Add(sizeFact);

                Domain birdDomain = new("Птица");
                birdDomain.Values.Add("снегирь");
                Domains.Add(birdDomain.Id, birdDomain);

                Variable birdType = new() { Name = "Вид птицы", Domain = birdDomain };
                Variables.Add(birdType.Id, birdType);

                birdRule.Result = new Fact()
                {
                    Variable = birdType,
                    Value = "снегирь"
                };
                Rules.Add(birdRule.Id, birdRule);
            }
        }

        /// <summary>
        /// Словарь всех доменов.
        /// Ключ - уникальный идентификатор домена, значение - объект домена
        /// </summary>
        public Dictionary<Guid, Domain> Domains { get; set; } = [];

        /// <summary>
        /// Словарь всех переменных.
        /// Ключ - уникальный идентификатор переменной, значение - объект переменной
        /// </summary>
        public Dictionary<Guid, Variable> Variables { get; set; } = [];

        /// <summary>
        /// Словарь всех фактов.
        /// Ключ - уникальный идентификатор факта, значение - объект факта
        /// </summary>
        public Dictionary<Guid, Fact> Facts { get; set; } = [];

        /// <summary>
        /// Словарь всех правил.
        /// Ключ - уникальный идентификатор правила, значение - объект правила
        /// </summary>
        public Dictionary<Guid, Rule> Rules { get; set; } = [];

        #region IKnowledgeBase
        public bool Open()
        {
            return true;
        }

        public void Close()
        {
            return;
        }
        #endregion
    }
}