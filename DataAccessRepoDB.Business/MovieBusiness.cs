using DataAccessRepoDb.Entities;
using DataAccessRepoDB.Repository;

namespace DataAccessRepoDB.Business
{
    public class MovieBusiness
    {
        private MovieRepository _movieRepository;

        public MovieBusiness()
        {
            _movieRepository = new MovieRepository();
        }

        public IEnumerable<Movie> TraerMovies() 
        { 
            return _movieRepository.TraerMovies();
        }
        public void InsertarMovieModo1()
        {
            _movieRepository.InsertarPelisModo1();
        }
        public void InsertarMovieModo2()
        {
            _movieRepository.InsertarPelisModo2();
        }
        public void UpdatearMovie()
        {
            _movieRepository.UpdatePelis();
        }
        public void DeletearMovies() 
        { 
            _movieRepository.DeletePelis();
        }
    }
}