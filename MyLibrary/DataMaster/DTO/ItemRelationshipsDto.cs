using System.Collections.Generic;

namespace DataMaster.DTO
{
    using DataMaster.Models;

    public class ItemRelationshipsDto
    {

        public ItemRelationshipsDto(IItem item, IList<IItem> items, IList<IItemRelation> relations)
        {
            Item = item;
            Items = items;
            Relations = relations;
        }

        public IItem Item { get; set; }
        public IList<IItem> Items { get; set; }
        public IList<IItemRelation> Relations { get; set; }
    }
}
