using System;

namespace ClassLibraryES.semantic_es;

/// <summary>
/// Ключ для отношения
/// </summary>
public struct KeyRelative
{
    /// <summary>
    /// Идентификатор подчиненного объекта
    /// </summary>
    public Guid Slave { get; set; }

    /// <summary>
    /// Связь
    /// </summary>
    public Guid Relative { get; set; }

    /// <summary>
    /// Создание пустого ключа
    /// </summary>
    public KeyRelative() { }

    /// <summary>
    /// Создание ключа с известными параметрами
    /// </summary>
    /// <param name="sid_">id подчиненный</param>
    /// <param name="rid_">id отношения</param>
    public KeyRelative(Guid sid_, Guid rid_)
    {
        Slave = sid_;
        Relative = rid_;
    }
}

/// <summary>
/// Ключ связи
/// </summary>
public struct KeyLink
{
    /// <summary>
    /// Идентификатор главного объекта
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор подчиненного объекта
    /// </summary>
    public Guid Slave { get; set; }

    /// <summary>
    /// Идентификатор связи
    /// </summary>
    public Guid Relative { get; set; }

    /// <summary>
    /// Создание пустого ключа
    /// </summary>
    public KeyLink() { }

    /// <summary>
    /// Создание ключа с известными параметрами
    /// </summary>
    /// <param name="id">Идентификатор главного объекта</param>
    /// <param name="slave">Идентификатор подчиненного</param>
    /// <param name="relative">Идентификатор отношения</param>
    public KeyLink(Guid id, Guid slave, Guid relative)
    {
        Id = id;
        Slave = slave;
        Relative = relative;
    }

    /// <summary>
    /// Создание ключа с известными параметрами
    /// </summary>
    /// <param name="id">Идентификатор главного объекта</param>
    /// <param name="key">Ключ отношения</param>
    public KeyLink(Guid id, KeyRelative key)
    {
        Id = id;
        Slave = key.Slave;
        Relative = key.Relative;
    }
}