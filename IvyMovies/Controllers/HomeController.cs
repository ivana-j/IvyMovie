using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IvyMovies.Models;
using IvyMovies.Data;
using Microsoft.EntityFrameworkCore;

namespace IvyMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }


        //public IActionResult Index()
        //{
        //    var GetAllBooks = _context.Movies.AsEnumerable();

        //    var ViewModel = new MainViewModel
        //    {
        //        GetMovies = GetAllBooks
        //    };

        //    return View(ViewModel);
        //}

        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.MovieName.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
