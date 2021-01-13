using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data;
using IvyMovies.Data.Entities;

namespace IvyMovies.Repositories.Repository.Interfaces
{
    public interface IActorRepository
    {
        void Add(Actor actor);
        void Edit(Actor actor);
        void Delete(Actor actor);
        IEnumerable<Actor> GetActors();
        Actor GetActorById(int id);
    }
}
