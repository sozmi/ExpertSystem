using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.Entities.Item;

public class EntityViewModel : BaseViewModel
{
    public EntityViewModel(Guid id)
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null) return;
        Entity entity = db.GetEntity(id);
        Id = entity.Id;
        Name = entity.Name;
        foreach (var link in entity.Links.Values)
            Links.Add(new(link));
        addLinkCommand = new(AddLink);
        removeLinkCommand = new(RemoveLink);
    }

    public Guid Id { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }
    private string name = "";

    public ObservableCollection<RowLinkViewModel> Links { get => links; set => SetProperty(ref links, value); }
    ObservableCollection<RowLinkViewModel> links = [];

    public bool SaveChanges()
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null)
            return false;

        Entity newEnt = new(Id, Name);
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

        db.Edit(newEnt, keys);

        return true;
    }

    public RelayAction AddLinkCommand => addLinkCommand;
    readonly RelayAction addLinkCommand;
    private void AddLink()
    {
        Link link = new(new(Guid.Empty, ""), new(Guid.Empty, ""));
        Links.Add(new(link));
    }

    public RelayAction RemoveLinkCommand => removeLinkCommand;
    readonly RelayAction removeLinkCommand;

    private RowLinkViewModel? _selectedItem;
    public RowLinkViewModel? SelectedLink
    {
        get => _selectedItem;
        set => SetProperty(ref _selectedItem, value);
    }

    private void RemoveLink()
    {
        if (SelectedLink == null)
        {
            Common.MessageBox.Show("Необходимо выделить связь", "Ошибка");
            return;
        }

        var index = Links.IndexOf(SelectedLink);
        SelectedLink = null;
        Links.RemoveAt(index);
    }
}