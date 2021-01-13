using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;
using IvyMovies.Services.Service.Interfaces;

namespace IvyMovies.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService (IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void Add(Genre genre)
        {
            _genreRepository.Add(genre);
        }

        public void Delete(Genre genre)
        {
            _genreRepository.Delete(genre);
        }

        public void Edit(Genre genre)
        {
            _genreRepository.Edit(genre);
        }

        public Genre GetGenreById(int id)
        {
            var result = _genreRepository.GetGenreById(id);
            return result;
        }

        public IEnumerable<Genre> GetGenres()
        {
            var result = _genreRepository.GetGenres();
            return result;
        }
    }
}
