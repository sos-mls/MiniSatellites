using System.Data;

namespace DataMaster.Models
{
    public class Item : IItem
    {
        public Item(string name, string json, int id = 0)
        {
            Name = name;
            Json = json;
            Id = id;
        }

        public Item(IDataReader reader)
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
