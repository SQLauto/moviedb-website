using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    [DataContract]
    public class MovieStatistics
    {
        [DataMember]
        public Dictionary<string, int> ActorsPerGenre { get; set; }

        [DataMember]
        public Dictionary<string, int> MoviesPerActor { get; set; }

        [DataMember]
        public Dictionary<string, int> ActorsPerMovie { get; set; }

        [DataMember]
        public Dictionary<string, int> MoviesPerGenre { get; set; }

        [DataMember]
        public int NumberOfMovies { get; set; }

        [DataMember]
        public int NumberOfActors { get; set; }

        [DataMember]
        public List<string> Genres { get; set; }

        public MovieStatistics()
        {
            ActorsPerGenre = new Dictionary<string, int>();
            MoviesPerActor = new Dictionary<string, int>();
            ActorsPerMovie = new Dictionary<string, int>();
            MoviesPerGenre = new Dictionary<string, int>();
            Genres = new List<string>();
        }
    }
}
