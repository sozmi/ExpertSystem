using System.Collections.ObjectModel;
using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using Microsoft.Msagl.Core.DataStructures;
using Microsoft.Msagl.Drawing;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    class ExpertViewModel : BaseViewModel
    {
        public ExpertViewModel()
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null)
                return;

            Relations = new(db.GetRelations());
            Entities = new(db.GetEntities());
            DrawGraph();
        }


        #region Fields and properties
        /// <summary>
        /// Коллекция типов отношений
        /// </summary>
        public ObservableCollection<RelationType> Relations { get => relations; set => SetProperty(ref relations, value); }
        ObservableCollection<RelationType> relations = [];
        /// <summary>
        /// Графическое описание БЗ
        /// </summary>
        public Graph GraphObject { get => graphObject; set => SetProperty(ref graphObject, value); }
        private Graph graphObject = new();

        /// <summary>
        /// Коллекция типов сущностей
        /// </summary>
        public ObservableCollection<Entity> Entities { get => entities; set => SetProperty(ref entities, value); }
        ObservableCollection<Entity> entities = [];

        private RelationType _selectedItem;
        public RelationType SelectedItem
        {
            get => _selectedItem;
            set=> SetProperty(ref _selectedItem, value);
        }

        private RelationType _selectedItem2;
        public RelationType SelectedItem2
        {
            get => _selectedItem2;
            set => SetProperty(ref _selectedItem2, value);
        }
        #endregion

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
            if (obj == null)
            {
                new Common.MessageBox("Не выбран элемент для удаления", "Ошибка").Show();
                return;
            }

            Guid? id = obj as Guid?;
            if (id == null) return;

            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;

            db.DeleteRelationType((Guid)id);

            Relations = new(db.GetRelations());
            Entities = new(db.GetEntities());
            DrawGraph();
        }
        #endregion

        #region AddEntityCommand 
        /// <summary>
        /// Команда добавления новой сущности
        /// </summary>
        public RelayCommand AddEntityCommand => addEntityCommand ??= new(AddEntity);
        private RelayCommand? addEntityCommand;

        private void AddEntity(object? _)
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;
            Entity ent = new("Не указано");
            db.Create(ent);
            Entities.Add(ent);
            DrawGraph();
        }
        #endregion

        #region RemoveEntityCommand
        /// <summary>
        /// Команда удаления сущности
        /// </summary>
        public RelayCommand RemoveEntityCommand => removeEntityCommand ??= new(obj => RemoveEntity(obj));
        private RelayCommand? removeEntityCommand;

        private void RemoveEntity(object? obj)
        {
            if(obj == null) return;

            Guid? id = obj as Guid?;
            if (id == null) return;

            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;

            db.DeleteEntity((Guid)id);
            Entities = new(db.GetEntities());
            DrawGraph();
        }
        #endregion

        #region Graph
        /// <summary>
        /// Заполнение и отрисовка графического изображения
        /// </summary>
        private void DrawGraph()
        {
            Graph graph = new();
            foreach (var ent in Entities)
            {
                Node n = new(ent.Id.ToString())
                {
                    LabelText = ent.Name
                };
                graph.AddNode(n);
            }
            foreach (var ent in Entities)
            {
                foreach (var pair in ent.Associations)
                {
                    var association = pair.Value;
                    foreach (var target in association.Entities)
                        graph.AddEdge(ent.Id.ToString(),
                            association.Relation.Name,
                            target.Key.ToString());
                }

            }
            GraphObject = graph;
        }
    }
    #endregion
};