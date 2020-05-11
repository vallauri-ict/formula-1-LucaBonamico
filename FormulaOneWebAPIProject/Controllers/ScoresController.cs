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
    [RoutePrefix("api/scores")]
    public class ScoresController : ApiController
    {
        DbTools db = new DbTools();

        [Route("list")]
        public IEnumerable<Score> GetAllScores()
        {
            return db.GetScores().Values;
        }

        [Route("{id:int}")]
        public IHttpActionResult GetRacesScore(int id)
        {
            try
            {
                Score s = db.GetScores()[id];
                return Ok(s);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
