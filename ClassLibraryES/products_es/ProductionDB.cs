using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibraryES.Managers;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Продукционная база знаний
    /// </summary>
    public class ProductionDB : IKnowledgeBase
    {
        /// <summary>
        /// Словарь всех доменов
        /// </summary>
        public Dictionary<Guid, Domain> Domains { get; set; } = [];

        /// <summary>
        /// Словарь всех переменных
        /// </summary>
        public Dictionary<Guid, Variable> Variables { get; set; } = [];

        /// <summary>
        /// Словарь всех фактов
        /// </summary>
        public Dictionary<Guid, Fact> Facts { get; set; } = [];

        /// <summary>
        /// Словарь всех правил
        /// </summary>
        public Dictionary<Guid, Rule> Rules { get; set; } = [];

        /// <summary>
        /// Рабочая память для механизма вывода
        /// </summary>
        //private List<Fact> workingMemory;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public ProductionDB()
        {
        }

        #region IKnowledgeBase
        public bool Open()//удалить
        {
            return true;
        }

        //public void Close()//удалить
        //{
        //    Domains.Clear();
        //    Variables.Clear();
        //    Facts.Clear();
        //    Rules.Clear();
        //    workingMemory.Clear();
        //}
        //#endregion

        //#region Методы для работы с рабочей памятью  // удалить
        ///// <summary>
        ///// Добавить факт в рабочую память
        ///// </summary>
        //public void AddFactToWorkingMemory(Fact fact)
        //{
        //    if (!workingMemory.Contains(fact))
        //    {
        //        workingMemory.Add(fact);
        //    }
        //}

        ///// <summary>
        ///// Очистить рабочую память // удалить
        ///// </summary>
        //public void ClearWorkingMemory()
        //{
        //    workingMemory.Clear();
        //}
        //#endregion

        //    #region Прямой вывод
        //    /// <summary>
        //    /// Выполнить прямой вывод на основе фактов в рабочей памяти
        //    /// </summary>
        //    public List<Fact> ForwardChaining()
        //    {
        //        List<Fact> newFacts = new List<Fact>();
        //        bool changed;

        //        do
        //        {
        //            changed = false;
        //            foreach (var rule in Rules.Values)
        //            {
        //                if (!workingMemory.Contains(rule.Result))
        //                {
        //                    if (rule.CheckPremises(workingMemory))
        //                    {
        //                        workingMemory.Add(rule.Result);
        //                        newFacts.Add(rule.Result);
        //                        changed = true;
        //                    }
        //                }
        //            }
        //        } while (changed);

        //        return newFacts;
        //    }
        //    #endregion

        //    #region Обратный вывод
        //    /// <summary>
        //    /// Выполнить обратный вывод для достижения целевого факта
        //    /// </summary>
        //    public bool BackwardChaining(Fact goalFact)
        //    {
        //        if (workingMemory.Contains(goalFact))
        //            return true;

        //        var relevantRules = Rules.Values.Where(r => r.Result.Equals(goalFact)).ToList();

        //        foreach (var rule in relevantRules)
        //        {
        //            bool allPremisesTrue = true;
        //            foreach (var premise in rule.Premises)
        //            {
        //                if (!workingMemory.Contains(premise) && !BackwardChaining(premise))
        //                {
        //                    allPremisesTrue = false;
        //                    break;
        //                }
        //            }

        //            if (allPremisesTrue)
        //            {
        //                workingMemory.Add(rule.Result);
        //                return true;
        //            }
        //        }

        //        return false;
        //    }

        //    /// <summary>
        //    /// Получить список необходимых фактов для достижения цели
        //    /// </summary>
        //    public List<Fact> GetRequiredFacts(Fact goalFact)
        //    {
        //        var requiredFacts = new List<Fact>();
        //        var relevantRules = Rules.Values.Where(r => r.Result.Equals(goalFact));

        //        foreach (var rule in relevantRules)
        //        {
        //            foreach (var premise in rule.Premises)
        //            {
        //                if (!workingMemory.Contains(premise))
        //                {
        //                    requiredFacts.Add(premise);
        //                }
        //            }
        //        }

        //        return requiredFacts;
        //    }
        //    #endregion

        //    #region Вспомогательные методы
        //    /// <summary>
        //    /// Получить переменную по имени
        //    /// </summary>
        //    public Variable GetVariable(string name)
        //    {
        //        return Variables.Values.FirstOrDefault(v => v.Name == name);
        //    }

        //    /// <summary>
        //    /// Получить домен по имени
        //    /// </summary>
        //    public Domain GetDomain(string name)
        //    {
        //        return Domains.Values.FirstOrDefault(d => d.Name == name);
        //    }
        //    #endregion
        //}
    }