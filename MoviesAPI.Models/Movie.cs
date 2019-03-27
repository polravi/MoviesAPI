using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public double RunningTime { get; set; }
        private double averageRating;
        public double AverageRating {
            get
            {
                return Math.Round(averageRating * 2, MidpointRounding.AwayFromZero) / 2;
            }
            set
            {
                this.averageRating = value;
            }
        }
        public string Genres { get; set; }
         
    }
}
