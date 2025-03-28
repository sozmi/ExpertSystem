using ClassLibraryES.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ClassLibraryES.semantic_es;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace ClassLibraryES.logic_es;

public class LogicDB : IKnowledgeBase
{
    public LogicDB(bool isTest = false) : base()
    {
        Consent find = new("", "");
        
    }

    /// <summary>
    /// Словарь содержащий информацию о суждениях БЗ
    /// </summary>
    [JsonProperty]
    private Dictionary<Guid, Consent> Consents { get; set; } = [];

    #region Interface
    public bool Open()
    {
        return true;
    }
    public void Close()
    {
        Consents.Clear();
    }
    #endregion



    /// <summary>
    /// Функция для добавления высказывания
    /// </summary>
    /// <param name="Who">Причина (первая половина)</param>
    /// <param name="Obj"Следствие (вторая половина)></param>
    public void AddConsent(Consent cons)
    {
        Consents.Add(cons.Id, cons);
    }
}
