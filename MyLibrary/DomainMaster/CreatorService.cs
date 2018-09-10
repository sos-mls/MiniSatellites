using System.Collections.Generic;

namespace DomainMaster
{
    using DataMaster.DAO;
    using DataMaster.Models;

    public class CreatorService
    {
        public IEnumerable<ICreator> GetCreators()
        {
            return CreatorDao.GetCreators();
        }
    }
}
