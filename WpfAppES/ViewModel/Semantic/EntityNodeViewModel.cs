using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;

namespace WpfAppES.ViewModel.Semantic
{
    public class EntityNodeViewModel
    {
        public EntityNodeViewModel(Entity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Dictionary<RelationType, List<Entity>> relations = [];
            foreach (var link in entity.Links.Values)
            {
                if (!relations.ContainsKey(link.Relation))
                    relations.Add(link.Relation, []);
                relations[link.Relation].Add(link.Entity);
            }
            foreach (var link in relations)
                Links.Add(new(entity, link.Key, link.Value));
        }
        public Guid Id { get; }
        public string Name { get; }
        public ObservableCollection<LinksTreeViewModel> Links { get; set; } = [];
    }
};