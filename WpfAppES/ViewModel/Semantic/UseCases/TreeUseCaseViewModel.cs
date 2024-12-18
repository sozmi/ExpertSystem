using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases;

class TreeUseCaseViewModel: BaseViewModel
{
    public TreeUseCaseViewModel()
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null)
            return;

        UseCases = new(db.GetUseCases());
    }

    public ObservableCollection<UseCase> UseCases { get=>_useCases; set => SetProperty(ref _useCases, value); }
    private ObservableCollection<UseCase> _useCases;
}
