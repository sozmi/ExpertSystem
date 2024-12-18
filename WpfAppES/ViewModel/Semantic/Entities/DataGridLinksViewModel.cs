using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.Entities
{
    public class DataGridLinksViewModel : BaseViewModel
    {
        public DataGridLinksViewModel(Link link)
        {
            relation = link.Relation;
            entity = link.Entity;
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null)
                return;
            AllRelations = db.GetRelations();
            AllEntities = db.GetEntities();
        }

        public static List<RelationType> AllRelations { get; set; } = [];
        public RelationType Relation { get => relation; set => SetProperty(ref relation, value); }
        private RelationType relation;

        public static List<Entity> AllEntities { get; set; } = [];
        public Entity Entity { get => entity; set => SetProperty(ref entity, value); }
        private Entity entity;
    }
}
