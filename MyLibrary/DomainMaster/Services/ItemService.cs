namespace DomainMaster.Services
{
    using DataMaster.DAO;
    using DataMaster.DTO;

    public class ItemService
    {
        public ItemRelationshipsDto GetItemRelations(int itemId)
        {
            return ItemDao.GetRelations(itemId);
        }
    }
}
