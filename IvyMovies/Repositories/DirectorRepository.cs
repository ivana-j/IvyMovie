using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;

namespace IvyMovies.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly DataContext _context;

        public DirectorRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Director directory)
        {
            _context.Directors.Add(directory);
            _context.SaveChanges();
        }

        public void Delete(Director directory)
        {
            _context.Directors.Remove(directory);
            _context.SaveChanges();
        }

        public void Edit(Director directory)
        {
            _context.Directors.Update(directory);
            _context.SaveChanges();
        }

        public Director GetDirectorById(int id)
        {
            var result = _context.Directors.FirstOrDefault(x => x.DirectorId == id);
                return result;
        }

        public IEnumerable<Director> GetDirectories()
        {
            var result = _context.Directors.AsEnumerable();
            return result;
        }
    }
}
