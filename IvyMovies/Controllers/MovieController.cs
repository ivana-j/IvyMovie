using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IvyMovies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movie = _movieService.GetMovies();
            return View(movie);
        }
    }
}