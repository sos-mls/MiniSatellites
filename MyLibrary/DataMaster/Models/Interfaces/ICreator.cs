namespace DataMaster.Models
{
    public interface ICreator
    {
        int Id { get; set; }
        string Name { get; set; }
        string Json { get; set; }
    }
}
