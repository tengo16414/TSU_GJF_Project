using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJF.BLL.Abstract;
using GJF.DAL.Abstract;
using GJF.Domain.Entities;

namespace GJF.BLL.Concrete
{
    public class TournamentWrestleBll : GenericBll<TournamentWrestle>, ITournamentWrestleBll
    {
        public TournamentWrestleBll(IGenericRepository<TournamentWrestle> genericRepository) : base(genericRepository)
        {
        }
    }
}
