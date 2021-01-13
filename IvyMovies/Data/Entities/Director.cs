using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IvyMovies.Data.Entities
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }

        //public DateTime DirectorBirthDate { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
