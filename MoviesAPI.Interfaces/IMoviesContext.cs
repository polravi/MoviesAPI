using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using System;

namespace MoviesAPI.Interfaces
{
    public interface IMoviesContext  
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<UserRating> UserRatings { get; set; }

        //void SaveChanges();
        //void SaveChangesAsync();
    }

}