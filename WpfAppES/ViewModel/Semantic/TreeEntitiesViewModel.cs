﻿using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.Components.Semantic;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic
{
    public class TreeEntitiesViewModel : BaseViewModel<object>
    {
        List<IModelChanged> modelChangeds = [];
        public void Subscribe(IModelChanged modelChanged)
        {
            modelChangeds.Add(modelChanged);
        }
        public ObservableCollection<EntityTreeViewModel> Entities { get; set; } = [];
        public TreeEntitiesViewModel()
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null)
                return;

            foreach (var ent in db.GetEntities())
                Entities.Add(new(ent));
        }

        #region AddEntityCommand 
        /// <summary>
        /// Команда добавления новой сущности
        /// </summary>
        public RelayCommand AddEntityCommand => addEntityCommand ??= new(AddEntity);
        private RelayCommand? addEntityCommand;

        private void AddEntity(object? _)
        {
            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;
            Entity ent = new("Не указано");
            db.Create(ent);
            Entities.Add(new(ent));
            foreach(IModelChanged model in modelChangeds)
                model.OnGlobalChanged();
            //DrawGraph();
        }
        #endregion

        #region RemoveEntityCommand
        /// <summary>
        /// Команда удаления сущности
        /// </summary>
        public RelayCommand RemoveEntityCommand => removeEntityCommand ??= new(obj => RemoveEntity(obj));
        private RelayCommand? removeEntityCommand;

        private void RemoveEntity(object? obj)
        {
            if (obj == null) return;

            Guid? id = obj as Guid?;
            if (id == null) return;

            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;

            db.RemoveEntity((Guid)id);
            Entities.Clear();
            foreach (var ent in db.GetEntities())
                Entities.Add(new(ent));
            foreach (IModelChanged model in modelChangeds)
                model.OnGlobalChanged();
            // DrawGraph();
        }
        #endregion
        #region EditEntityCommand
        /// <summary>
        /// Команда добавления новой сущности
        /// </summary>
        public RelayCommand EditEntityCommand => editEntityCommand ??= new(obj => EditEntity(obj));
        private RelayCommand? editEntityCommand;

        private void EditEntity(object? obj)
        {
            if (obj == null) return;

            Guid? id = obj as Guid?;
            if (id == null) return;

            var db = KnowledgeBaseManager.Get().GetBase<SemanticDB>();
            if (db == null) return;
            EntityViewModel vme = new(db.GetEntity((Guid)id));
            EditEntityDlg entityDlg = new(vme);
            if (entityDlg.ShowDialog() != true)
                return;
            vme.SendChanges();

            //db.Edit(vme);
            Entities.Clear();
            foreach (var ent in db.GetEntities())
                Entities.Add(new(ent));
            //DrawGraph();
        }
        #endregion
    }
}