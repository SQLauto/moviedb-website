using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Services.DTO;
using Tools.DB;
using System.Data.SqlClient;
using System.Data;

namespace Services
{
    [ServiceContract]
    public interface IMovieDBService
    {
        [OperationContract]
        Genre GetGenre(int id);

        [OperationContract]
        List<Genre> GetGenres();

        [OperationContract]
        Genre SubmitGenre(Genre genre);

        [OperationContract]
        Actor GetActor(int id);

        [OperationContract]
        List<Actor> GetActors(int movieID, int genreID);

        [OperationContract]
        Actor SubmitActor(Actor actor);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        List<Movie> GetMovies(int actorID);

        [OperationContract]
        Movie SubmitMovie(Movie movie);

        [OperationContract]
        MovieStatistics GetStatistics();

        [OperationContract]
        bool DeleteActor(int id);

        [OperationContract]
        bool DeleteGenre(int id);

        [OperationContract]
        bool DeleteMovie(int id);

        [OperationContract]
        bool AddActorToMovie(int actorID, int movieID);

        [OperationContract]
        bool RemoveActorFromMovie(int actorID, int movieID);
    }

    public class MovieDBService : IMovieDBService
    {
        public static string MovieDBConnectionName = "MovieDB";

        public bool AddActorToMovie(int actorID, int movieID)
        {
            try
            {
                using (var connection = DBTools.GetConnection(MovieDBConnectionName))
                {
                    var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@actorID", actorID),
                    new SqlParameter("@movieID", movieID)
                };

                    connection.ExecuteStoredProcedure("SubmitMovie_Actor", parameters);
                }

                return true;
            }
            catch (Exception e)
            {
                // Log here
                return false;
            }
        }

