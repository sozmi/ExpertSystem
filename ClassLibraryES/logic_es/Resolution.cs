using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.logic_es;

public class Resolution
{
    protected List<Consent> consents;
    protected List<string> predicates;

    public Resolution(List<Consent> consents)
    {
        this.consents = new List<Consent>();
        this.consents.AddRange(consents);
        predicates = CreatePredicates();
    }

    public bool Method(Consent consent)
    {
        var dnfs = DNFForm(); // Получение дизъюнктивных форм
        var noConsentRes = $"!{consent.Who}({consent.Object})"; // Строка с отрицанием целевого выражения
        var knf = KNFForm(dnfs, noConsentRes); // Получение конъюнктивной формы

        return SearchResolvent(knf) == ""; // Проверка, удовлетворена ли цель
    }

    private string SearchResolvent(string knf)
    {
        string[] knfSplit = knf.MySplit('&');
        string resolvent = knfSplit[0];

        for (int n = knfSplit.Length - 1, i = 0; i < n; i++)
        {
            resolvent = Resolvent(resolvent, knfSplit[i + 1]);
        }
        return resolvent;
    }

    //Поиск резольвенты
    public string Resolvent(string dnf1, string dnf2)
    {
        string resolvent = " ";
        string left, right;

        //В цикле проводим опреацию поиска резольвентов над каждой парой дизъюнктов
        foreach (var predicate in predicates)
        {
            //Условия направлены на поиск противоположных пар, если срабатывает, исключаем пару
            if (dnf1.Contains(predicate) && dnf2.Contains("!" + predicate))
            {
                left = dnf1.Replace(predicate, "");
                right = dnf2.Replace(predicate, "");
                resolvent = GetResolvent(left, right);
            }
            if (dnf1.Contains("!" + predicate) && dnf2.Contains(predicate))
            {
                left = dnf1.Replace(predicate, "");
                right = dnf2.Replace(predicate, "");
                resolvent = GetResolvent(left, right);
            }
        }
        //Возвращаем полученную строку
        return resolvent;
    }

    private string GetResolvent(string left, string right)
    {
        string resolvent = string.Empty;
        foreach (var predicate in predicates)
        {
            if (left.Contains(predicate))
            {
                if (resolvent.Length > 0)
                {
                    resolvent += " | ";
                }
                resolvent += left.GetResolvent(predicate);
            }
            if (right.Contains(predicate))
            {
                if (resolvent.Length > 0)
                {
                    resolvent += " | ";
                }
                resolvent += right.GetResolvent(predicate);
            }
        }
        return resolvent;
    }

    //Составляем конъюнкцию всех дезъюнктов, включив в нее отрицание целевого выражения
    private string KNFForm(List<string> dnfs, string noApprovalRes)
    {
        string knf = dnfs[0];

        //Формирование строки конъюнтов
        for (int n = dnfs.Count, i = 1; i < n; i++)
        {
            knf = knf.KNF(dnfs[i]); // вызов правила перевода в конъюнктивную форму
        }

        return knf.KNF(noApprovalRes);
    }

    //Преобразуем предикатную форму в дизъюнктивную
    private List<string> DNFForm()
    {
        List<string> dnfs = new List<string>();

        //формируем лист с дизъюнктивной формой
        for (int n = predicates.Count - 1, i = 0; i < n; i++)
        {
            dnfs.Add($"{predicates[i]}(X)".DNF($"{predicates[i + 1]}(X)"));
        }
        dnfs.Add($"{consents[0].Who}({consents[0].Object})");

        return dnfs;
    }

    private List<string> CreatePredicates()
    {
        List<string> predicates = new List<string>();

        foreach (var approval in consents)
        {
            predicates.Add($"{approval.Who}");
        }

        return predicates;
    }
}
