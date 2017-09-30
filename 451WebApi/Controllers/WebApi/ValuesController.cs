using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _451WebApi.Controllers.WebApi
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get() => Ok("from values controller without any versions");

        [Route("Constants")]
        public IHttpActionResult GetConstants() => Ok("Constants");
    }
}
