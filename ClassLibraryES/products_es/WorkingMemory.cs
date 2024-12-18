using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.products_es;

/// <summary>
/// Класс для управление рабочей памятью
/// </summary>
public class WorkingMemory
{
    /// <summary>
    /// Список фактов в рабочей памяти
    /// </summary>
    private List<Fact> facts;

    /// <summary>
    /// Конструктор для инициализации рабочей памяти
    /// </summary>
    public WorkingMemory()
    {
        facts = new List<Fact>();
    }

    /// <summary>
    /// Добавить факт в рабочую память
    /// </summary>
    /// <param name="fact">Факт, который нужно добавить</param>
    public void AddFact(Fact fact)
    {
        if (!facts.Contains(fact))
        {
            facts.Add(fact);
        }
    }

    /// <summary>
    /// Очистить рабочую память
    /// </summary>
    public void Clear()
    {
        facts.Clear();
    }

    /// <summary>
    /// Проверить, содержится ли факт в рабочей памяти
    /// </summary>
    /// <param name="fact">Факт, который нужно проверить</param>
    /// <returns>Возвращает true, если факт содержится в памяти; иначе false</returns>
    public bool Contains(Fact fact)
    {
        return facts.Contains(fact);
    }

    /// <summary>
    /// Получить все факты из рабочей памяти
    /// </summary>
    /// <returns>Список фактов, содержащихся в памяти</returns>
    public List<Fact> GetFacts()
    {
        return facts;
    }
    public void RemoveFact(Fact fact)
    {
        facts.Remove(fact);
    }

}
