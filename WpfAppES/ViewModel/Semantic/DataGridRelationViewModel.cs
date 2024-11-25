using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    class DataGridRelationViewModel : BaseViewModel<object>
    {
        /// <summary>
        /// Коллекция типов отношений
        /// </summary>
        public ObservableCollection<RelationType> Relations { get => relations; set => SetProperty(ref relations, value); }
        ObservableCollection<RelationType> relations = [];
        List<IModelChanged> modelChangeds = [];

        private RelationType? _selectedItem;
        public RelationType? SelectedItem2
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public void Subscribe(IModelChanged modelChanged)
        {
            modelChangeds.Add(modelChanged);
        }
        public DataGridRelationViewModel()
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null)
                return;
            Relations = new(db.GetRelations());
        }
        #region AddRelationCommand
        /// <summary>
        /// Команда добавление новых связей
        /// </summary>
        public RelayCommand AddRelationCommand => addRelationCommand ??= new(AddRelation);
        private RelayCommand? addRelationCommand;
        private void AddRelation(object? _)
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;
            var rt = new RelationType("Не указано");
            db.Create(rt);
            Relations.Add(rt);
            foreach (var model in modelChangeds)
                model.OnGlobalChanged();
        }
        #endregion
        #region RemoveRelationCommand
        /// <summary>
        /// Команда удаления типа связи
        /// </summary>
        public RelayCommand RemoveRelationCommand => removeRelationCommand ??= new(obj => RemoveRelation(obj));
        private RelayCommand? removeRelationCommand;

        private void RemoveRelation(object? obj)
        {
            obj = SelectedItem2.Id;
            if (obj == null)
            {
                new Common.MessageBox("Не выбран элемент для удаления", "Ошибка").Show();
                return;
            }
            if (obj is not Guid)
                return;
            Guid id = (Guid)obj;
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;

            db.RemoveRelationType(id);

            foreach (var rel in Relations.ToArray())
                if (rel.Id == id)
                {
                    Relations.Remove(rel);
                    break;
                }
            foreach (var model in modelChangeds)
                model.OnGlobalChanged();
        }

        #endregion
        #region EditRelationCommand
        #endregion

    }
}
