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
    [RoutePrefix("api/circuits")]
    public class CircuitsController : ApiController
    {

        DbTools db = new DbTools();

        [Route("list")]
        public IEnumerable<Circuit> GetAllCircuits()
        {
            return db.GetCircuits().Values;
        }

        [Route("{id:int}")]
        public IHttpActionResult GetCircuit(int id)
        {
            try
            {
                Circuit c = db.GetCircuits()[id];
                return Ok(c);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
