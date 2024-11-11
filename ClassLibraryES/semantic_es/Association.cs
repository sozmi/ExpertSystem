using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLibraryES.Semantic
{
    public class Association
    {
        Relation relation;
        Entity entity;
        public Association(Relation relation, Entity entity)
        {
            this.relation = relation;
            this.entity = entity;
        }

        public Association(Tuple<Guid, Guid> tuple)
        {

        }

        [JsonPropertyName("association")]
        public Tuple<Guid, Guid> GetIds => new(relation.Id, entity.Id);
    }
}
