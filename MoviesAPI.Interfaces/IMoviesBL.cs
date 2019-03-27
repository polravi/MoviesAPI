using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesAPI.Interfaces
{
    public interface IMoviesBL
    {
        IList<Movie> GetMovieByCriteria(int YoR, string Title, string Genre);
        IList<Movie> GetTop5MovieByUser(int UserId);
        IList<Movie> GetTop5Movies();
        IList<Movie> GetAll();
        Movie PostMovie(Movie movie);
    }
}
