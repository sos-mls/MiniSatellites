using System.Collections.Generic;

namespace DomainMaster.Services
{
    using DataMaster.DAO;
    using DataMaster.Models;

    public class CreatorService
    {
        /// <summary>
        /// Gets all creators
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ICreator> GetCreators()
        {
            return CreatorDao.Get();
        }

        /// <summary>
        /// Instansiates new Creator object and passes to DAO
        /// </summary>
        /// <param name="name">name of creator</param>
        /// <param name="json">additional info</param>
        /// <returns></returns>
        public ICreator AddCreator(string name, string json)
        {
            ICreator creator = new Creator(name, json);

            return CreatorDao.Add(creator);
        }
    }
}
