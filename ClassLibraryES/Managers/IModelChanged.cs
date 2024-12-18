namespace ClassLibraryES.Managers;

/// <summary>
/// Интерфейс для оповещения о глобальных изменениях в системе.
/// </summary>
public interface IModelChanged
{
    /// <summary>
    /// Метод, который необходимо вызывать при возникновении глобального изменения.
    /// </summary>
    void OnGlobalChanged();
}