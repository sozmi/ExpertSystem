using ClassLibraryES.semantic_es;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases
{
    public class NodeQuestionViewModel : BaseViewModel
    {
        public NodeQuestionViewModel(Question question)
        {
            foreach (var c in question.Cases)
                if(c != null)
                    Cases.Add(new(c, this));
            _text = question.Text;
        }
        public string Text { get => _text; set => SetProperty(ref _text, value); }
        private string _text;
        public ObservableCollection<CaseViewModel> Cases { get; set; } = [];
        public static implicit operator Question(NodeQuestionViewModel v)
        {
            Question q = new();
            q.Text = v.Text;
            q.Cases =[.. v.Cases];
            return q;
        }
    }
}
