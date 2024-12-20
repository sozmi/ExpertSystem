﻿namespace ClassLibraryES.semantic_es;

using Newtonsoft.Json;
using System.Collections.Generic;

/// <summary>
/// Класс с информациях о сущностях
/// </summary>
public class Entity
{
    #region Construction
    /// <summary>
    /// Создание сущности с уникальным id
    /// </summary>
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Создание сущности с известными параметрами
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="name">Наименование</param>
    public Entity(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
    /// <summary>
    /// Создание сущности с уникальным id и известным именем
    /// </summary>
    /// <param name="name">Наименование</param>
    public Entity(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    
    /// <summary>
    /// Конструктор копирования
    /// </summary>
    /// <param name="entity">Сущность</param>
    public Entity(Entity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Links = new(entity.Links);
    }
    #endregion

    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Наименование сущности
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Связи сущности
    /// </summary>
    [JsonIgnore]
    public Dictionary<KeyRelative, Link> Links { get; set; } = [];

    /// <summary>
    /// Добавление связи
    /// </summary>
    /// <param name="link"></param>
    /// <exception cref="InvalidOperationException">в случае, если такая связь уже существует</exception>
    public void AddLink(Link link)
    {
        var key = link.GetKey();
        if (Links.ContainsKey(key))
            throw new InvalidOperationException("Добавление существующей связи");

        Links.Add(key, link);
    }

    /// <summary>
    /// Удаление связи по ключу
    /// </summary>
    /// <param name="key_">Ключ связи</param>
    public void RemoveLink(KeyLink key_)
    {
        Links.Remove(new(key_.Slave, key_.Relative));
    }

    /// <summary>
    /// Получение списка ключей связей сущности
    /// </summary>
    /// <returns>Список ключей</returns>
    public List<KeyLink> GetKeysRelations()
    {
        List<KeyLink> values = [];
        foreach (var link in Links.Values)
            values.Add(new(Id, link.GetKey()));
        return values;
    }

    public List<KeyRelative> GetKeysRelative()
    {
        List<KeyRelative> values = [];
        foreach (var link in Links.Values)
            values.Add(link.GetKey());
        return values;
    }

    public List<RelationType> GetRelationTypes()
    {
        List<RelationType> values = [];
        foreach (var link in Links.Values)
            values.Add(link.Relation);
        return values;
    }
}