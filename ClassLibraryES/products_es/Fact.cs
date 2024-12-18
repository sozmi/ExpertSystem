using System;

namespace ClassLibraryES.products_es;

/// <summary>
/// Факт продукционной системы - это пара "переменная-значение",
/// которая представляет собой утверждение о некотором свойстве объекта
/// </summary>
public class Fact
{
    /// <summary>
    /// Уникальный идентификатор факта.
    /// Генерируется автоматически при создании факта.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Переменная факта - описывает свойство или характеристику объекта.
    /// </summary>
    public Variable? Variable { get; set; }

    /// <summary>
    /// Значение переменной - конкретное значение свойства объекта.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Создает новый факт с пустыми значениями переменной и значения.
    /// Используется когда значения будут установлены позже.
    /// </summary>
    public Fact()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Создает новый факт с указанной переменной и значением.
    /// </summary>
    /// <param name="variable">Переменная факта</param>
    /// <param name="value">Значение переменной</param>
    public Fact(Variable variable, string value)
    {
        Id = Guid.NewGuid();
        Variable = variable;
        Value = value;
    }
}