using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;
using IvyMovies.Services.Service.Interfaces;

namespace IvyMovies.Services
{
    public class DirectorsService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorsService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void Add(Director director)
        {
            _directorRepository.Add(director);
        }

        public void Delete(Director director)
        {
            _directorRepository.Delete(director);
        }

        public void Edit(Director director)
        {
            _directorRepository.Edit(director);
        }

        public Director GetDirectorById(int id)
        {
            var result = _directorRepository.GetDirectorById(id);
            return result;
        }

        public IEnumerable<Director> GetDirectors()
        {
            var result = _directorRepository.GetDirectories();
            return result;
        }
    }
}
