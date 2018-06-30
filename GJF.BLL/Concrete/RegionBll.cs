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
    public class RegionBll : GenericBll<Region>, IRegionBll
    {
        public RegionBll(IGenericRepository<Region> genericRepository) : base(genericRepository)
        {
        }
    }
}
