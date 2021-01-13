using IvyMovies.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvyMovies.Models
{
    public class DataJson
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
