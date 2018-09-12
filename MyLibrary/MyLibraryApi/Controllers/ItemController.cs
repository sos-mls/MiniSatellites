using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace MyLibraryApi.Controllers
{
    using DataMaster.DTO;
    using DomainMaster.Services;

    public class ItemController : ApiController
    {
        // GET: api/Item/GetItemRelations
        public JsonResult<ItemRelationshipsDto> GetItemRelations(int itemId)
        {
            ItemService service = new ItemService();
            ItemRelationshipsDto dto = service.GetItemRelations(itemId);
            return Json(dto);
        }

        // GET: api/Item
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Item/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Item
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Item/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Item/5
        public void Delete(int id)
        {
        }
    }
}
