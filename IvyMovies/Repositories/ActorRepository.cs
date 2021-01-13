using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;

namespace IvyMovies.Repositories
{

    public class ActorRepository : IActorRepository
    {
        private readonly DataContext _context;

        public ActorRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Edit(Actor actor)
        {
            _context.Actors.Update(actor);
            _context.SaveChanges();
        }

        public void Delete(Actor actor)
        {
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }

        public IEnumerable<Actor> GetActors()
        {
            var result = _context.Actors.AsEnumerable();
            return result;
        }

        public Actor GetActorById(int id)
        {
            var result = _context.Actors.FirstOrDefault(x => x.ActorId == id);
            return result;
        }
    }
}
