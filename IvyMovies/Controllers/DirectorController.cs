using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using IvyMovies.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IvyMovies.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }
        public IActionResult Index()
        {
            var director = _directorService.GetDirectors();
            return View(director);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                _directorService.Add(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }
        public IActionResult Details(int id)
        {
            var director = _directorService.GetDirectorById(id);

            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        public IActionResult Edit(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }


        [HttpPost]
        public IActionResult Edit(int id, Director director)
        {
            if (id != director.DirectorId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _directorService.Edit(director);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }
        public IActionResult Delete(int id)
        {
            var director = _directorService.GetDirectorById(id);

            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var director = _directorService.GetDirectorById(id);
            _directorService.Delete(director);

            return RedirectToAction(nameof(Index));
        }
    }
}