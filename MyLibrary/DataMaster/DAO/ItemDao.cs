using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataMaster.DAO
{
    using DataMaster.DbConnection;
    using DataMaster.DTO;
    using DataMaster.Models;

    public static class ItemDao
    {
        /// <summary>
        /// Gets all Items
        /// </summary>
        /// <returns>I collection of Items</returns>
        public static IEnumerable<IItem> Get()
        {
            IList<IItem> items = new List<IItem>();

            using (IDbCommand command = new SqlCommand())
            using (IDbConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetItem";

                //use a reader to fetch the data (faster than an adapter)
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item(reader));
                    }
                }

                connection.Close();
            }

            return items;
        }

        /// <summary>
        /// Gets a Item
        /// </summary>
        /// <param name="parameter">The Item ID</param>
        /// <returns>The Item</returns>
        public static IItem Get(IDbDataParameter parameter)
        {
            IItem item;

            using (IDbCommand command = new SqlCommand())
            using (IDbConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetItem";

                command.Parameters.Add(parameter);

                //use a reader to fetch the data (faster than an adapter)
                using (IDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    item = new Item(reader);
                }

                connection.Close();
            }

            return item;
        }

        /// <summary>
        /// Gets which Items are related to a Item
        /// </summary>
        /// <param name="parameter">The Item ID</param>
        /// <returns>An Item to Item relationship</returns>
        public static ItemRelationshipsDto GetRelations(IDbDataParameter parameter)
        {
            IItem item = Get(parameter);

            ItemRelationshipsDto dto;

            IList<IItem> items = new List<IItem>();
            IList<IItemRelation> relations = new List<IItemRelation>();

            using (IDbCommand command = new SqlCommand())
            using (IDbConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetItemRelations";

                command.Parameters.Add(parameter);

                //use a reader to fetch the data (faster than an adapter)
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        relations.Add(new ItemRelation(reader));
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        items.Add(new Item(reader));
                    }
                }

                connection.Close();

                dto = new ItemRelationshipsDto(item, items, relations);
            }

            return dto;
        }

        /// <summary>
        /// Adds a new Item
        /// </summary>
        /// <param name="parameters">Details of an Item</param>
        /// <returns>The Item ID</returns>
        public static int Add(IEnumerable<IDbDataParameter> parameters)
        {
            int itemId = 0;
            using (IDbCommand command = new SqlCommand())
            using (IDbConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertItem";

                command.Parameters.Add(parameters);

                //use a reader to fetch the data (faster than an adapter)
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itemId = reader.GetInt32(0);
                    }
                }

                connection.Close();
            }

            return itemId;
        }
    }
}
