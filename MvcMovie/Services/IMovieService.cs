using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Services
{
    public interface IMovieService
    {
        Movie GetMovieById(int? id);
        IEnumerable<Movie> GetAllMovies();
        Movie CreateMovie(Movie movie);
        Movie EditMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
