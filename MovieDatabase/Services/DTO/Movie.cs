using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    [DataContract]
    public class Movie
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public Genre Genre { get; set; }

        [DataMember]
        public List<Actor> Actors { get; set; }

        public Movie()
        {
            Genre = new Genre();
            Actors = new List<Actor>();
        }
    }
}
