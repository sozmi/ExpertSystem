using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public class DataGridLinksViewModel : BaseViewModel<Link>
    {
        public DataGridLinksViewModel(Link link) : base(link)
        {
            Relation = link.Relation;
            Entity = link.Entity;
        }

        public static List<RelationType> AllRelations => new(KnowledgeBaseManager.Get()?.GetBase<SemanticDB>()?.GetRelations().ToList());
        public RelationType Relation { get => relation; set => SetProperty(ref relation, value); }
        private RelationType relation;

        public static List<Entity> AllEntities => KnowledgeBaseManager.Get()?.GetBase<SemanticDB>()?.GetEntities().ToList();
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
