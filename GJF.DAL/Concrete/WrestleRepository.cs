using GJF.DAL.Abstract;
using GJF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJF.DAL.Concrete
{
    public class WrestleRepository : GenericRepository<Wrestle, GJFDbContext>, IWrestleRepository
    {
    }
}
