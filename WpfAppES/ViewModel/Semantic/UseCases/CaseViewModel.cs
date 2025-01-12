using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases
{
    public class CaseViewModel : BaseViewModel
    {
        public CaseViewModel(Case case_, NodeQuestionViewModel parent)
        {
            _text = case_.Name;
            Parent = parent;
            FactsViewModel = new(case_.Facts);
            
            foreach (var f in case_.Questions)
                SubQuestions.Add(new(f));
        }
        public NodeQuestionViewModel Parent { get; set; }
        public string TextVariant { get => _text; set => SetProperty(ref _text, value); }
        private string _text;
        public bool ContinueAsk { get; set; } = false;
        public DataGridFactsViewModel FactsViewModel { get; }
        public ObservableCollection<NodeQuestionViewModel> SubQuestions { get; } = [];

        public static implicit operator Case(CaseViewModel v)
        {
            Case c = new()
            {
                Facts = v.FactsViewModel,
                Questions = [.. v.SubQuestions],
                AskContinue = v.ContinueAsk,
                Name = v.TextVariant
            };
            return c;
        }
    }
}
