using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;

namespace IvyMovies.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository (DataContext context)
        {
            _context = context;
        }

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Delete(Genre gerne)
        {
            _context.Genres.Remove(gerne);
            _context.SaveChanges();
        }

        public void Edit(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }

        public Genre GetGenreById(int id)
        {
            var result = _context.Genres.FirstOrDefault(x => x.GenreId == id);
            return result;
        }

        public IEnumerable<Genre> GetGenres()
        {
            var result = _context.Genres.AsEnumerable();
            return result;
        }
    }
}
