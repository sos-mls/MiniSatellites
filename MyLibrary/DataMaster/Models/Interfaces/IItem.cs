namespace DataMaster.Models
{
    public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        string Json { get; set; }
    }
}
