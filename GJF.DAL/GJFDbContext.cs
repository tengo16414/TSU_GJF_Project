using GJF.DAL.Migrations;
using GJF.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GJF.DAL
{
    public class GJFDbContext : DbContext
    {
        public GJFDbContext() : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;

            //stop circular reference error beetwen task and stage
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<GJFDbContext>(new MigrateDatabaseToLatestVersion<GJFDbContext, Configuration>());


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Sportsman> Sportsmans { get; set; }
        public virtual DbSet<Wrestle> Wrestles { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentSportsman> TournamentSportsmen { get; set; }
        public virtual DbSet<TournamentWrestle> TournamentWrestles { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
    }
}