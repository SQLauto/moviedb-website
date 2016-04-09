using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieDatabase.Models
{
    public class Genre
    {
        [Required(ErrorMessage = "The Genre field is required")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}