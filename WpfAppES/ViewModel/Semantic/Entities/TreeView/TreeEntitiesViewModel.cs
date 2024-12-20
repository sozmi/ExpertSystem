﻿using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.Components.Semantic;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.Entities.TreeView;

public class TreeEntitiesViewModel : CollectionViewModel, IModelChanged
{
    public ObservableCollection<NodeEntityViewModel> Entities { get; set; } = [];
    public TreeEntitiesViewModel()
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null)
            return;

        foreach (var ent in db.GetEntities())
            Entities.Add(new(ent));
        Subscribe(OnGlobalChanged);
    }

    #region AddEntityCommand 
    /// <summary>
    /// Команда добавления новой сущности
    /// </summary>
    public RelayCommand AddEntityCommand => addEntityCommand ??= new(AddEntity);
    private RelayCommand? addEntityCommand;

    private void AddEntity(object? _)
    {
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null) return;
        Entity ent = new("Не указано");
        db.Create(ent);
        Entities.Add(new(ent));
        OnCollectionChanged();
        //DrawGraph();
    }
    #endregion

    #region RemoveEntityCommand
    /// <summary>
    /// Команда удаления сущности
    /// </summary>
    public RelayCommand RemoveEntityCommand => removeEntityCommand ??= new(RemoveEntity);
    private RelayCommand? removeEntityCommand;

    private void RemoveEntity(object? id)
    {
        if (id == null || id is not Guid)
            return;

        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null) return;

        db.RemoveEntity((Guid)id);
        Entities.Clear();
        foreach (var ent in db.GetEntities())
            Entities.Add(new(ent));
        OnCollectionChanged();
    }
    #endregion
    #region EditEntityCommand
    /// <summary>
    /// Команда добавления новой сущности
    /// </summary>
    public RelayCommand EditEntityCommand => editEntityCommand ??= new(EditEntity);
    private RelayCommand? editEntityCommand;

    private void EditEntity(object? obj)
    { 
        if (obj != null && obj is Guid id)
        {
            EditEntityDlg entityDlg = new(id);
            if (entityDlg.ShowDialog() != true)
                return;
            OnCollectionChanged();
        }
    }

    public void OnGlobalChanged()
    {
        Entities.Clear();
        var db = KnowledgeBaseManager.GetBase<SemanticDB>();
        if (db == null) return;
        foreach (var ent in db.GetEntities())
            Entities.Add(new(ent));
    }
    #endregion
}
