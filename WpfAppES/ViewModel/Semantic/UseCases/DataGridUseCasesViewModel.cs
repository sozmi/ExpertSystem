using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppES.Components.Semantic.UseCases;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases;

class DataGridUseCasesViewModel : BaseViewModel
{
    #region Constructs
    public DataGridUseCasesViewModel()
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null)
            return;

        _useCases = new(db.GetUseCases());
        AddCommand = new(Add);
        RemoveCommand = new(Remove);
        EditCommand = new(Edit);
    }
    #endregion

    #region Fields and Properties
    public ObservableCollection<UseCase> UseCases { get=>_useCases; set => SetProperty(ref _useCases, value); }
    private ObservableCollection<UseCase> _useCases;

    public UseCase? SelectedItem {  get=>selectedItem; set => SetProperty(ref selectedItem, value); }
    private UseCase? selectedItem;
    #endregion

    #region Commands
    public RelayAction RemoveCommand {  get; private set; } 
    public RelayAction AddCommand { get; private set;}
    public RelayAction EditCommand { get; private set; }
    #endregion

    #region Methods
    private void Add()
    {
        UseCase newUC = new("Новый");
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null) return;

        db.Create(newUC);
        
        UseCases.Add(db.GetUseCase(newUC.Id));
    }

    private void Edit()
    {
        if (SelectedItem == null)
        {
            Common.MessageBox.Show("Не выбран элемент для изменения", "Ошибка");
            return;
        }
        Guid id = SelectedItem.Id;
        DialogUseCaseView dialogUseCaseView = new(id);
        dialogUseCaseView.ShowDialog();
    }

    private void Remove()
    {
        if (SelectedItem == null)
        {
            Common.MessageBox.Show("Не выбран элемент для удаления", "Ошибка");
            return;
        }

        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null) return;
        var id = SelectedItem.Id;
        SelectedItem = null;
        db.RemoveUseCase(id);
        foreach (var uc in UseCases.ToArray())
            if (uc.Id == id)
            {
                UseCases.Remove(uc);
                break;
            }
    }

    #endregion
}
