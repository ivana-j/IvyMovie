using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using IvyMovies.Repositories.Repository.Interfaces;
using IvyMovies.Services.Service.Interfaces;

namespace IvyMovies.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService (IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public void Add(Actor actor)
        {
            _actorRepository.Add(actor);
        }

        public void Delete(Actor actor)
        {
            _actorRepository.Delete(actor);
        }

        public void Edit(Actor actor)
        {
            _actorRepository.Edit(actor);
        }

        public Actor GetActorById(int id)
        {
            var result = _actorRepository.GetActorById(id);
            return result;
        }

        public IEnumerable<Actor> GetActors()
        {
            var result = _actorRepository.GetActors();
            return result;
        }
    }
}
