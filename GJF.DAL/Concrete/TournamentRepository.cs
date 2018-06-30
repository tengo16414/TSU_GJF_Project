using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJF.DAL.Abstract;
using GJF.Domain.Entities;

namespace GJF.DAL.Concrete
{
    public class TournamentRepository : GenericRepository<Tournament, GJFDbContext>, ITournamentRepository { 
    }
}
