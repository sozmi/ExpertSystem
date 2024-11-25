using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public class EntityTreeViewModel
    {
        public EntityTreeViewModel(Entity entity)
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

    public class EntityViewModel : BaseViewModel<Entity>
    {
        public EntityViewModel(Entity entity) : base(entity)
        {
            Name = entity.Name;
            Links = [.. entity.Links.Values];
            Dictionary<RelationType, List<Entity>> relations = [];
            foreach (var link in entity.Links.Values)
            {
                if (!relations.ContainsKey(link.Relation))
                    relations.Add(link.Relation, []);
                relations[link.Relation].Add(link.Entity);
            }
            //AssociationsVM.Add(new(association));
        }

        public Guid Id => original.Id;
        public static List<Entity>? AllEntities => KnowledgeBaseManager.Get()?.GetBase<SemanticDB>()?.GetEntities().ToList();
        public static ObservableCollection<RelationType> AllRelations => new(KnowledgeBaseManager.Get()?.GetBase<SemanticDB>()?.GetRelations().ToList());
        public string Name { get => name; set => SetProperty(ref name, value); }
        private string name = "";

        public ObservableCollection<Link> Links { get => links; set => SetProperty(ref links, value); }
        ObservableCollection<Link> links = [];

        private List<Action> funcs = [];
        public bool SendChanges()
        {
            if (original == null)
                return false;

            original.Name = Name;
            original.Id = Id;

            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null)
                return false;
            foreach (var action in funcs)
            {
                action();
            }

            return true;
        }

        public RelayCommand AddLinkCommand => addLinkCommand ??= new(obj => AddLink(obj));
        RelayCommand addLinkCommand;

        private void AddLink(object? _)
        {
            Links.Add(new());
        }

        public RelayCommand RemoveLinkCommand => removeLinkCommand ??= new(obj => RemoveLink(obj));
        RelayCommand removeLinkCommand;

        private Link? _selectedItem;
        public Link? SelectedItem { get; set; }
        //public Link? SelectedItem
        //{
        //    get => _selectedItem;
        //    set => SetProperty(ref _selectedItem, value);
        //}

        private void RemoveLink(object? _)
        {
            Link link = SelectedItem;
            var f = () =>
            {
                var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
                if (db == null)
                    return;
                var key = new KeyLink(Id, link.GetKey());
                db.RemoveLink(key);
            };
            funcs.Add(f);
            Links.Remove(link);
        }

        private void EditRelationTypeInLink(object id, object link)
        {

        }

        private void EditEntityInLink(object id, object link)
        {

        }
    }
};