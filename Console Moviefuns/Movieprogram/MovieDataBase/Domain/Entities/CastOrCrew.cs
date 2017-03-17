using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieprogram.MovieDataBase.Domain.Entities
{

    public class CastOrCrew
    {

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<Movie> ActedMovies { get; set; }

        public HashSet<Movie> DirectedMovies { get; set; }

        public bool IsDirector { get { return DirectedMovies.Count > 0; } }
        public bool IsActor { get { return ActedMovies.Count > 0; } }

        public CastOrCrew(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            ActedMovies = new HashSet<Movie>();
            DirectedMovies = new HashSet<Movie>();
           

        }
        
        

        public string JobTitle
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                bool needsComma = true;
                if (IsActor)
                {
                    builder.Append("Actor");
                    needsComma = true;
                }
                if (IsDirector)
                {
                    if (needsComma)
                    {
                        builder.Append(", ");
                    }
                    builder.Append("Director");
                    needsComma = true;
                }
                return builder.ToString();
            }

        }
    }
}

