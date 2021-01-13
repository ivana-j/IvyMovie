using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;

namespace IvyMovies.Services.Service.Interfaces
{
    public interface IGenreService
    {
        void Add(Genre genre);
        void Edit(Genre genre);
        void Delete(Genre genre);

        Genre GetGenreById(int id);
        IEnumerable<Genre> GetGenres();
    }
}
