using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace SecurityAPI.Controllers
{
    public class AuditController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        public IHttpActionResult Post([FromBody]dynamic value)
        {
            try
            {
                log.Info("Starting");
                log.Info(value.ToString());
                JArray notifications = JArray.Parse(value.ToString());
                foreach (var notification in notifications)
                {
                    log.Info(notification["contentUri"].ToString());
                }

            }
            catch (Exception ex)
            {
                log.Info(ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
           
            return Ok("test");
        }
    }
}
