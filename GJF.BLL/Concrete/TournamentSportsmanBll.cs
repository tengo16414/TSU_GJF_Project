using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJF.DAL.Abstract;

namespace GJF.BLL.Concrete
{
    public class TournamentSportsmanBll : GenericBll<TournamentSportsman>, ITournamentSportsmanBll
    {
        public TournamentSportsmanBll(IGenericRepository<TournamentSportsman> genericRepository) : base(genericRepository)
        {
        }
    }
}
