using System.Collections.Generic;

namespace DataMaster.DTO
{
    using DataMaster.Models;
    using System.Data;

    public class ItemRelationshipsDto
    {
        public ItemRelationshipsDto(IDataReader reader)
        {
            Relations = new List<IItemRelation>();

            Relations.Add(new ItemRelation(reader));

            while (reader.Read())
            {
                Relations.Add(new ItemRelation(reader));
            }

            reader.NextResult();

            Items = new List<IItem>();

            while (reader.Read())
            {
                Items.Add(new Item(reader));
            }
        }

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
