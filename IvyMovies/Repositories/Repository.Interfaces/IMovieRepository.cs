using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;

namespace IvyMovies.Repositories.Repository.Interfaces
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        void Edit(Movie movie);
        void Delete(Movie movie);
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int id);
    }
}
