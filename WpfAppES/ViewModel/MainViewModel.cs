using System.Windows;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel
{
    /// <summary>
    /// Основная модель представления для привязки данных в приложении.
    /// Обеспечивает обновление интерфейса при изменении значений свойств.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        // Поле для хранения состояния доступности команды сохранения
        private bool _saveEnabled;

        // Поля для управления видимостью меню интерфейса и базы знаний
        private Visibility _interfaceMenuVisibility = Visibility.Collapsed;
        private Visibility _knowledgeMenuVisibility = Visibility.Collapsed;

        /// <summary>
        /// Указывает, доступна ли команда сохранения.
        /// </summary>
        public bool SaveEnabled
        {
            get => _saveEnabled;
            set => SetProperty(ref _saveEnabled, value);
        }

        /// <summary>
        /// Определяет видимость меню интерфейса.
        /// </summary>
        public Visibility InterfaceMenuVisibility
        {
            get => _interfaceMenuVisibility;
            set => SetProperty(ref _interfaceMenuVisibility, value);
        }

        /// <summary>
        /// Определяет видимость меню базы знаний. 
        /// </summary>
        public Visibility KnowledgeMenuVisibility
        {
            get => _knowledgeMenuVisibility;
            set => SetProperty(ref _knowledgeMenuVisibility, value);
        }
    }
}
