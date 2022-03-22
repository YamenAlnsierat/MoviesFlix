using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieflix_api.Data;
using movieflix_api.Models;

namespace movieflix_api.Controllers
{
    [ApiController]
    [Route("api/v1/movies")]
    public class moviesController : ControllerBase
    {
        private readonly DataContext _context;
        public moviesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Movie>>>ListMovies()
        {
            var movies = await _context.Movies.ToListAsync();
           return Ok(movies);
        }

        [HttpPost()]
        public ActionResult<Movie> AddMovies(Movie movie){
            return new Movie();
        }
    
        [HttpGet("{title}")]
        public ActionResult<Movie> myMovie(string title)
        {
            return Ok("Mirrors");
        }
    }
}