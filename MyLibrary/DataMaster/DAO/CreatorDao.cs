using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataMaster.DAO
{
    using DataMaster.DbConnection;
    using DataMaster.Models;
    using System;

    /// <summary>
    /// Turn this class into a Singleton
    /// </summary>
    public static class CreatorDao
    {
        public static IEnumerable<ICreator> Get()
        {
            IList<ICreator> creators = new List<ICreator>();

            using (SqlCommand command = new SqlCommand())
            using (SqlConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCreators";

                //use a reader to fetch the data (faster than an adapter)
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        creators.Add(new Creator(reader));
                    }
                }

                connection.Close();
            }

            return creators;
        }

        public static ICreator Add(ICreator creator)
        {
            using (SqlCommand command = new SqlCommand())
            using (SqlConnection connection = new SqlConnection(SqlCommander.ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.InsertCreator";

                //add the command parameters
                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar) { Value = creator.Name });
                command.Parameters.Add(new SqlParameter("@Json", SqlDbType.VarChar) { Value = creator.Json });                

                //use a reader to fetch the data (faster than an adapter)
                creator.Id = Convert.ToInt32( command.ExecuteScalar() );

                connection.Close();
            }

            return creator;
        }
    }
}
