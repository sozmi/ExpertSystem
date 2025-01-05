using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppES.Components.Common
{
    public class SubsystemExplanationViewModel : INotifyPropertyChanged
    {
        private List<string> _questionsAndAnswers = new List<string>();

        public List<string> QuestionsAndAnswers
        {
            get => _questionsAndAnswers;
            set
            {
                if (_questionsAndAnswers != value)
                {
                    _questionsAndAnswers = value;
                    OnPropertyChanged(nameof(QuestionsAndAnswers));
                }
            }
        }

        public SubsystemExplanationViewModel()
        {
            // Инициализация списка QuestionsAndAnswers тестовыми данными
            QuestionsAndAnswers = new List<string>
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
            QuestionsAndAnswers.Add(systemMessage);
            QuestionsAndAnswers.Add(userAction);
            QuestionsAndAnswers.Add(explanation);
            OnPropertyChanged(nameof(QuestionsAndAnswers));
        }
    }
}