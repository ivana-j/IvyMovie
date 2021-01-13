using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;
using IvyMovies.Services.Service.Interfaces;

namespace IvyMovies.Services
{
    public class MovieService : IMovieService
    {
        public readonly IMovieRepository _movieReposotory;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieReposotory = movieRepository;
        }

        public void Add(Movie movie)
        {
            _movieReposotory.Add(movie);
        }

        public void Delete(Movie movie)
        {
            _movieReposotory.Delete(movie);
        }

        public void Edit(Movie movie)
        {
            _movieReposotory.Edit(movie);
        }

        public Movie GetMovieById(int id)
        {
            var result = _movieReposotory.GetMovieById(id);
                return result;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var result = _movieReposotory.GetMovies();
            return result;
        }
    }
}
