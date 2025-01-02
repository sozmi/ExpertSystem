using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases
{
    public class RowFactsViewModel : BaseViewModel
    {
        public RowFactsViewModel(Fact fact_)
        {
            relation = fact_.Relation;
            from = fact_.From;
            to = fact_.To;
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null)
                return;
            AllRelations = db.GetRelations();
            AllEntities = db.GetEntities(false);
        }
        public static List<RelationType> AllRelations { get; set; } = [];
        public static List<Entity> AllEntities { get; set; } = [];


        public RelationType Relation { get => relation; set => SetProperty(ref relation, value); }
        private RelationType relation;

        public Entity From { get => from; set => SetProperty(ref from, value); }
        private Entity from;

        public Entity To { get => to; set => SetProperty(ref to, value); }
        private Entity to;

        public static implicit operator Fact(RowFactsViewModel v)
        {
            Fact f = new()
            {
                From = v.From,
                Relation = v.Relation,
                To = v.To
            };
            return f;
        }
    }
}
