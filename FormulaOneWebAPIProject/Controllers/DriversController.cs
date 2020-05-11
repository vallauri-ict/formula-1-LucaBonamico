using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FormulaOneDll;

namespace FormulaOneWebAPIProject.Controllers
{
    [RoutePrefix("api/drivers")]
    public class DriversController : ApiController
    {
        DbTools db = new DbTools();

        [Route("list")]
        public IEnumerable<Driver> GetAllDrivers()
        {
            return db.GetDrivers().Values;
        }

        [Route("{id:int}")]
        public IHttpActionResult GetDriver(int id)
        {
            try
            {
                Driver d = db.GetDrivers()[id];
                return Ok(d);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
