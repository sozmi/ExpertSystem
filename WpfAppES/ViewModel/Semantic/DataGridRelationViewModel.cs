using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    class DataGridRelationViewModel : CollectionViewModel
    {
        /// <summary>
        /// Коллекция типов отношений
        /// </summary>
        public ObservableCollection<RelationType> Relations { get => relations; set => SetProperty(ref relations, value); }
        ObservableCollection<RelationType> relations = [];

        private RelationType? _selectedItem;
        public RelationType? SelectedRelation
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public DataGridRelationViewModel()
        {
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
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
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null) return;
            var rt = new RelationType("Не указано", "Вопрос");
            db.Create(rt);
            Relations.Add(rt);
            OnCollectionChanged();
        }
        #endregion
        #region RemoveRelationCommand
        /// <summary>
        /// Команда удаления типа связи
        /// </summary>
        public RelayCommand RemoveRelationCommand => removeRelationCommand ??= new(obj => RemoveRelation(obj));
        private RelayCommand? removeRelationCommand;

        private void RemoveRelation(object _)
        {
            if (SelectedRelation == null)
            {
                new Common.MessageBox("Не выбран элемент для удаления", "Ошибка").Show();
                return;
            }

            if (SelectedRelation.Id == Guid.Empty)
            {
                new Common.MessageBox("Нельзя удалять системные связи", "Ошибка").Show();
                return;
            }

            Guid id = SelectedRelation.Id;
            SelectedRelation = null;
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null) return;

            db.RemoveRelationType(id);

            foreach (var rel in Relations.ToArray())
                if (rel.Id == id)
                {
                    Relations.Remove(rel);
                    break;
                }
            OnCollectionChanged();
        }

        #endregion
        #region EditRelationCommand
        #endregion

    }
}
