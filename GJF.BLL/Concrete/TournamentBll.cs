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
    public class TournamentBll : GenericBll<Tournament>, ITournamentBll
    {
        public TournamentBll(IGenericRepository<Tournament> genericRepository) : base(genericRepository)
        {
        }
    }
}
