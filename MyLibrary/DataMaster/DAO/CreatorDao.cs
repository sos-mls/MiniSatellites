using System.Collections.Generic;

namespace DataMaster.DAO
{
    using DataMaster.DbConnection;
    using DataMaster.Models;
    using System.Data;
    using System.Data.SqlClient;

    public class CreatorDao
    {

        public IEnumerable<ICreator> GetCreators()
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
    }
}
