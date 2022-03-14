using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieflix_api.Models;

namespace movieflix_api.Controllers
{
    [ApiController]
    [Route("api/v1/movies")]
    public class moviesController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<IEnumerable<Movie>>ListMovies()
        {
            return Ok(new List<string>());
        }
    
        [HttpGet("{title}")]
        public ActionResult<Movie> myMovie(string title)
        {
            return Ok("Mirrors");
        }
    }
}