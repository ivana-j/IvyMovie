using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvyMovies.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IvyMovies.Models
{
    public class MainViewModel
    {

        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

        public IEnumerable<Movie> GetMovies { get; set; }

        public IEnumerable<SelectListItem> Movies { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Directors { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }
    }
}

