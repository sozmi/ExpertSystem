using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases
{
    public class CaseViewModel : BaseViewModel
    {
        public CaseViewModel(Case case_, NodeQuestionViewModel parent)
        {
            TextVariant = case_.Name;
            Parent = parent;
            if (case_.Facts != null)
                FactsViewModel = new(case_.Facts);

            if (case_.SubQuestions != null)
                foreach (var f in case_.SubQuestions)
                    SubQuestions.Add(new(f));
            AddCommand = new(PerformAdd);
            RemoveCommand = new(PerformRemove);
        }
        public NodeQuestionViewModel Parent { get; set; }
        public string TextVariant { get; set; }
        public bool ContinueAsk { get; set; } = false;
        public DataGridFactsViewModel FactsViewModel { get; }
        public ObservableCollection<NodeQuestionViewModel> SubQuestions { get; } = [];

        public RelayAction AddCommand { get; private set; }

        private void PerformAdd()
        {
            SubQuestions.Add(new(new("Не указан")));
        }

        public NodeQuestionViewModel? SelectedQuestion { get => selectedQuestion; set => SetProperty(ref selectedQuestion, value); }
        private NodeQuestionViewModel? selectedQuestion;

        public RelayAction RemoveCommand { get; private set; }

        private void PerformRemove()
        {
            if (SelectedQuestion == null)
                return;
            int index = SubQuestions.IndexOf(SelectedQuestion);
            SelectedQuestion = null;
            SubQuestions.RemoveAt(index);
        }
    }
}
