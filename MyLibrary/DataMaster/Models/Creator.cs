using System.Data;

namespace DataMaster.Models
{
    public class Creator : ICreator
    {
        public Creator(string name, string json)
        {
            Name = name;
            Json = json;
        }

        public Creator(IDataReader reader)
        {
            Id = reader.GetInt32(0);
            Name = reader.GetString(1);
            Json = (reader["Json"] != System.DBNull.Value) ? reader.GetString(2) : null;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }
    }
}
