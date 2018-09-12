using System.Data;

namespace DataMaster.Models
{
    public class ItemRelation : IItemRelation
    {
        public ItemRelation(IDataReader reader)
        {
            Id = reader.GetInt32(0);
            ItemOneId = reader.GetInt32(1);
            ItemTwoId = reader.GetInt32(2);
        }

        public int Id { get; }
        public int ItemOneId { get; }
        public int ItemTwoId { get; }
    }
}
