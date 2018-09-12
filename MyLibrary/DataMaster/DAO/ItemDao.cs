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

        public static IItem Get(int itemId)
        {
            IItem item;

            using (SqlCommand command = new SqlCommand())
            using (SqlConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetItem";

                command.Parameters.Add(new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = itemId });

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



        public static ItemRelationshipsDto GetRelations(int itemId)
        {
            IItem item = Get(itemId);

            ItemRelationshipsDto dto;

            IList<IItem> items = new List<IItem>();
            IList<IItemRelation> relations = new List<IItemRelation>();

            using (SqlCommand command = new SqlCommand())
            using (SqlConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetItemRelations";

                command.Parameters.Add(new SqlParameter("@ItemID", SqlDbType.VarChar) { Value = itemId });

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
    }
}
