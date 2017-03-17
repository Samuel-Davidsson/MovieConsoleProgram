using Movieprogram.MovieDataBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieprogram.MovieDataBase.Repositories
{
    
    public class CastOrCrewRepository
    {
        public List<CastOrCrew> people;

        public static CastOrCrewRepository _castOrCrewRepository;

         public static  CastOrCrewRepository castOrCrewRepository
        {
            get
            {
                if (_castOrCrewRepository == null)
                {
                    _castOrCrewRepository = new CastOrCrewRepository();
                }
                return _castOrCrewRepository;
            }
        }

        public CastOrCrewRepository()
        {
            people = new List<CastOrCrew>();
        }
        public void Add(CastOrCrew castOrCrew)
        {
            people.Add(castOrCrew);
        }

        public CastOrCrew FindBy(string name)
        {
            return people.Find(x => x.Name.ToLower() == name.ToLower());
        }
        

    }

}
