using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppES.ViewModel.BaseObjects;

public class CollectionViewModel : BaseViewModel
{
    protected event Action? CollectionChanged;
    public void Subscribe(Action action)
    {
        CollectionChanged += action;
    }
    protected void OnCollectionChanged()
    {
        CollectionChanged?.Invoke();
    }
}

public class BaseViewModel : INotifyPropertyChanged
{
    protected BaseViewModel()
    {
    }

    /// <summary>
    /// Событие изменения свойства
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Изменение значения свойства
    /// </summary>
    /// <typeparam name="T">тип поля</typeparam>
    /// <param name="field">поле</param>
    /// <param name="newValue">новое значение</param>
    /// <param name="propertyName">наименование свойства</param>
    /// <returns></returns>
    protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null)
    {
        if (!Equals(field, newValue))
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
        return false;
    }
}