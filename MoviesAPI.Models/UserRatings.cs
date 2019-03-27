using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoviesAPI.Models
{
    public class UserRating
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int Rating { get; set; }

        public Movie Movie { get; set; }
    }
}
