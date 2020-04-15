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
    public class CircuitsController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Circuit> GetAllCircuits()
        {
            return db.GetCircuits().Values;
        }

        public IHttpActionResult GetCircuit(int id)
        {
            try
            {
                Circuit c = GetAllCircuits().ElementAt(id);
                return Ok(c);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
