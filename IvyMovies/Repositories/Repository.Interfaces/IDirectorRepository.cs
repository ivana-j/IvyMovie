using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;

namespace IvyMovies.Repositories.Repository.Interfaces
{
    public interface IDirectorRepository
    {
        void Add(Director directory);
        void Edit(Director directory);
        void Delete(Director directory);

        IEnumerable<Director> GetDirectories();

        Director GetDirectorById(int id);
    }
}
