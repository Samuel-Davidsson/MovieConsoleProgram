using Movieprogram.MovieDataBase.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieprogram.MovieDataBase.Domain.Entities
{
    public class Movie
    {
        public HashSet<CastOrCrew> Actors { get; set; }
        public CastOrCrew _director;
       

        public CastOrCrew Director
        {
            get { return _director; }
            set
            {
                _director = value;
                _director.DirectedMovies.Add(this);
            }
        }
        public Movie(string title, ProductionYear productionYear)
        {
            Title = title;
            ProductionYear = productionYear;
            Actors = new HashSet<CastOrCrew>();
           

        }

        public ProductionYear ProductionYear { get; }
        public string Title { get; }

        public void AddActor(CastOrCrew actor)
        {
            if (actor == null)
            {
                return;
            }
            actor.ActedMovies.Add(this);
            Actors.Add(actor);
        }
      


    }
}
