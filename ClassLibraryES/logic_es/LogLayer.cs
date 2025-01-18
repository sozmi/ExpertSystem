using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.logic_es;

public class LogLayer
{
    protected List<Consent> consents = new List<Consent>();
    protected string exp = "";

    /// <summary>
    /// Функция для добавления высказывания
    /// </summary>
    /// <param name="Who">Причина (первая половина)</param>
    /// <param name="Obj"Следствие (вторая половина)></param>
    public void AddConsent(string Who, string Obj)
    {
        consents.Add(new Consent(Who, Obj));
    }

    /// <summary>
    /// Функция для проверки высказывания методом резолюций
    /// </summary>
    /// <param name="Who">Причина</param>
    /// <param name="Obj">Следствие</param>
    /// <returns></returns>
    public string DoResolution(string Who, string Obj)
    {
        Resolution resolution = new Resolution(consents);
        exp = resolution.GetExp();
        if (resolution.Method(new Consent(Who, Obj)))
            return "Высказывание верно";
        else
            return "Выссказывание ложно или недостаточно информации";
    }

    public string Explain()
    {
        if (exp != "")
            return exp;
        else return "Объяснения нет";
    }
}
