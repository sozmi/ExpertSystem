using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using Microsoft.Msagl.Drawing;

namespace WpfAppES.ViewModel.Semantic
{
    public interface IModelChanged
    {
        public void OnGlobalChanged();//TODO: разделить на более локальные события
    }

    class ExpertViewModel : BaseViewModel, IModelChanged
    {
        public TreeEntitiesViewModel TreeEntitiesViewModel { get; } = new();
        public DataGridRelationViewModel DataGridRelationViewModel { get; } = new();

        public ExpertViewModel()
        {
            DataGridRelationViewModel = new();
            TreeEntitiesViewModel.Subscribe(OnGlobalChanged);
            DataGridRelationViewModel.Subscribe(OnGlobalChanged);
            DataGridRelationViewModel.Subscribe(TreeEntitiesViewModel.OnGlobalChanged);

            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
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

        #region Graph
        /// <summary>
        /// Заполнение и отрисовка графического изображения
        /// </summary>
        private void DrawGraph()
        {
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
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