using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;

namespace IvyMovies.Repositories.Repository.Interfaces
{
    public interface IGenreRepository
    {
        void Add (Genre genre);
        void Edit(Genre genre);
        void Delete(Genre gerne);
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(int id);
    }
}
