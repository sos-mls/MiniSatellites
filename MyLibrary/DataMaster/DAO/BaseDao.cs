using DataMaster.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMaster.DAO
{
    public static class BaseDao
    {
        internal delegate void Initializer<T>(IDataReader record, out T value);


        internal static void Read<T>(string storedProcedure, IDataParameter[] dataParameters, Initializer<T> initializer, out T value)
        {
            IDbCommand command = SqlCommander.BuildCommand(storedProcedure, dataParameters);
            _Read(command, initializer, out value);
        }

        internal static void ReadCollection<T>(string storedProcedure, IDataParameter[] dataParameters, Initializer<T> initializer, out IEnumerable<T> values)
        {
            IDbCommand command = SqlCommander.BuildCommand(storedProcedure, dataParameters);
            _ReadCollection(command, initializer, out values);
        }


        internal static void Read<T>(IDbCommand command, Initializer<T> initializer, out T value)
        {
            _Read(command, initializer, out value);
        }

        internal static void ReadCollection<T>(IDbCommand command, Initializer<T> initializer, out IEnumerable<T> values)
        {
            _ReadCollection(command, initializer, out values);
        }


        private static void _Read<T>(IDbCommand command, Initializer<T> initializer, out T value)
        {
            using (command)
            {
                command.Connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    value = default(T);

                    if (reader.Read())
                        initializer(reader, out value);
                }

                command.Connection.Close();
                command.Parameters.Clear();
            }
        }

        private static void _ReadCollection<T>(IDbCommand command, Initializer<T> initializer, out IEnumerable<T> values)
        {
            IList<T> items = new List<T>();

            using (command)
            {
                command.Connection.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T t;
                        initializer(reader, out t);
                        items.Add(t);
                    }
                        
                }

                command.Connection.Close();
                command.Parameters.Clear();
            }

            values = items;
        }



        internal static void InitializeType<T>(IDataReader record, out T value)
        {
            value = (T) Activator.CreateInstance(typeof(T), new object[] { record });
        }

        internal static void InitializeInt(IDataReader record, out int value)
        {
            value = record.GetInt32(0);
        }

        internal static void InitializeString(IDataReader record, out string value)
        {
            value = record.GetString(0);
        }
    }
}
