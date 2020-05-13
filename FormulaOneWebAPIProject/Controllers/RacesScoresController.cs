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
                List<RacesScore> rS = db.GetRacesScores().Values.ToList().FindAll(r => r.Race.Id == id);
                rS = rS.OrderBy(r => r.Pos.Pos).ToList();
                for (int i = 0; i < rS.Count; i++)
                {
                    if (rS[i].Pos.Pos == 0)
                    {
                        RacesScore r = rS[i];
                        rS.RemoveAt(i--);
                        rS.Add(r);
                    }
                    else
                        break;
                }
                return Ok(rS);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
