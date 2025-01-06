using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.Components.Common
{
    public class SubsystemExplanationViewModel : BaseViewModel
    {
        private ObservableCollection<QuestionAnswerPair> _questionsAndAnswers = new ObservableCollection<QuestionAnswerPair>();

        public ObservableCollection<QuestionAnswerPair> QuestionsAndAnswers
        {
            get => _questionsAndAnswers;
            set => SetProperty(ref _questionsAndAnswers, value);
        }

        public SubsystemExplanationViewModel()
        {
            // Инициализация списка QuestionsAndAnswers тестовыми данными
            QuestionsAndAnswers = new ObservableCollection<QuestionAnswerPair>
            {
                new QuestionAnswerPair { Question = "Какой город является столицей Франции?", Answer = "Париж." },
                new QuestionAnswerPair { Question = "Как называется самая высокая гора в мире?", Answer = "Эверест." },
                new QuestionAnswerPair { Question = "Кто написал роман 'Война и мир'?", Answer = "Лев Толстой." }
            };
        }

        private void AddQuestionAnswer(string question, string answer)
        {
            QuestionsAndAnswers.Add(new QuestionAnswerPair { Question = question, Answer = answer });
        }
    }

    public class QuestionAnswerPair
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }
}