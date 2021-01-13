using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using IvyMovies.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IvyMovies.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        public IActionResult Index()
        {
            var actors = _actorService.GetActors();
            return View(actors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Actor actor)
        {
            if (ModelState.IsValid)
            {
                _actorService.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        public IActionResult Details(int id)
        {
            var actor = _actorService.GetActorById(id);

            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        public IActionResult Edit(int id)
        {
            var actor = _actorService.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }


        [HttpPost]
        public IActionResult Edit (int id, Actor actor)
        {
            if (id != actor.ActorId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _actorService.Edit(actor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        public IActionResult Delete(int id)
        {
            var actor = _actorService.GetActorById(id);

            if(actor==null)
            {
                return NotFound();
            }
            return View(actor);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = _actorService.GetActorById(id);
            _actorService.Delete(actor);

            return RedirectToAction(nameof(Index));
        }

    }
}