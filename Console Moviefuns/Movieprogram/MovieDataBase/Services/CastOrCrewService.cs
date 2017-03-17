using Movieprogram.MovieDataBase.Domain.Entities;
using Movieprogram.MovieDataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movieprogram.MovieDataBase.Services
{
    public class CastOrCrewService
    {
        private readonly CastOrCrewRepository _castOrCrewrepository;
        public CastOrCrewService()
        {
            _castOrCrewrepository = CastOrCrewRepository.castOrCrewRepository;
        }
        public void AddPeople(CastOrCrew castOrCrew)
        {
            _castOrCrewrepository.Add(castOrCrew);
        }

        public CastOrCrew FindBy(string name)
        {
            return _castOrCrewrepository.FindBy(name);
        }
       
    }
}
