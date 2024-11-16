using System.Collections.ObjectModel;
using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
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
        public ObservableCollection<RelationType> Relations { get; set; } = [];

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
        #endregion

        #region AddRelationCommand
        /// <summary>
        /// Команда добавление новых связей
        /// </summary>
        public RelayCommand AddRelationCommand => addRelationCommand ??= new(AddRelation);
        private RelayCommand? addRelationCommand;
        private void AddRelation(object? _)
        {
            var rt = new RelationType("Не указано");
            Relations.Add(rt);
            KnowledgeBaseManager.Get().GetBase<SemanticDB>()?.AddRelationType(rt);
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
            db.AddEntity(new("Не указано"));
            Entities = new(db.GetEntities());
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

            db.RemoveEntity((Guid)id);
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