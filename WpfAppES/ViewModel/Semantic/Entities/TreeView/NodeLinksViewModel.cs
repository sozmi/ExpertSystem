using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;

namespace WpfAppES.ViewModel.Semantic.Entities.TreeView
{
    public class NodeLinksViewModel(RelationType relation, List<Entity> entities)
    {
        public RelationType Relation { get; set; } = relation;
        public ObservableCollection<Entity> Entities { get; set; } = new(entities);
    }
}
