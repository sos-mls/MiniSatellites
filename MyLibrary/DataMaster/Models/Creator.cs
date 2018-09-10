using System.Data;

namespace DataMaster.Models
{
    public class Creator : ICreator
    {

        public Creator(IDataReader reader)
        {
            Id = reader.GetInt32(0);
            Name = reader.GetString(1);
            Hash = reader.GetString(2);
            Json = reader.GetString(3)
;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public string Json { get; set; }
    }
}
