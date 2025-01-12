using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryES.frame_es;

public class Slot
{
    private Guid id;
    private string name;
    private string value;

    /// <summary>
    /// Получить уникальный id слота\свойства
    /// </summary>
    public Guid Id { get => id; }

    /// <summary>
    /// Получить имя слота\свойства
    /// </summary>
    public string Name { get => name; set => name = value; }

    /// <summary>
    /// Получить значение слота\свойства
    /// </summary>
    public string Value { get => value; set => this.value = value; }

    /// <summary>
    /// Конструктор слота\свойства
    /// </summary>
    public Slot()
    {
        id = Guid.NewGuid();
        name = string.Empty;
        value = string.Empty;
    }
    /// <summary>
    /// Конструктор слота\свойства
    /// </summary>
    /// <param name="name">имя слота\свойства</param>
    /// <param name="value">значение слота\свойства</param>
    public Slot(string name, string value)
    {
        id = new Guid();
        this.name = name;
        this.value = value;
    }
}