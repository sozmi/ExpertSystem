using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfAppES.Components.Common
{
    public class SubsystemExplanationViewModel : BaseViewModel
    {
        private ObservableCollection<string> _questionsAndAnswers = new ObservableCollection<string>();

        public ICommand AddQuestionAnswerCommand { get; set; }

        public ObservableCollection<string> QuestionsAndAnswers
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
            AddQuestionAnswerCommand = new RelayCommand(AddQuestionAnswer);
        }

        private void AddQuestionAnswer(object? parameters)
        {
            var args = parameters as string[];
            if (args is not null && args.Length == 3)
            {
                var systemMessage = args[0];
                var userAction = args[1];
                var explanation = args[2];

                QuestionsAndAnswers.Add(systemMessage);
                QuestionsAndAnswers.Add(userAction);
                QuestionsAndAnswers.Add(explanation);
            }
        }
    }
}