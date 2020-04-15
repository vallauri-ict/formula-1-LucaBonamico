using FormulaOneDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FormulaOneWebAPIProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RacesController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Race> GetAllRaces()
        {
            return db.GetRaces().Values;
        }

        public IHttpActionResult GetRace(int id)
        {
            try
            {
                Race r = GetAllRaces().ElementAt(id);
                return Ok(r);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
