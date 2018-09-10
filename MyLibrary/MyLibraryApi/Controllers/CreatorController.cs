﻿using System.Collections.Generic;
using System.Web.Http;

namespace MyLibraryApi.Controllers
{
    using DataMaster.Models;
    using DomainMaster;
    using System.Web.Http.Results;

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
        public void Post([FromBody]string value)
        {
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
