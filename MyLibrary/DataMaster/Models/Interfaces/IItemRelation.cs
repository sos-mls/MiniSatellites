namespace DataMaster.Models
{
    public interface IItemRelation
    {
        int Id { get; }
        int ItemOneId { get; }
        int ItemTwoId { get; }
    }
}
