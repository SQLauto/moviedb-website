using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int? Year { get; set; }

        public List<Actor> Actors { get; set; }

        public Movie()
        {
            Actors = new List<Actor>();
        }
    }
}