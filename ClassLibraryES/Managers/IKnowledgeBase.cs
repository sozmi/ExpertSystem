// Managers/IKnowledgeBase.cs
namespace ClassLibraryES.Managers
{
    /// <summary>
    /// Интерфейс для базовых операций с базой знаний.
    /// </summary>
    public interface IKnowledgeBase
    {
        /// <summary>
        /// Метод для открытия базы знаний.
        /// </summary>
        /// <returns>true, если база знаний успешно открыта, иначе false.</returns>
        bool Open();

        /// <summary>
        /// Метод для закрытия базы знаний.
        /// </summary>
        void Close();
    }
}