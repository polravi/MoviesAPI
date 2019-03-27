using Microsoft.EntityFrameworkCore;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;

namespace MoviesAPI.DB
{
    public class MoviesContext : DbContext  
    {
        public MoviesContext()
        { }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        { }
        public DbSet<Movie> Movies { get ; set ; }
        public DbSet<Genre> Genres { get ; set ; }
        public DbSet<UserRating> UserRatings { get ; set; }

       
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 1, Title = "MoonLight", YearOfRelease = 2016, RunningTime = 145, AverageRating = 0, Genres = "Drama" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 2, Title = "Trainwreck", YearOfRelease = 2015, RunningTime = 125, AverageRating = 3, Genres = "Comedy,Drama,Romance" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 3, Title = "The Martian", YearOfRelease = 2015, RunningTime = 144, AverageRating = 4, Genres = "Adventure,Drama,Sci-Fi" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 4, Title = "Jurassic World", YearOfRelease = 2015, RunningTime = 124, AverageRating = 0, Genres = "Action, Adventure, Sci-Fi" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 5, Title = "Batman v Superman= Dawn of Justice", YearOfRelease = 2016, RunningTime = 151, AverageRating = 3.5, Genres = "Action,Adventure,Fantasy" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 6, Title = "Captain America= Civil War", YearOfRelease = 2016, RunningTime = 147, AverageRating = 3, Genres = "Action,Adventure,Sci-Fi" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 7, Title = "X-Men= Apocalypse", YearOfRelease = 2016, RunningTime = 144, AverageRating = 3.5, Genres = "Action,Adventure,Sci-Fi" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 8, Title = "Ride Along 2", YearOfRelease = 2016, RunningTime = 102, AverageRating = 0, Genres = "Action,Comedy" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 9, Title = "Finding Dory", YearOfRelease = 2016, RunningTime = 102, AverageRating = 0, Genres = "Action,Comedy" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 10, Title = "Logan", YearOfRelease = 2017, RunningTime = 137, AverageRating = 2, Genres = "Action,Drama,Sci-Fi" });
            //modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 11, Title = "Beauty and the Beast", YearOfRelease = 2017, RunningTime = 129, AverageRating = 3.5, Genres = "Family,Fantasy,Musical" });

            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 1, UserID = 1, MovieID = 3, Rating = 5, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 2, UserID = 1, MovieID = 2, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 3, UserID = 1, MovieID = 5, Rating = 4, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 4, UserID = 1, MovieID = 6, Rating = 5, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 5, UserID = 1, MovieID = 10, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 6, UserID = 1, MovieID = 11, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 7, UserID = 2, MovieID = 11, Rating = 5, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 8, UserID = 3, MovieID = 11, Rating = 2, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 9, UserID = 4, MovieID = 11, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 10, UserID = 2, MovieID = 7, Rating = 5, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 11, UserID = 3, MovieID = 7, Rating = 4, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 12, UserID = 4, MovieID = 7, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 13, UserID = 5, MovieID = 7, Rating = 1, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 14, UserID = 6, MovieID = 7, Rating = 5, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 15, UserID = 2, MovieID = 6, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 16, UserID = 3, MovieID = 6, Rating = 1, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 17, UserID = 3, MovieID = 5, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 18, UserID = 3, MovieID = 3, Rating = 3, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 1003, UserID = 1, MovieID = 7, Rating = 2, Movie = null });
            //modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 1004, UserID = 4, MovieID = 1, Rating = 4, Movie = null });

    }
    }
}
