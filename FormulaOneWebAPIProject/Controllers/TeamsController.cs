﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FormulaOneDll;

namespace FormulaOneWebAPIProject.Controllers
{
    [RoutePrefix("api/teams")]
    public class TeamsController : ApiController
    {
        DbTools db = new DbTools();

        [Route("list")]
        public IEnumerable<Team> GetAllTeams()
        {
            return db.LoadTeams();
        }

        [Route("{id:int}")]
        public IHttpActionResult GetTeam(int id)
        {
            try
            {
                Team t = GetAllTeams().ElementAt(id);
                return Ok(t);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
