using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IvyMovies.Data.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        //public int DuringTime { get; set; }
        //public DateTime YearOfIssue { get; set; }
        //public string MoviePosterURL { get; set; }

        //public string MostPopular { get; set; }
        //public string TopRated { get; set; }
        //public string LowestRated { get; set; }

        //Akter FKey
        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
