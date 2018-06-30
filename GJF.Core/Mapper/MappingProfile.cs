using AutoMapper;
using GJF.Domain.Entities;
using GJF.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJF.Domain.Models.Region;
using GJF.Domain.Models.Sportsman;
using GJF.Domain.Models.Tournament;
using GJF.Domain.Models.TournamentSportsman;
using GJF.Domain.Models.Wrestle;

namespace GJF.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserViewModel>().ForMember(user => user.RoleId, map => map.MapFrom(r => r.UserRoles.FirstOrDefault().RoleId))
                                             .ForMember(user => user.Role, map => map.MapFrom(r => r.UserRoles.FirstOrDefault().Role));
            CreateMap<UserViewModel, User>();


            CreateMap<User, UserEditModel>().ForMember(user => user.RoleId, map => map.MapFrom(r => r.UserRoles.FirstOrDefault().RoleId))
                                             .ForMember(user => user.Role, map => map.MapFrom(r => r.UserRoles.FirstOrDefault().Role));
            CreateMap<UserEditModel, User>();

            CreateMap<Region, RegionViewModel>();
            CreateMap<RegionViewModel, Region>();

            CreateMap<Region, RegionEditModel>();
            CreateMap<RegionEditModel, Region>();

            CreateMap<Sportsman, SportsmanViewModel>();
            CreateMap<SportsmanViewModel, Sportsman> ();

            CreateMap<Sportsman, SportsmanEditModel>();
            CreateMap<SportsmanEditModel, Sportsman>();

            CreateMap<Wrestle, WrestleViewModel>();
            CreateMap<WrestleViewModel, Wrestle>();

            CreateMap<Wrestle, WrestleEditModel>();
            CreateMap<WrestleEditModel, Wrestle>();

            CreateMap<Tournament, TournamentEditModel>();
            CreateMap<TournamentEditModel, Tournament>();

            CreateMap<Tournament, TournamentViewModel>();
            CreateMap<TournamentViewModel, Tournament>();

            CreateMap<TournamentSportsman, TournamentSportsmanEditModel>();
            CreateMap<TournamentSportsmanEditModel, TournamentSportsman>();

            CreateMap<TournamentSportsman, TournamentSportsmanViewModel>();
            CreateMap<TournamentSportsmanViewModel, TournamentSportsman>();
        }
    }
}
