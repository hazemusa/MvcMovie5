using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMovie.Models;
using MvcMovie.Models.Identity;
using System.Data.Entity;

namespace MvcMovie.Services
{
    public class MovieService : IMovieService
    {
        private readonly Models.Identity.ApplicationDbContext _dbContext;

        public MovieService(Models.Identity.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movieToRemove = _dbContext.Movies.Find(id);
            if (movieToRemove != null)
            {
                _dbContext.Movies.Remove(movieToRemove);
            }
            _dbContext.SaveChanges();
        }

        public Movie EditMovie(Movie movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return movie;
        }

        public Movie GetMovieById(int? id)
        {
            return _dbContext.Movies.Find(id);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _dbContext.Movies.AsEnumerable();
        }
    }
}