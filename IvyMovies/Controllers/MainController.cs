using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IvyMovies.Data.Entities;
using IvyMovies.Models;
using IvyMovies.Services.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.Internal;
using IvyMovies.Data;

namespace IvyMovies.Controllers
{
    public class MainController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        private readonly IDirectorService _directorService;
        private readonly DataContext _context;

        public MainController(IMovieService movieService, IGenreService genreService, IActorService actorService, IDirectorService directorService, DataContext context)
        {
            _movieService = movieService;
            _genreService = genreService;
            _actorService = actorService;
            _directorService = directorService;
            _context = context;
        }

        public IActionResult Index()
        {
            var movieList = _movieService.GetMovies();
            return View(movieList);
        }

        public IActionResult FillMovieDataTable()
        {

            var movies = _context.Movies
                .Include(x => x.Genres)
                .Include(x => x.Actors)
                .Include(x => x.Directors)
                .Select (x => new DataJson{
                    MovieId = x.MovieId,
                    MovieTitle = x.MovieName,
                    Actors = x.Actors,
                    Directors = x.Directors,
                    Genres = x.Genres
                })
                .ToList();
           
            return Ok(movies);
        }

        public IActionResult Create()
        {
            var Movies = _movieService.GetMovies();
            var Genres = _genreService.GetGenres();
            var Directors = _directorService.GetDirectors();
            var Actors = _actorService.GetActors();

            MainViewModel mainViewModel = new MainViewModel
            {
                Movies = GetSelectListItemMovies(Movies),
                Genres = GetSelectListItemGenres(Genres),
                Directors = GetSelectListItemDirectors(Directors),
                Actors = GetSelectListItemActors(Actors)
            };

            return View(mainViewModel);
        }

        private IEnumerable<SelectListItem> GetSelectListItemMovies(IEnumerable<Movie> movies)
        {
            var selectList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Select Movie"
                }
            };
            foreach (var item in movies)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.MovieId.ToString(),
                    Text = item.MovieName
                }); 
            }
            return selectList;
        }
        private IEnumerable<SelectListItem> GetSelectListItemGenres(IEnumerable<Genre> genres)
        {
            var selectList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Select Genre"
                }
            };
            foreach (var item in genres)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.GenreId.ToString(),
                    Text = item.GenreName
                });
            }
            return selectList;
        }
        private IEnumerable<SelectListItem> GetSelectListItemDirectors(IEnumerable<Director> directors)
        {
            var selectList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Select Director"
                }
            };
            foreach (var item in directors)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.DirectorId.ToString(),
                    Text = item.DirectorName
                });
            }
            return selectList;
        }
        private IEnumerable<SelectListItem> GetSelectListItemActors(IEnumerable<Actor> actors)
        {
            var selectList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "0",
                    Text = "Select Actor"
                }
            };
            foreach (var item in actors)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.ActorId.ToString(),
                    Text = item.ActorName
                });
            }
            return selectList;
        }


        #region UploadPhoto
        [HttpPost]
        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    var dbPath = fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    //_logger.LogInformation(LoggerMessageDisplay.PhotoUploaded);
                    return Ok(new { dbPath });
                }
                else
                {
                    //_logger.LogError(LoggerMessageDisplay.PhotoUploadedError);
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                //_logger.LogError(LoggerMessageDisplay.PhotoUploadedError + " --->" + ex);
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion
    }
}