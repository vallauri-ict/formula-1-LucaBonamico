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
    [RoutePrefix("api/racesScores")]
    public class RacesScoresController : ApiController
    {
        DbTools db = new DbTools();

        [Route("list")]
        public IEnumerable<RacesScore> GetAllRacesScores()
        {
            return db.GetRacesScores().Values;
        }

        [Route("{id:int}")]
        public IHttpActionResult GetRacesScore(int id)
        {
            try
            {
                RacesScore rS = db.GetRacesScores()[id];
                return Ok(rS);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
