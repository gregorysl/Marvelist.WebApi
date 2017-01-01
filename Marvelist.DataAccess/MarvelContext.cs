using System.Data.Entity;
using Marvelist.DataAccess.Configurations;
using Marvelist.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Marvelist.DataAccess
{
    public class MarvelEntities : IdentityDbContext<ApplicationUser>
    {
        public MarvelEntities()
            : base("MarvelEntities")
        {
        }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<UserComic> UserComics { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<UserSeries> UserSeries { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<ComicCreator> ComicCreators { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ComicCreatorConfiguration());
            modelBuilder.Configurations.Add(new ComicConfiguration());
            modelBuilder.Configurations.Add(new UserConfgiuration());
            modelBuilder.Configurations.Add(new SeriesConfiguration());
            modelBuilder.Configurations.Add(new CreatorConfiguration());
            modelBuilder.Configurations.Add(new UserComicConfiguration());
            modelBuilder.Configurations.Add(new UserSeriesConfiguration());
            
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
    public class MarvelInitializer : DropCreateDatabaseIfModelChanges<MarvelEntities>
    {
        protected override void Seed(MarvelEntities context)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExists("Member"))
            {
                roleManager.Create(new IdentityRole("Member"));
            }

            base.Seed(context);
        }
    }
}