using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using ClassLibraryES.Semantic;

namespace WpfAppES.ViewModel.Expert.Semantic
{
    class MainViewModel
    {
        #region Property
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
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        #endregion

        public ObservableCollection<Relation> Relations { get; set; } = [];

        private RelayCommand? addCommand;
        public RelayCommand AddRowCommand => addCommand ??= new RelayCommand(AddRow);
        private void AddRow(object _) => Relations.Add(new Relation("Пустая строка"));
    }
}
