using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace MyLibraryApi.Controllers
{
    using DataMaster.DTO;
    using DataMaster.Models;
    using DomainMaster.Services;

    public class ItemController : ApiController
    {
        // GET: api/Item/GetItemRelations
        public JsonResult<ItemRelationshipsDto> GetRelations(int itemId)
        {
            ItemService service = new ItemService();
            ItemRelationshipsDto dto = service.GetItemRelations(itemId);
            return Json(dto);
        }

        // GET: api/Item
        public JsonResult<IEnumerable<IItem>> Get()
        {
            ItemService service = new ItemService();
            IEnumerable<IItem> dto = service.Get();
            return Json(dto);
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
