using Movieprogram.MovieDataBase.Domain.Entities;
using Movieprogram.MovieDataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieprogram.MovieDataBase.Services
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;
        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }
        public void Add(Movie movie)
        {
            _movieRepository.Add(movie);
        }
        public Movie SearchMovie(string title)
        {
            return _movieRepository.FindMovie(title);
        }

    }
}
