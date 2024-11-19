using System;
using System.Collections.Generic;
using ClassLibraryES.Managers;

namespace ClassLibraryES.Products
{
    /// <summary>
    /// Продукционная база знаний - хранилище всех элементов 
    /// продукционной системы (доменов, переменных, фактов, правил)
    /// </summary>
    public class ProductionDB : IKnowledgeBase
    {
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
            throw new NotImplementedException();
        }
        #endregion
    }
}