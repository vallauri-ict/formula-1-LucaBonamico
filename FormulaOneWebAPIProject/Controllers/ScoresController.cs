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
    public class ScoresController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<Score> GetAllScores()
        {
            return db.GetScores().Values;
        }

        public IHttpActionResult GetRacesScore(int id)
        {
            try
            {
                Score s = GetAllScores().ElementAt(id);
                return Ok(s);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
