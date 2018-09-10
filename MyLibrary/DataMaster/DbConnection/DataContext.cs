using System;
using System.Data;
using System.Data.SqlClient;

namespace NASCAR.VehicleManager.Models
{
    public class DataContext
    {
        #region Properties

        public static string DatabaseName { get; set; }
        public static string DatabaseServer { get; set; }
        public static string DatabasePassword { get; set; }
        public static string DatabasUserId { get; set; }

        #endregion

        #region Fields

        /// <summary>
        /// local variable to hold ConnectionString property value
        /// </summary>
        private static string _connectionString;

        public static string ConnectionString { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the connection string
        /// </summary>
        /// <remarks>
        /// concatenates the Database[name] and Server into the connection string
        /// user name and password, if required, can also be added in here.
        /// </remarks>
        private static void BuildConnectionString()
        {
            //use the sql connection string builder to create our connection string
            //setting the pooling to false will ensure that we don't keep the connection
            //open the entire time the app is open, this means we don't have to worry
            //about the user not having closed the app before we import or export
            //the database
            //we may need to set pooling to true if this causes issues, but this means
            //that the import/export will fail if one person forgets to close this app
            var scsb = new SqlConnectionStringBuilder
            {
                InitialCatalog = DatabaseName,
                IntegratedSecurity = false,
                PersistSecurityInfo = false,
                Pooling = true,
                DataSource = DatabaseServer,
                UserID = DatabasUserId,
                Password = DatabasePassword,
            };

            //set our local variable to the string builder's connection string property
            _connectionString = scsb.ConnectionString;
        }

        /// <summary>
        /// Executes a non query command
        /// </summary>
        /// <param name="cmd">The non query command to execute</param>
        /// <returns>The number of rows affected</returns>
        internal static int ExecuteNonQueryCommand(SqlCommand cmd)
        {
            int rVal;
            //create the connection
            using (var connection = new SqlConnection(ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                cmd.Connection = connection;

                //execute the command
                rVal = cmd.ExecuteNonQuery();

                //close the connection
                connection.Close();
            }

            //return the result
            return rVal;
        }

        /// <summary>
        /// Executes a requested count command
        /// </summary>
        /// <param name="cmd">The counting command to execute</param>
        /// <returns>The number of rows affected</returns>
        internal static int ExecuteCountCommand(SqlCommand cmd)
        {
            int rVal;
            //create the connection
            using (var connection = new SqlConnection(ConnectionString))
            {
                //open the connection
                connection.Open();

                //attach the connection to the command
                cmd.Connection = connection;

                //execute the command
                rVal = Convert.ToInt32(cmd.ExecuteScalar());

                //close the connection
                connection.Close();
            }

            //return the result
            return rVal;
        }

        /// <summary>
        /// Executes the specified command and returns a dataset
        /// </summary>
        /// <param name="cmd">The command to execute</param>
        /// <returns>a dataset</returns>
        internal static DataTable GetDataTable(SqlCommand cmd)
        {
            //create our return value
            var rVal = new DataTable();

            //create the connection
            using (var connection = new SqlConnection(ConnectionString))
            {

                //open the connection
                connection.Open();

                //attach the connection to the command
                cmd.Connection = connection;

                //use a reader to fetch the data (faster than an adapter)
                using (var reader = cmd.ExecuteReader())
                {
                    rVal.Load(reader);
                }

                connection.Close();

            }

            return rVal;
        }
        #endregion
    }
}
