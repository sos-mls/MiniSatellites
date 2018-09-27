namespace DomainMaster.Services
{
    using DataMaster.DAO;
    using DataMaster.DTO;
    using DataMaster.Models;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ItemService
    {
        public ItemRelationshipsDto GetItemRelations(int itemId)
        {
            IDbDataParameter itemParameter = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = itemId };
            return ItemDao.GetRelations(itemParameter);
        }

        public IEnumerable<IItem> Get()
        {
            return ItemDao.Get();
        }

        public IItem Get(int itemId)
        {
            IDbDataParameter itemParameter = new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = itemId };
            return ItemDao.Get(itemParameter);
        }

        public IItem Insert(string name, string json = null)
        {
            IDbDataParameter nameParameter = new SqlParameter("@Name", SqlDbType.VarChar) { Value = name };
            IDbDataParameter jsonParameter = new SqlParameter("@Json", SqlDbType.VarChar) { Value = json };
            
            int itemId = ItemDao.Add(new List<IDbDataParameter>() { nameParameter, jsonParameter });

            return new Item(name, json, itemId);
        }
    }
}
