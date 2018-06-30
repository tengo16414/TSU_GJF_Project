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
    public class SportsmanBll : GenericBll<Sportsman>, ISportsmanBll
    {
        public SportsmanBll(IGenericRepository<Sportsman> genericRepository) : base(genericRepository)
        {
        }
    }
}
