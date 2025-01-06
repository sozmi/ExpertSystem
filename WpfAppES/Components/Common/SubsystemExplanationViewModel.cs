using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.Components.Common
{
    public class SubsystemExplanationViewModel : BaseViewModel
    {
        private ObservableCollection<string> _questionsAndAnswers = new ObservableCollection<string>();

        public ObservableCollection<string> QuestionsAndAnswers
        {
            get => _questionsAndAnswers;
            set => SetProperty(ref _questionsAndAnswers, value);
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
        }

        private void AddQuestionAnswer(string systemMessage, string userAction, string explanation)
        {
            QuestionsAndAnswers.Add(systemMessage);   // Добавляем элемент без вызова OnPropertyChanged
            QuestionsAndAnswers.Add(userAction);      // Добавляем элемент без вызова OnPropertyChanged
            QuestionsAndAnswers.Add(explanation);     // Добавляем элемент без вызова OnPropertyChanged
        }
    }
}