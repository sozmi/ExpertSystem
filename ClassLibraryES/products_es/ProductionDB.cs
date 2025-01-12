using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibraryES.Managers;
namespace ClassLibraryES.Products
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
        /// Словарь доменов
        /// </summary>
        public Dictionary<Guid, Domain> Domains { get; set; } = [];

        /// <summary>
        /// Словарь переменных
        /// </summary>
        public Dictionary<Guid, Variable> Variables { get; set; } = [];

        /// <summary>
        /// Словарь фактов
        /// </summary>
        public Dictionary<Guid, Fact> Facts { get; set; } = [];

        /// <summary>
        /// Словарь правил
        /// </summary>
        public Dictionary<Guid, Rule> Rules { get; set; } = [];

        #region Операции с доменами
        /// <summary>
        /// Получить домен по идентификатору
        /// </summary>
        public Domain? GetDomain(Guid id)
        {
            return Domains.TryGetValue(id, out Domain? domain) ? domain : null;
        }

        /// <summary>
        /// Добавить новый домен
        /// </summary>
        public void AddDomain(Domain domain)
        {
            Domains.Add(domain.Id, domain);
        }

        /// <summary>
        /// Обновить существующий домен
        /// </summary>
        public void UpdateDomain(Domain newDomain)
        {
            if (!Domains.ContainsKey(newDomain.Id))
                return;

            var oldDomain = Domains[newDomain.Id];
            var oldValues = new HashSet<string>(oldDomain.Values);
            var newValues = new HashSet<string>(newDomain.Values);

            var addedValues = newValues.Except(oldValues).ToList();
            var removedValues = oldValues.Except(newValues).ToList();

            // Обновляем значения существующего домена вместо замены объекта
            oldDomain.Name = newDomain.Name;
            oldDomain.Values.Clear();
            oldDomain.Values.AddRange(newDomain.Values);

            // Находим все переменные, использующие этот домен
            var affectedVariables = Variables.Values.Where(v => v.Domain?.Id == newDomain.Id);

            foreach (var variable in affectedVariables)
            {
                // Добавляем новые факты для новых значений
                foreach (var value in addedValues)
                {
                    var newFact = new Fact(variable, value);
                    Facts.Add(newFact.Id, newFact);
                }

                // Удаляем факты для удаленных значений
                var factsToRemove = Facts.Values
                    .Where(f => f.Variable?.Id == variable.Id &&
                           removedValues.Contains(f.Value ?? string.Empty))
                    .ToList();

                foreach (var fact in factsToRemove)
                {
                    Facts.Remove(fact.Id);
                }
            }
        }

        /// <summary>
        /// Удалить домен по идентификатору
        /// </summary>
        public void DeleteDomain(Guid id)
        {
            if (!Domains.ContainsKey(id))
                return;

            // Удаляем все факты, связанные с переменными этого домена
            var factsToRemove = Facts.Values
                .Where(f => f.Variable?.Domain?.Id == id)
                .ToList();

            foreach (var fact in factsToRemove)
            {
                Facts.Remove(fact.Id);
            }

            Domains.Remove(id);
        }
        #endregion

        #region Операции с переменными
        /// <summary>
        /// Получить переменную по идентификатору
        /// </summary>
        public Variable? GetVariable(Guid id)
        {
            return Variables.TryGetValue(id, out Variable? variable) ? variable : null;
        }

        /// <summary>
        /// Добавить новую переменную
        /// </summary>
        public void AddVariable(Variable variable)
        {
            Variables.Add(variable.Id, variable);
        }

        /// <summary>
        /// Обновить существующую переменную
        /// </summary>
        public void UpdateVariable(Variable newVariable)
        {
            if (!Variables.ContainsKey(newVariable.Id))
                return;

            var existingVariable = Variables[newVariable.Id];
            existingVariable.Update(newVariable.Name, newVariable.Domain);
        }

        /// <summary>
        /// Удалить переменную по идентификатору
        /// </summary>
        public void DeleteVariable(Guid id)
        {
            if (!Variables.ContainsKey(id))
                return;

            // Удаляем все факты этой переменной
            var factsToRemove = Facts.Values
                .Where(f => f.Variable?.Id == id)
                .ToList();

            foreach (var fact in factsToRemove)
            {
                Facts.Remove(fact.Id);
            }

            Variables.Remove(id);
        }
        #endregion

        #region Операции с правилами
        /// <summary>
        /// Получить правило по идентификатору
        /// </summary>
        public Rule? GetRule(Guid id)
        {
            return Rules.TryGetValue(id, out Rule? rule) ? rule : null;
        }

        /// <summary>
        /// Добавить новое правило
        /// </summary>
        public void AddRule(Rule rule)
        {
            Rules.Add(rule.Id, rule);
        }

        /// <summary>
        /// Обновить существующее правило
        /// </summary>
        public void UpdateRule(Rule newRule)
        {
            if (!Rules.ContainsKey(newRule.Id))
                return;

            var existingRule = Rules[newRule.Id];
            existingRule.Update(newRule.Name, newRule.Result, newRule.Premises);
        }

        /// <summary>
        /// Удалить правило по идентификатору
        /// </summary>
        public void DeleteRule(Guid id)
        {
            Rules.Remove(id);
        }
        #endregion

        #region Получение списков
        /// <summary>
        /// Получить все факты
        /// </summary>
        public List<Fact> GetAllFacts()
        {
            return new List<Fact>(Facts.Values);
        }

        /// <summary>
        /// Получить все домены
        /// </summary>
        public List<Domain> GetAllDomains()
        {
            return new List<Domain>(Domains.Values);
        }

        /// <summary>
        /// Получить все правила
        /// </summary>
        public List<Rule> GetAllRules()
        {
            return new List<Rule>(Rules.Values);
        }
        #endregion

        #region IKnowledgeBase
        public bool Open()
        {
            return true;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}