using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using GJF.DAL.Abstract;

namespace GJF.BLL.Concrete
{
    public class WrestleBll : GenericBll<Wrestle>, IWrestleBll
    {
        public WrestleBll(IGenericRepository<Wrestle> genericRepository) : base(genericRepository)
        {
        }
    }
}
