using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;

namespace IvyMovies.Services.Service.Interfaces
{
    public interface IDirectorService
    {
        void Add(Director director);
        void Edit(Director director);
        void Delete(Director director);
        IEnumerable<Director> GetDirectors();
        Director GetDirectorById(int id);
    }
}
