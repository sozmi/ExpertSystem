using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppES.Components.Common
{
    public class SubsystemExplanationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _questionsAndAnswers = new ObservableCollection<string>();

        public ObservableCollection<string> QuestionsAndAnswers
        {
            get => _questionsAndAnswers;
            set
            {
                if (_questionsAndAnswers != value)
                {
                    _questionsAndAnswers = value;
                    OnPropertyChanged(nameof(QuestionsAndAnswers));
                    // OnPropertyChanged теперь нужен только при замене всего списка целиком,
                    // а не при добавлении/удалении отдельных элементов.
                }
            }
        }

        public SubsystemExplanationViewModel()
        {
            // Инициализация списка QuestionsAndAnswers тестовыми данными
            QuestionsAndAnswers = new ObservableCollection<string>
            {
                "Это",
                "Тестовые",
                "Данные",
                "Для",
                "Списка"
            };

            // Инициализация события PropertyChanged
            PropertyChanged += delegate { };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddQuestionAnswer(string systemMessage, string userAction, string explanation)
        {
            QuestionsAndAnswers.Add(systemMessage);   // Добавляем элемент без вызова OnPropertyChanged
            QuestionsAndAnswers.Add(userAction);      // Добавляем элемент без вызова OnPropertyChanged
            QuestionsAndAnswers.Add(explanation);     // Добавляем элемент без вызова OnPropertyChanged
        }
    }
}