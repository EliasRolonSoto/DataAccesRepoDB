using DataAccessRepoDb.Entities;
using Microsoft.Data.SqlClient;
using RepoDb;
using System;

namespace DataAccessRepoDB.Repository
{
    public class MovieRepository
    {
       
        private string _connectionString =
                "Persist Security Info=True;Initial Catalog=Demo;Data Source=.; Integrated Security=True;TrustServerCertificate=True;";

        public MovieRepository()
        {
            GlobalConfiguration
               .Setup()
       .UseSqlServer();
        }
        public IEnumerable<Movie> TraerMovies()
        {
           
            //Movies
            IEnumerable<Movie> movies;

            //ORM
            using (var connection = new SqlConnection(_connectionString))
            {
                movies = connection.QueryAll<Movie>();
            }

            var count = movies.Count();

            Console.WriteLine($"Movies count: {count}");


            //Query
            IEnumerable<Movie> moviesStarwars;
            using (var connection = new SqlConnection(_connectionString))
            {
                moviesStarwars = connection.Query<Movie>(m => m.Name.Contains("Starwars"));

            }

            Console.WriteLine($"Movies Starwars count: {moviesStarwars.Count()}");


            long count2;
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT COUNT(*) FROM [dbo].[Movie];";
                count2 = connection.ExecuteScalar<long>(sql);
            }


            Console.WriteLine($"Movies  count 2: {count2}");


            //1: Insertar 10mil peliculas (o entidades de su negocio)
            //Ejemplo "pelicula 123456789"

            //Actualizar solo peliculas que terminan en "666" con "(XX)"
            //"Pelicula ...666 (X)"
            //Ejemplo 
            //  ANTES: Pelicula 666  >>  Pelicula 666 (X)
            //  ANTES: Pelicula 1666  >> Pelicula 1666 (X)
            //  ANTES: Pelicula 2666  >> Pelicula 2666 (X)
            return movies;
        }
        public void InsertarPelisModo1()
        {
            var movie = new Movie();
            using (var connection = new SqlConnection(_connectionString))
            { 
                for (int i=1; i<=10000; i++) 
                { 
                    movie.MovieId = i;
                    movie.ImageUrl = i.ToString();
                    movie.Name = $"pelicula {i}";
                
                    var rowsInserted = connection.Insert<Movie>(movie);
                };
            }
            
        }
        public void InsertarPelisModo2()
        {
            var movies = new List<Movie>();
            for (int i = 1; i <= 10000; i++)
            {
                var movie = new Movie();
                movie.MovieId = i;
                movie.ImageUrl = i.ToString();
                movie.Name = $"pelicula {i}";

               movies.Add(movie);
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                var rowsInserted = connection.InsertAll<Movie>(movies);
            }

        }
        public void UpdatePelis() 
        {
            IEnumerable<Movie> moviesStarwars;
            using (var connection = new SqlConnection(_connectionString))
            {
                moviesStarwars = connection.Query<Movie>(m => m.Name.EndsWith("666"));
                foreach (var movie in moviesStarwars) { movie.Name = $"{movie.Name}, (x)";}

                connection.UpdateAll<Movie>(moviesStarwars);
            }
        }
        public void DeletePelis()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.DeleteAll<Movie>();
            }
        }
    }
}