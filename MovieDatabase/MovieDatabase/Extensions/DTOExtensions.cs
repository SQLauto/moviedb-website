using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = Services.DTO;
using Model = MovieDatabase.Models;

namespace MovieDatabase
{
    public static class DTOExtensions
    {
        public static DTO.Movie ToDTO(this Model.Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            return new DTO.Movie
            {
                ID = movie.ID,
                Title = movie.Title,
                Year = (movie.Year.HasValue ? movie.Year.Value : 0),
                Genre = movie.Genre.ToDTO(),
                Actors = movie.Actors.Select(c => c.ToDTO()).ToList()
            };
        }

        public static Model.Movie ToModel(this DTO.Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            return new Model.Movie
            {
                ID = movie.ID,
                Title = movie.Title,
                Year = movie.Year,
                Genre = movie.Genre.ToModel(),
                Actors = movie.Actors.Select(c => c.ToModel()).ToList()
            };
        }

        public static DTO.Actor ToDTO(this Model.Actor actor)
        {
            if (actor == null)
            {
                return null;
            }

            return new DTO.Actor
            {
                ID = actor.ID,
                FirstName = actor.FirstName,
                LastName = actor.LastName
            };
        }

        public static Model.Actor ToModel(this DTO.Actor actor)
        {
            if (actor == null)
            {
                return null;
            }

            return new Model.Actor
            {
                ID = actor.ID,
                FirstName = actor.FirstName,
                LastName = actor.LastName
            };
        }

        public static DTO.Genre ToDTO(this Model.Genre genre)
        {
            if (genre == null)
            {
                return null;
            }

            return new DTO.Genre
            {
                ID = genre.ID,
                Name = genre.Name
            };
        }

        public static Model.Genre ToModel(this DTO.Genre genre)
        {
            if (genre == null)
            {
                return null;
            }

            return new Model.Genre
            {
                ID = genre.ID,
                Name = genre.Name
            };
        }

        public static Model.Statistics ToModel(this DTO.MovieStatistics stats)
        {
            return new Model.Statistics
            {
                ActorsPerGenre = stats.ActorsPerGenre,
                ActorsPerMovie = stats.ActorsPerMovie,
                MoviesPerActor = stats.MoviesPerActor,
                MoviesPerGenre = stats.MoviesPerGenre,
                NumberOfActors = stats.NumberOfActors,
                NumberOfMovies = stats.NumberOfMovies,
                Genres = stats.Genres
            };
        }

        public static DTO.MovieStatistics ToDTO(this Model.Statistics stats)
        {
            return new DTO.MovieStatistics
            {
                ActorsPerGenre = stats.ActorsPerGenre,
                ActorsPerMovie = stats.ActorsPerMovie,
                MoviesPerActor = stats.MoviesPerActor,
                MoviesPerGenre = stats.MoviesPerGenre,
                NumberOfActors = stats.NumberOfActors,
                NumberOfMovies = stats.NumberOfMovies,
                Genres = stats.Genres
            };
        }
    }
}