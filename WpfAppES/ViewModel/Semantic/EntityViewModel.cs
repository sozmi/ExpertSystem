using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public class EntityViewModel : BaseViewModel<Entity>
    {
        public EntityViewModel(Entity entity) : base(entity)
        {
            if (original == null)
                return;
            Id = original.Id;
            Name = original.Name;
            State = original.State;
            foreach(var link in original.Links.Values)
                Links.Add(new(link));
        }

        public Guid Id {  get; set; }
        
        public string Name { get => name; set => SetProperty(ref name, value); }
        private string name = "";

        public EEntityState State { get => state; set => SetProperty(ref state, value); }
        private EEntityState state = EEntityState.Middle;

        public ObservableCollection<DataGridLinksViewModel> Links { get => links; set => SetProperty(ref links, value); }
        ObservableCollection<DataGridLinksViewModel> links = [];
        public bool SendChanges()
        {
            original.Id = Id;
            original.Name = Name;
            original.State = State;

            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null)
                return false;
            HashSet<KeyRelative> keys = [];
            foreach (var link in Links)
            {
                if (link.Relation.Id == Guid.Empty || link.Entity.Id == Guid.Empty)
                {
                    Common.MessageBox.Show("Присутствуют незаполненные связи", "Ошибка");
                    return false;
                }

                KeyRelative key = new(link.Entity.Id, link.Relation.Id);
                if (keys.Contains(key))
                {
                    Common.MessageBox.Show($"Есть одинаковые связи с отношением \"{link.Relation.Name}\" к сущности \"{link.Entity.Name}\"." +
                        $" Удалите повторы и повторите попытку.", "Ошибка");
                    return false;
                }
                keys.Add(key);
            }
            
            //TODO: это логика модели, нужно будет перенести
            var originalKeys = original.GetKeysRelative();
            foreach (var link in Links)
            {
                KeyRelative key = new(link.Entity.Id, link.Relation.Id);
                if (originalKeys.Contains(key))
                {
                    //если в оригинале есть такая связь, можно её просто заменить
                    var dblink = db.GetLink(new(Id, key));
                    link.SendChanges(dblink);
                }
                else
                {
                    var dblink = db.AddLink(new(Id, key));
                    link.SendChanges(dblink);
                }
                originalKeys.Remove(key);
            }    
            
            foreach (var key in originalKeys)
            {
                db.RemoveLink(new(Id, key));
            }

            return true;
        }

        public RelayCommand AddLinkCommand => addLinkCommand ??= new(obj => AddLink(obj));
        RelayCommand addLinkCommand;
        private void AddLink(object? _)
        {
            Link link = new(new(Guid.Empty,""), new(Guid.Empty,""));
            Links.Add(new(link));
        }

        public RelayCommand RemoveLinkCommand => removeLinkCommand ??= new(obj => RemoveLink(obj));
        RelayCommand removeLinkCommand;

        private DataGridLinksViewModel? _selectedItem;
        public DataGridLinksViewModel? SelectedLink
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        private void RemoveLink(object? _)
        {
            if (SelectedLink == null)
            {
                Common.MessageBox.Show("Необходимо выделить связь" , "Ошибка");
                return;
            }

            var index = Links.IndexOf(SelectedLink);
            SelectedLink = null;
            Links.RemoveAt(index);

        }
    }
};