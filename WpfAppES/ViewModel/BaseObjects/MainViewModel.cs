using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppES.ViewModel.BaseObjects
{
    /// <summary>
    /// Основная модель представления для привязки данных в приложении.
    /// Обеспечивает обновление интерфейса при изменении значений свойств.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        // Поле для хранения состояния доступности команды сохранения
        private bool _saveEnabled;

        // Поля для управления видимостью меню интерфейса и базы знаний
        private Visibility _interfaceMenuVisibility = Visibility.Collapsed;
        private Visibility _knowledgeMenuVisibility = Visibility.Collapsed;

        // Событие для уведомления интерфейса об изменении свойств.
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Указывает, доступна ли команда сохранения.
        /// </summary>
        public bool SaveEnabled
        {
            get => _saveEnabled;
            set
            {
                _saveEnabled = value;
                OnPropertyChanged();// Уведомляем об изменении свойства
            }
        }

        /// <summary>
        /// Определяет видимость меню интерфейса.
        /// </summary>
        public Visibility InterfaceMenuVisibility
        {
            get => _interfaceMenuVisibility;
            set
            {
                _interfaceMenuVisibility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Определяет видимость меню базы знаний. 
        /// </summary>
        public Visibility KnowledgeMenuVisibility
        {
            get => _knowledgeMenuVisibility;
            set
            {
                _knowledgeMenuVisibility = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Уведомляет об изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства. Определяется автоматически при вызове</param>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
