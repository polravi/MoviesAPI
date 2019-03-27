using MoviesAPI.DB;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.BusinessLayer
{
    public class UserRatingBL : IUserRatingBL
    {
        private readonly MoviesContext db;
        public UserRatingBL(MoviesContext context)
        {
            db = context;
        }

        public IList<UserRating> AllRating()
        {
            return db.UserRatings.ToList();
        }

        public bool PostRating(int userId, int movieId, int rating)
        {
            try
            {
                var movies = db.Movies.Where(a => a.Id == movieId).ToList();
                if (movies ==null || movies.Count == 0)
                    return false;

                UserRating userrating = db.UserRatings.Where(a => a.UserID == userId && a.MovieID == movieId).FirstOrDefault();

                if (userrating != null)
                {
                    userrating.Rating = rating;
                    db.UserRatings.Update(userrating);
                }
                else
                {
                    userrating = new UserRating()
                    {
                        UserID = userId,
                        MovieID = movieId,
                        Rating = rating
                    };
                    db.UserRatings.Add(userrating);
                }

                db.SaveChanges();

                var movie_average_rating = db.UserRatings.Where(a => a.MovieID == movieId).Average(b => b.Rating);
                var movie = db.Movies.Where(a => a.Id == movieId).FirstOrDefault();
                movie.AverageRating = movie_average_rating;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
