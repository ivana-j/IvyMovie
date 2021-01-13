using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using IvyMovies.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IvyMovies.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController (IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var genre = _genreService.GetGenres();
            return View(genre);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.Add(genre);
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }
        public IActionResult Details(int id)
        {
            var genre = _genreService.GetGenreById(id);

            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }
    }
}