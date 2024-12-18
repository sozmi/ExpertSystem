using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.Relations
{
    class DataGridRelationViewModel : CollectionViewModel
    {
        /// <summary>
        /// Коллекция типов отношений
        /// </summary>
        public ObservableCollection<RelationType> Relations { get => relations; set => SetProperty(ref relations, value); }
        ObservableCollection<RelationType> relations = [];


        public RelationType? SelectedRelation { get => _selectedItem; set => SetProperty(ref _selectedItem, value); }
        private RelationType? _selectedItem;

        public DataGridRelationViewModel()
        {
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null)
                return;
            relations = new(db.GetRelations());

            removeRelationCommand = new(RemoveRelation);
            addRelationCommand = new(AddRelation);
        }

        #region AddRelationCommand
        /// <summary>
        /// Команда добавление новых связей
        /// </summary>
        public RelayAction AddRelationCommand => addRelationCommand;
        private readonly RelayAction addRelationCommand;
        private void AddRelation()
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
        public RelayAction RemoveRelationCommand => removeRelationCommand;
        private readonly RelayAction removeRelationCommand;

        private void RemoveRelation()
        {
            if (SelectedRelation == null)
            {
                Common.MessageBox.Show("Не выбран элемент для удаления", "Ошибка");
                return;
            }

            if (SelectedRelation.Id == Guid.Empty)
            {
                Common.MessageBox.Show("Нельзя удалять системные связи", "Ошибка");
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
