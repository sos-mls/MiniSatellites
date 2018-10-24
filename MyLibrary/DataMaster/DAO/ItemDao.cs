using System.Collections.Generic;
using System.Data;

namespace DataMaster.DAO
{
    using DataMaster.DTO;
    using DataMaster.Models;
    using System.Linq;

    public static class ItemDao
    {
        /// <summary>
        /// Gets all Items
        /// </summary>
        /// <returns>I collection of Items</returns>
        public static IEnumerable<IItem> Get()
        {
            IEnumerable<Item> items;
            BaseDao.ReadCollection("dbo.GetItem", null, BaseDao.InitializeType, out items);
            return items;
        }

        /// <summary>
        /// Gets a Item
        /// </summary>
        /// <param name="parameter">The Item ID</param>
        /// <returns>The Item</returns>
        public static IItem Get(IDataParameter parameter)
        {
            Item item;        
            BaseDao.Read("dbo.GetItem", new IDataParameter[] { parameter }, BaseDao.InitializeType, out item);
            return item;
        }

        /// <summary>
        /// Gets which Items are related to a Item
        /// </summary>
        /// <param name="parameter">The Item ID</param>
        /// <returns>An Item to Item relationship</returns>
        public static ItemRelationshipsDto GetRelations(IDataParameter parameter)
        {
            ItemRelationshipsDto dto;        
            BaseDao.Read("dbo.GetItemRelations", new IDataParameter[] { parameter }, BaseDao.InitializeType, out dto);
            dto.Item = Get(parameter);
            return dto;
        }

        /// <summary>
        /// Adds a new Item
        /// </summary>
        /// <param name="parameters">Details of an Item</param>
        /// <returns>The Item ID</returns>
        public static int Add(IEnumerable<IDataParameter> parameters)
        {
            int itemId = 0;
            BaseDao.Read("dbo.InsertItem", parameters.ToArray(), BaseDao.InitializeInt, out itemId);
            return itemId;
        }
    }
}
