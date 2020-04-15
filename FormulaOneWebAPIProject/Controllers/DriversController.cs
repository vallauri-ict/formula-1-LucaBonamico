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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DriversController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Driver> GetAllDrivers()
        {
            return db.GetDrivers().Values;
        }

        public IHttpActionResult GetDriver(int id)
        {
            try
            {
                Driver d = GetAllDrivers().ElementAt(id);
                return Ok(d);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
