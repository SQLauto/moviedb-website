using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Statistics
    {
        [Display(Name = "# Actors Per Genre")]
        public Dictionary<string, int> ActorsPerGenre { get; set; }

        [Display(Name = "Actors In Genre")]
        public Dictionary<string, List<Actor>> ActorsInGenre { get; set; }

        [Display(Name = "# Movies Per Actor")]
        public Dictionary<string, int> MoviesPerActor { get; set; }

        [Display(Name = "# Actors Per Movie")]
        public Dictionary<string, int> ActorsPerMovie { get; set; }

        [Display(Name = "# Movies Per Genre")]
        public Dictionary<string, int> MoviesPerGenre { get; set; }

        [Display(Name = "# Movies")]
        public int NumberOfMovies { get; set; }

        [Display(Name = "# Actors")]
        public int NumberOfActors { get; set; }
        
        public List<string> Genres { get; set; }

        public Statistics()
        {
            ActorsInGenre = new Dictionary<string, List<Actor>>();
            ActorsPerGenre = new Dictionary<string, int>();
            MoviesPerActor = new Dictionary<string, int>();
            ActorsPerMovie = new Dictionary<string, int>();
            MoviesPerGenre = new Dictionary<string, int>();
            Genres = new List<string>();
        }
    }
}