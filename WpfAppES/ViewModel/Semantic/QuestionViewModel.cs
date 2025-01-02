using ClassLibraryES.semantic_es;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public class QuestionViewModel : BaseViewModel
    {
        Question question;
        public QuestionViewModel(Question q) 
        { 
            question = q;
            SelectCase = new(SelectCaseCommand);
        }

        public string Name => question.Text;
        public List<Case> Cases => question.Cases;

        public RelayCommand SelectCase { get; private set; }
        private void SelectCaseCommand(object? obj)
        {
            if (obj == null)
                return;
            if (obj is Case c)
            {
                var q = SemanticES.Next(c);
                if (q == null)
                    return;
            }
        }
    }
}
