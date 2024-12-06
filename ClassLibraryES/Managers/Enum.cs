namespace ClassLibraryES.Managers
{
    /// <summary>
    /// Перечисление типов баз знаний, используемых в экспертной системе.
    /// </summary>
    public enum ETypeDB
    {
        /// <summary>
        /// Логическая база знаний.
        /// </summary>
        eLogical = 0,

        /// <summary>
        /// Продукционная база знаний.
        /// </summary>
        eProducts = 1,

        /// <summary>
        /// Семантическая база знаний.
        /// </summary>
        eSemantic = 2,

        /// <summary>
        /// Фреймовая база знаний.
        /// </summary>
        eFrame = 3,

        /// <summary>
        /// Общее количество возможных типов баз знаний.
        /// </summary>
        eCommonCount = 4
    }
}
