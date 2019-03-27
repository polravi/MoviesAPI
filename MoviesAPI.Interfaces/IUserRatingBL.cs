using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IUserRatingBL
    {
        IList<UserRating> AllRating();
        bool PostRating(int userId, int movieId, int rating);
    }
}
