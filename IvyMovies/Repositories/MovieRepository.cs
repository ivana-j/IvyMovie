using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;

namespace IvyMovies.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public void Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public Movie GetMovieById(int id)
        {
            var result = _context.Movies.FirstOrDefault(x => x.MovieId == id);
            return result;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var result = _context.Movies.AsEnumerable();
            return result;
        }
    }
}
