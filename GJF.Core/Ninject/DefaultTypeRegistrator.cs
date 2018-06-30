using GJF.BLL.Abstract;
using GJF.BLL.Concrete;
using GJF.BLL.Helpers.Security;
using GJF.DAL;
using GJF.DAL.Abstract;
using GJF.DAL.Concrete;
using GJF.Domain.Entities;
using Ninject.Web.Common;

namespace GJF.Core.Ninject
{
    public class DefaultTypeRegistrator
    {
        public void Register(ITypeRegistrator registrator)
        {

            registrator.Kernel.Bind<GJFDbContext>().ToSelf().InRequestScope();
            registrator.RegisterType<ISignInManager, SignInManager>();
            

            registrator.RegisterType<IGenericRepository<User>, UserRepository>();
            registrator.RegisterType<IUserRepository, UserRepository>();
            registrator.RegisterType<IUserBll, UserBll>();

            registrator.RegisterType<IGenericRepository<Role>, RoleRepository>();
            registrator.RegisterType<IRoleRepository, RoleRepository>();
            registrator.RegisterType<IRoleBll, RoleBll>();

            registrator.RegisterType<IGenericRepository<UserRole>, UserRoleRepository>();
            registrator.RegisterType<IUserRoleRepository, UserRoleRepository>();
            registrator.RegisterType<IUserRoleBll, UserRoleBll>();

            registrator.RegisterType<IGenericRepository<Region>, RegionRepository>();
            registrator.RegisterType<IRegionRepository, RegionRepository>();
            registrator.RegisterType<IRegionBll, RegionBll>();

            registrator.RegisterType<IGenericRepository<Sportsman>, SportsmanRepository>();
            registrator.RegisterType<ISportsmanRepository, SportsmanRepository>();
            registrator.RegisterType<ISportsmanBll, SportsmanBll>();

            registrator.RegisterType<IGenericRepository<Wrestle>, WrestleRepository>();
            registrator.RegisterType<IWrestleRepository, WrestleRepository>();
            registrator.RegisterType<IWrestleBll, WrestleBll>();

            registrator.RegisterType<IGenericRepository<Tournament>, TournamentRepository>();
            registrator.RegisterType<ITournamentRepository, TournamentRepository>();
            registrator.RegisterType<ITournamentBll, TournamentBll>();

            registrator.RegisterType<IGenericRepository<TournamentSportsman>, TournamentSportsmanRepository>();
            registrator.RegisterType<ITournamentSportsmanRepository, TournamentSportsmanRepository>();
            registrator.RegisterType<ITournamentSportsmanBll, TournamentSportsmanBll>();

            registrator.RegisterType<IGenericRepository<TournamentWrestle>, TournamentWrestleRepository>();
            registrator.RegisterType<ITournamentWrestleRepository, TournamentWrestleRepository>();
            registrator.RegisterType<ITournamentWrestleBll, TournamentWrestleBll>();
        }
    }
}