        public bool DeleteActor(int id)
        {
            try
            {
                using (var connection = DBTools.GetConnection(MovieDBConnectionName))
                {
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@id", id)
                    };

                    connection.ExecuteStoredProcedure("DeleteActor", parameters);
                }
                return true;
            }
            catch (Exception e)
            {
                // Log here
                return false;
            }
        }

        public bool DeleteGenre(int id)
        {
            try { 
                using (var connection = DBTools.GetConnection(MovieDBConnectionName))
                {
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@id", id)
                    };

                    connection.ExecuteStoredProcedure("DeleteGenre", parameters);
                }
                return true;
            }
            catch (Exception e)
            {
                // Log here
                return false;
            }
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                using (var connection = DBTools.GetConnection(MovieDBConnectionName))
                {
                    var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@id", id)
                    };

                    connection.ExecuteStoredProcedure("DeleteMovie", parameters);
                }
                return true;
            }
            catch (Exception e)
            {
                // Log here
                return false;
            }
        }

        public Actor GetActor(int id)
        {
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", id)
                };

                using (var reader = connection.ExecuteStoredProcedure("GetActor", parameters))
                {
                    if (reader.Read())
                    {
                        var output = new Actor
                        {
                            ID = reader.GetInt32("ID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName")
                        };

                        return output;
                    }
                }
            }

            return null;
        }

        public List<Actor> GetActors(int movieID = 0, int genreID = 0)
        {
            var output = new List<Actor>();
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@movieID", movieID),
                    new SqlParameter("@genreID", genreID)
                };

                using (var reader = connection.ExecuteStoredProcedure("GetActors", parameters))
                {
                    while (reader.Read())
                    {
                        output.Add(new Actor
                        {
                            ID = reader.GetInt32("ID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName")
                        });
                    }
                }
            }

            return output;
        }

        public Genre GetGenre(int id)
        {
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", id)
                };

                using (var reader = connection.ExecuteStoredProcedure("GetGenre", parameters))
                {
                    if (reader.Read())
                    {
                        var output = new Genre
                        {
                            ID = reader.GetInt32("ID"),
                            Name = reader.GetString("Name")
                        };

                        return output;
                    }
                }
            }
            
            return null;
        }

        public List<Genre> GetGenres()
        {
            var output = new List<Genre>();
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                using (var reader = connection.ExecuteStoredProcedure("GetGenres"))
                {
                    while (reader.Read())
                    {
                        output.Add(new Genre
                        {
                            ID = reader.GetInt32("ID"),
                            Name = reader.GetString("Name")
                        });
                    }
                }
            }

            return output;
        }

        public Movie GetMovie(int id)
        {
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", id)
                };

                using (var reader = connection.ExecuteStoredProcedure("GetMovie", parameters))
                {
                    if (reader.Read())
                    {
                        var output = new Movie
                        {
                            ID = reader.GetInt32("ID"),
                            Title = reader.GetString("Title"),
                            Year = reader.GetInt32("Year"),
                            Genre = GetGenre(reader.GetInt32("GenreID"))
                        };

                        return output;
                    }
                }
            }

            return null;
        }

        public List<Movie> GetMovies(int actorID = 0)
        {
            var output = new List<Movie>();
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@actorID", actorID)
                };

                using (var reader = connection.ExecuteStoredProcedure("GetMovies", parameters))
                {
                    while (reader.Read())
                    {
                        output.Add(new Movie
                        {
                            ID = reader.GetInt32("ID"),
                            Title = reader.GetString("Title"),
                            Year = reader.GetInt32("Year"),
                            Genre = GetGenre(reader.GetInt32("GenreID"))
                        });
                    }
                }
            }

            return output;
        }

        public MovieStatistics GetStatistics()
        {
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                using (var dataSet = connection.ExecuteStoredProcedureDataSet("GetStatistics"))
                {
                    var output = new MovieStatistics();
                    var actorsPerGenre = dataSet.Tables[0];
                    var actorsPerMovie = dataSet.Tables[1];
                    var moviesPerActor = dataSet.Tables[2];
                    var numberOfActors = dataSet.Tables[3];
                    var numberOfMovies = dataSet.Tables[4];
                    var genres = dataSet.Tables[5];

                    foreach (DataRow row in actorsPerGenre.Rows)
                    {
                        output.ActorsPerGenre.Add(row.GetString("Genre"), row.GetInt32("# Actors"));
                    }

                    foreach (DataRow row in actorsPerMovie.Rows)
                    {
                        output.ActorsPerMovie.Add(row.GetString("Title"), row.GetInt32("# Actors"));
                    }

                    foreach (DataRow row in moviesPerActor.Rows)
                    {
                        output.MoviesPerActor.Add(row.GetString("Actor"), row.GetInt32("# Movies"));
                    }

                    output.NumberOfActors = numberOfActors.Rows[0].GetInt32("# Actors");
                    output.NumberOfMovies = numberOfMovies.Rows[0].GetInt32("# Movies");

                    foreach (DataRow row in genres.Rows)
                    {
                        output.Genres.Add(row.GetString("Genre"));
                    }

                    return output;
                }
            }
        }

        public bool RemoveActorFromMovie(int actorID, int movieID)
        {
            try
            {
                using (var connection = DBTools.GetConnection(MovieDBConnectionName))
                {
                    var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@actorID", actorID),
                    new SqlParameter("@movieID", movieID)
                };

                    connection.ExecuteStoredProcedure("DeleteMovie_Actor", parameters);
                }

                return true;
            }
            catch (Exception e)
            {
                // Log here
                return false;
            }
        }

        public Actor SubmitActor(Actor actor)
        {
            Actor output = null;

            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", actor.ID),
                    new SqlParameter("@firstName", actor.FirstName),
                    new SqlParameter("@lastName", actor.LastName)
                };

                using (var reader = connection.ExecuteStoredProcedure("SubmitActor", parameters))
                {
                    if (reader.Read())
                    {
                        output = new Actor
                        {
                            ID = reader.GetInt32("ID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName")
                        };
                    }
                }

                return output;
            }
        }

        public Genre SubmitGenre(Genre genre)
        {
            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", genre.ID),
                    new SqlParameter("@name", genre.Name)
                };

                using (var reader = connection.ExecuteStoredProcedure("SubmitGenre", parameters))
                {
                    if (reader.Read())
                    {
                        var output = new Genre
                        {
                            ID = reader.GetInt32("ID"),
                            Name = reader.GetString("Name")
                        };

                        return output;
                    }
                }
            }

            return null;
        }

        public Movie SubmitMovie(Movie movie)
        {
            Movie output = null;

            using (var connection = DBTools.GetConnection(MovieDBConnectionName))
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@id", movie.ID),
                    new SqlParameter("@name", movie.Title),
                    new SqlParameter("@year", movie.Year),
                    new SqlParameter("@genreId", movie.Genre.ID)
                };

                using (var reader = connection.ExecuteStoredProcedure("SubmitMovie", parameters))
                {
                    if (reader.Read())
                    {
                        output = new Movie
                        {
                            ID = reader.GetInt32("ID"),
                            Title = reader.GetString("Title"),
                            Year = reader.GetInt32("Year"),
                            Genre = GetGenre(reader.GetInt32("GenreID"))
                        };
                    }
                }

                if (movie.Actors.Any())
                {
                    foreach (var actor in movie.Actors)
                    {
                        parameters = new List<SqlParameter>
                        {
                            new SqlParameter("@actorID", output.ID),
                            new SqlParameter("@movieID", actor.ID)
                        };

                        connection.ExecuteStoredProcedure("SubmitMovie_Actor", parameters);
                    }
                }
            }

            return output;
        }
    }
}
