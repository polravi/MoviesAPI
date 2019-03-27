using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserRatings : Controller
    {
        private readonly IUserRatingBL userRatingBL;
        public UserRatings(IUserRatingBL BL)
        {
            userRatingBL = BL;
        }
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(typeof(UserRating), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var ret = userRatingBL.AllRating();
            if (ret == null || ret.Count ==0)
                return NotFound();

            return Ok(ret);
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]UserRating userRating)
        {
            dynamic ret;
            if (userRating == null)
                return BadRequest();

            if (userRating.UserID == 0 || userRating.MovieID == 0 )
                return BadRequest();

            if (userRating.Rating >= 1 && userRating.Rating <= 5)
                ret = userRatingBL.PostRating(userRating.UserID, userRating.MovieID, userRating.Rating);
            else
                return BadRequest();

            if ( ret == false)
                return NotFound();

            return Ok(ret);
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
