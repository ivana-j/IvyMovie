using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IvyMovies.Data.Entities
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        //public DateTime ActorBirthDate { get; set; }
        //public string Awards { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }


    }
}
