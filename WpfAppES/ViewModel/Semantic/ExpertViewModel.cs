using System.Collections.ObjectModel;
using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using Microsoft.Msagl.Drawing;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public interface IModelChanged
    {
        public void OnGlobalChanged();
    }

    class ExpertViewModel : BaseViewModel<object?>, IModelChanged
    {

        public TreeEntitiesViewModel TreeEntitiesViewModel { get => _treeEntities; set => SetProperty(ref _treeEntities, value); }
        TreeEntitiesViewModel _treeEntities;
        public DataGridRelationViewModel DataGridRelationViewModel { get => _dataGridRelation; set => SetProperty(ref _dataGridRelation, value); }
        private DataGridRelationViewModel _dataGridRelation;

        public ExpertViewModel() : base(null)
        {
            TreeEntitiesViewModel = new TreeEntitiesViewModel();
            DataGridRelationViewModel = new DataGridRelationViewModel();
            TreeEntitiesViewModel.Subscribe(this);
            DataGridRelationViewModel.Subscribe(this);
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null)
                return;

            DrawGraph();
        }

        #region Fields and properties

        /// <summary>
        /// Графическое описание БЗ
        /// </summary>
        public Graph GraphObject { get => graphObject; set => SetProperty(ref graphObject, value); }
        private Graph graphObject = new();



        #endregion


            db.DeleteEntity((Guid)id);
            Entities.Clear();
            foreach (var ent in db.GetEntities())
                Entities.Add(new(ent));
            DrawGraph();
        }
        #endregion

        #region Graph
        /// <summary>
        /// Заполнение и отрисовка графического изображения
        /// </summary>
        private void DrawGraph()
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;
            Graph graph = new();
            foreach (var ent in db.GetEntities())
            {
                Node n = new(ent.Id.ToString())
                {
                    LabelText = ent.Name
                };
                graph.AddNode(n);
            }
            foreach (var ent in db.GetEntities())
            {
                foreach (var link in ent.Links.Values)
                {
                    graph.AddEdge(ent.Id.ToString(),
                       link.Relation.Name,
                        link.Entity.Id.ToString());
                }
            }
            GraphObject = graph;
        }

        public void OnGlobalChanged()
        {
            DrawGraph();
        }
    }
    #endregion
};