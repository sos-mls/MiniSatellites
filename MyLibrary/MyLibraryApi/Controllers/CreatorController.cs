using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace MyLibraryApi.Controllers
{
    using DataMaster.Models;
    using DomainMaster.Services;

    public class CreatorController : ApiController
    {
        // GET: api/Creator
        public JsonResult<IEnumerable<ICreator>> Get()
        {
            CreatorService service = new CreatorService();
            return Json(service.GetCreators());
        }

        // GET: api/Creator/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Creator
        public void Post([FromBody]string name)
        {
            CreatorService service = new CreatorService();
            service.AddCreator(name, null);
        }

        // PUT: api/Creator/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Creator/5
        public void Delete(int id)
        {
        }
    }
}
