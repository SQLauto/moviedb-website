using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = Services.DTO;
using Model = MovieDatabase.Models;

namespace MovieDatabase
{
    public class MockData
    {
        private static MockData singleton = null;

        public static MockData Instance { get { return singleton == null ? singleton = new MockData() : singleton; } }

        public List<Model.Movie> MovieList { get; set; }

        public List<Model.Actor> ActorList { get; set; }

        public List<Model.Genre> GenreList { get; set; }

        public Model.Statistics Stats { get; set; }

        public MockData()
        {
            MovieList = new List<Model.Movie>
            {
                new Model.Movie
                {
                    ID = 1,
                    Title = "Blade Runner",
                    Genre = new Model.Genre()
                    {
                        ID = 1,
                        Name = "Action"
                    },
                    Year = 1982
                },
                new Model.Movie
                {
                    ID = 2,
                    Title = "Silent Hill",
                    Genre = new Model.Genre()
                    {
                        ID = 4,
                        Name = "Horror"
                    },
                    Actors = new List<Model.Actor>
                    {
                        new Model.Actor
                        {
                            ID = 3,
                            FirstName = "Radha",
                            LastName = "Mitchell"
                        }
                    },
                    Year = 2006
                },
                new Model.Movie
                {
                    ID = 3,
                    Title = "40 Year Old Virgin",
                    Genre = new Model.Genre()
                    {
                        ID = 2,
                        Name = "Comedy"
                    },
                    Actors = new List<Model.Actor>
                    {
                        new Model.Actor
                        {
                            ID = 1,
                            FirstName = "Paul",
                            LastName = "Rudd"
                        },
                        new Model.Actor
                        {
                            ID = 2,
                            FirstName = "Jason",
                            LastName = "Siegel"
                        }
                    },
                    Year = 2005
                }
            };

            ActorList = new List<Model.Actor>
            {
                new Model.Actor
                {
                    ID = 1,
                    FirstName = "Paul",
                    LastName = "Rudd"
                },
                new Model.Actor
                {
                    ID = 2,
                    FirstName = "Jason",
                    LastName = "Siegel"
                },
                new Model.Actor
                {
                    ID = 3,
                    FirstName = "Radha",
                    LastName = "Mitchell"
                }
            };

            GenreList = new List<Model.Genre>
            {
                new Model.Genre
                {
                    ID = 1,
                    Name = "Action"
                },
                new Model.Genre
                {
                    ID = 2,
                    Name = "Comedy"
                },
                new Model.Genre
                {
                    ID = 3,
                    Name = "Sci-Fi"
                },
                new Model.Genre
                {
                    ID = 4,
                    Name = "Horror"
                }
            };

            Stats = new Model.Statistics();
            MovieList.ForEach(movie =>
            {
                Stats.ActorsPerMovie.Add(movie.Title, movie.Actors.Count());
            });

            int numActors;
            GenreList.ForEach(genre =>
            {
                // for each actor, determine if they have been in a movie of the genre
                var actors = ActorList.Where(actor => MovieList.Any(movie => movie.Genre.ID == genre.ID
                                                                    && movie.Actors.Any(c => c.ID == actor.ID))).ToList();
                numActors = actors.Count;
                Stats.ActorsInGenre.Add(genre.Name, actors);
                Stats.ActorsPerGenre.Add(genre.Name, numActors);
            });

            int numMovies;
            ActorList.ForEach(actor =>
            {
                numMovies = MovieList.Count(movie => movie.Actors.Any(a => a.ID == actor.ID));
                Stats.MoviesPerActor.Add(actor.FirstName + " " + actor.LastName, numMovies);
            });

            GenreList.ForEach(genre =>
            {
                numMovies = MovieList.Count(movie => movie.Genre.ID == genre.ID);
                Stats.MoviesPerGenre.Add(genre.Name, numMovies);
            });

            Stats.NumberOfActors = ActorList.Count();
            Stats.NumberOfMovies = MovieList.Count();
            Stats.Genres = GenreList.Select(genre => genre.Name).ToList();
        }
    }
}