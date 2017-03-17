using Movieprogram.MovieDataBase.Domain.Entities;
using Movieprogram.MovieDataBase.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieprogram.MovieDataBase.Repositories
{
    public class MovieRepository
    {
        public CastOrCrewRepository _castOrCrewRepository;
        public MovieRepository _movieRepository;
        public List<Movie> movies;

       
        public MovieRepository()
        {
            movies = new List<Movie>();
            Load();
        }
        public MovieRepository movieRepository
        {
            get
            {
                if (_movieRepository == null)
                {
                    _movieRepository = new MovieRepository();
                }
                return _movieRepository;
            }
        }

        public void Add(Movie movie)
        {
            movies.Add(movie);
        }

        public Movie FindMovie(string title)
        {
            return movies.Find(x => x.Title.ToLower() == title.ToLower());
        }

        public void Load()
        {
            CastOrCrewRepository castOrCrew = CastOrCrewRepository.castOrCrewRepository;


            var georgeClooney = new CastOrCrew("George Clooney", new DateTime(1961, 5, 6));
            castOrCrew.people.Add(georgeClooney);
            var sandraBullock = new CastOrCrew("Sandra Bullock", new DateTime(1964, 7, 26));
            castOrCrew.Add(sandraBullock);
            var juliaRoberts = new CastOrCrew("Julia Roberts", new DateTime(1967, 10, 28));
            castOrCrew.Add(juliaRoberts);
            var denzelWashington = new CastOrCrew("Denzel Washington", new DateTime(1954, 12, 28));
            castOrCrew.Add(denzelWashington);
            var stevenSoderbergh = new CastOrCrew("Steven Soderbergh", new DateTime(1963, 1, 14));
            castOrCrew.Add(stevenSoderbergh);
            var antoineFuqua = new CastOrCrew("Antoine Fuqua", new DateTime(1966, 1, 19));
            castOrCrew.Add(antoineFuqua);
            var alfonsoCuaron = new CastOrCrew("Alfonso Cuarón", new DateTime(1961, 11, 28));
            castOrCrew.Add(alfonsoCuaron);


            var trainingDay = new Movie("Training Day", new ProductionYear(2001));
            trainingDay.Director = antoineFuqua;
            trainingDay.AddActor(denzelWashington);
            Add(trainingDay);

            var oceansEleven = new Movie("Ocean's Eleven", new ProductionYear(2001));
            oceansEleven.Director = stevenSoderbergh;
            oceansEleven.AddActor(juliaRoberts);
            oceansEleven.AddActor(georgeClooney);
            Add(oceansEleven);

            var gravity = new Movie("Gravity", new ProductionYear(2013));
            gravity.Director = alfonsoCuaron;
            gravity.AddActor(sandraBullock);
            gravity.AddActor(georgeClooney);
            Add(gravity);
        }


    }



    }

