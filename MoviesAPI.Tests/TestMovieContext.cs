using Microsoft.EntityFrameworkCore;
using MoviesAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesAPI.Tests
{
    public class TestMovieContext : DbContext, IMoviesContext
    {
        public TestMovieContext()
        {
            this.Movies = new List<Movie>();
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
    }
}
