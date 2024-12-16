using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryES.logic_es
{
    /// <summary>
    /// Класс - расширения
    /// </summary>
    public static class LogicHelper
    {
        /// <summary>
        /// Правило перевода в конъюнктивную форму
        /// </summary>
        public static string KNF(this string a, string b) => $"{a} & {b}";

        /// <summary>
        /// Правило перевода в дизъюнктивную форму
        /// </summary>
        public static string DNF(this string a, string b) => $"!{a} | {b}";

        /// <summary>
        /// Метод разделения строки по символу и обрезки пробелов
        /// </summary>
        public static string[] MySplit(this string str, char sym) =>
            str.Split(sym).Select(s => s.Trim()).ToArray();

        /// <summary>
        /// Метод извлечения резольвенты из строки
        /// </summary>
        public static string GetResolvent(this string str, string predicate)
        {
            int index = str.IndexOf(predicate[0]);
            int length = predicate.Length + (str.Substring(index).IndexOf(')') - str.Substring(index).IndexOf('(')) + 1;

            // Возвращаем строку резольвенты с учетом отрицания, если оно присутствует
            return (str[index - 1] == '!' ? "!" : "") + str.Substring(index, length);
        }
    }
}
