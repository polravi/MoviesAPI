using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.BusinessLayer;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    public class Movies : Controller
    {
        private readonly IMoviesBL moviesBL;
        //private readonly IMoviesContext db;

        public Movies(IMoviesBL BL)
        {
            moviesBL = BL;
            
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("GetTop5Movies")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var ret = moviesBL.GetTop5Movies();
            if (ret== null || ret.Count == 0)
            {
                return NotFound();
            }
            return Ok(ret);
        }


        [HttpGet]
        [Route("GetAllMovies")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var ret = moviesBL.GetAll();
            if (ret == null || ret.Count == 0)
            {
                return NotFound();
            }
            return Ok(ret);
        }

        // GET api/<controller>/5
        [HttpGet("{userid}")]
        [Route("GetTop5MoviesByUserID")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int userid)
        {
            if ( userid == 0)
            {
                return BadRequest();
            }
            var ret = moviesBL.GetTop5MovieByUser(userid);
            if (ret == null || ret.Count == 0)
            {
                return NotFound();
            }
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetMoviesByCriteria")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetMovies(int yor, string title, string genre  )
        {
            if (yor <= 0 && string.IsNullOrEmpty( title) && string.IsNullOrEmpty(genre))
            {
                return BadRequest();
            }

            var ret = moviesBL.GetMovieByCriteria(yor, title, genre);
            if (ret == null || ret.Count==0)
            {
                return NotFound();
            }
            return Ok(ret);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("postMovie")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Movie movie)
        {
            moviesBL.PostMovie(movie);
            return Ok(movie);
           // var mbl = ne
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
