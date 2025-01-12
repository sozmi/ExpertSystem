using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public class LinksTreeViewModel : BaseViewModel<Entity>
    {
        public RelationType Relation { get; set; }
        public LinksTreeViewModel(Entity entity, RelationType relation, List<Entity> entities) : base(entity)
        {
            Relation = relation;
            Entities = new(entities);
        }
        public ObservableCollection<Entity> Entities { get; set; } = [];
    } 
}
