using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Shapes;
using WpfAppES.ViewModel.BaseObjects;
using WpfAppES.ViewModel.Semantic.Entities.Item;

namespace WpfAppES.ViewModel.Semantic.UseCases;

public class UseCaseViewModel : BaseViewModel
{
    public UseCaseViewModel(Guid id)
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null) return;
        var uc = db.GetUseCase(id);
        Id = uc.Id;
        _name = uc.Name;
        _description = uc.Description;

        FactsViewModel = new(uc.Facts);
        QuestionsViewModel = new(uc.Questions);
    }
    public DataGridFactsViewModel FactsViewModel { get; }

    public ControlQuestionsViewModel QuestionsViewModel { get; }
    public Guid Id { get; }

    public string Name { get => _name; set => SetProperty(ref _name, value); }
    private string _name;

    public string Description { get => _description; set => SetProperty(ref _description, value); }
    private string _description;



    public bool SaveChanges()
    {
        UseCase n = new()
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Facts = FactsViewModel,
            Questions = QuestionsViewModel
        };

        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null)
            return false;

        db.Edit(n);
        return true;
    }
}
