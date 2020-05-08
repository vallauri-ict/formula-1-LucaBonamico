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
    public class RacesScoresController : ApiController
    {
        DbTools db = new DbTools();

        public IEnumerable<RacesScore> GetAllRacesScores()
        {
            return db.GetRacesScores().Values;
        }

        public IHttpActionResult GetRacesScore(int id)
        {
            try
            {
                RacesScore rS = GetAllRacesScores().ElementAt(id);
                return Ok(rS);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
