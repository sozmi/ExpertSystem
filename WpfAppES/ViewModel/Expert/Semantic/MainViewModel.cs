using System.Collections.ObjectModel;
using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using Microsoft.Msagl.Drawing;

namespace WpfAppES.ViewModel.Expert.Semantic
{
    
    class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Коллекция типов отношений
        /// </summary>
        public ObservableCollection<RelationType> Relations { get; set; }

        private Graph graphObject = new();
        public Graph GraphObject
        {
            get => graphObject;
            set => SetProperty(ref graphObject, value);
        }

        ObservableCollection<Entity> entities;
        /// <summary>
        /// Коллекция типов сущностей
        /// </summary>
        public ObservableCollection<Entity> Entities { get=>entities; set=>SetProperty(ref entities, value); } 

        public MainViewModel()
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null)
                return;

            Relations = new(db.GetRelations());
            Entities = new(db.GetEntities());
            DrawGraph();
        }

        private RelayCommand? addRelationCommand;
        public RelayCommand AddRelationCommand => addRelationCommand ??= new RelayCommand(AddRelation);


        private RelayCommand? addEntityCommand;
        public RelayCommand AddEntityCommand => addEntityCommand ??= new RelayCommand(AddEntity);
        private void AddEntity(object _)
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;
            db.AddEntity(new("Не указано"));
            Entities = new(db.GetEntities());
            DrawGraph();
        }

        private RelayCommand? removeEntityCommand;

        public RelayCommand RemoveEntityCommand => removeEntityCommand ??= new RelayCommand(obj => RemoveEntity(obj));

        private void RemoveEntity(object obj)
        {
            Guid? id = obj as Guid?;
            if (id == null) return;

            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if(db == null) return;

            db.RemoveEntity((Guid)id);
            Entities = new(db.GetEntities());
            DrawGraph();
        }

        private void AddRelation(object _)
        {
            var rt = new RelationType("Не указано");
            Relations.Add(rt);
            KnowledgeBaseManager.Get().GetBase<SemanticDB>()?.AddRelationType(rt);
        }

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
}
