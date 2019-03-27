using Microsoft.EntityFrameworkCore;
using MoviesAPI.DB;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.BusinessLayer
{
    public class MoviesBL : IMoviesBL
    {
        private readonly MoviesContext db;
         
        public MoviesBL(MoviesContext context)
        {
            db = context;
        }

        public IList<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public IList<Movie> GetMovieByCriteria(int YoR, string Title, string Genre)
        {
            dynamic res = null ;
            //All 3 criterias are provided
            if (YoR > 1900 && !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Genre))
            {
                res = db.Movies.Where
                (
                    y => y.YearOfRelease == YoR
                    && y.Title.Contains(Title)
                    && y.Genres.Contains(Genre)

                ).ToList();
            }

            //Only YoR 
            if (YoR >1900 && string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Genre) )
            {
                res = db.Movies.Where
               (
                   y => y.YearOfRelease == YoR
               ).ToList();
            }

            //Only Title
            if (YoR <=1900 && !string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Genre))
            {
                res = db.Movies.Where
               (
                   y => y.Title.Contains(Title)
               ).ToList();
            }


            //Only Genre
            if (YoR <= 1900 && string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Genre))
            {
                res = db.Movies.Where
               (
                   y => y.Genres.Contains(Genre)
               ).ToList();
            }

            //YoR and Title
            if (YoR > 1900 && !string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Genre))
            {
                res = db.Movies.Where
               (
                   y => y.YearOfRelease == YoR
                   && y.Title.Contains(Title)
               ).ToList();
            }

            //YoR and Genre
            if (YoR > 1900 && string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Genre))
            {
                res = db.Movies.Where
               (
                   y => y.YearOfRelease == YoR
                   && y.Genres.Contains(Genre)
               ).ToList();
            }

            //Title and Genre
            if (YoR <= 1900 && !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Genre))
            {
                res = db.Movies.Where
               (
                   y => y.Title.Contains(Title)
                   && y.Genres.Contains(Genre)
               ).ToList();
            }


            return res;
        }

        public IList<Movie> GetTop5Movies()
        {
            return db.Movies.OrderByDescending(a => a.AverageRating).ThenBy(b => b.Title).Take(5).ToList();
        }

        public IList<Movie> GetTop5MovieByUser(int UserId)
        {
            var userratings =  db.UserRatings
                .Where(a => a.UserID == UserId)
                //                
                .Include(m => m.Movie)
                .Select(b =>
                new
                {
                    b.Rating
                    ,
                    b.Movie
                }
                )
                .OrderByDescending(m => m.Rating)
                .ThenBy(t => t.Movie.Title)
                .Take(5)
                .Select(c=>c.Movie)
                .ToList();

            return userratings;
        }

        public Movie PostMovie(Movie movie)
        {
           //var carmovie= new Movie()
           //{ 
              
           //    Title = "Rocky",
           //    YearOfRelease =1988,
           //    RunningTime = 1.55,
           //    AverageRating = 0,
           //    MovieGenres = new List<MovieGenre>() {  }
           //}
           // ;

            db.Movies.Add(movie);
            db.SaveChanges();
            return movie;
        }
    }
}
