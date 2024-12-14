using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public class DataGridLinksViewModel : BaseViewModel<Link>
    {
        public DataGridLinksViewModel(Link link) : base(link)
        {
            relation = link.Relation;
            entity = link.Entity;
        }

        public static List<RelationType> AllRelations => KnowledgeBaseManager.GetBase<SemanticDB>()?.GetRelations();
        public RelationType Relation { get => relation; set => SetProperty(ref relation, value); }
        private RelationType relation;

        public static List<Entity> AllEntities => KnowledgeBaseManager.GetBase<SemanticDB>()?.GetEntities();
        public Entity Entity { get => entity; set => SetProperty(ref entity, value); }
        private Entity entity;

        internal void SendChanges(Link dblink)
        {
            dblink.Relation = relation;
            dblink.Entity = entity;
            dblink.Explanation = ""; //TODO: добавить поле
        }
    }
}
