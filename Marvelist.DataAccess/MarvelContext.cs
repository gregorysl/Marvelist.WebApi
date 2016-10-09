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

            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
        }
    }
    public class MarvelInitializer : DropCreateDatabaseIfModelChanges<MarvelEntities>
    {
        protected override void Seed(MarvelEntities context)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            base.Seed(context);
            var u = new ApplicationUser
            {
                Email = "12312312",
                UserName = "12312312",
                EmailConfirmed = true
            };
            var userResult = userManager.Create(u, "qweqweqwe");

            var s = new Series { Id = 1, Title = "asdasd" };
            context.Series.Add(s);
            context.SaveChanges();
            var c = new Comic
            {
                Id = 1,
                Title = "asdasd",
                Series = s
            };
            context.Comics.Add(c);
            context.SaveChanges();
            var cr = new Creator
            {
                Id = 1,
                Title = "asdasd",

            };
            context.Creators.Add(cr);
            context.SaveChanges();
            var userSeries = new UserSeries { Series = s, User = u };
            context.UserSeries.Add(userSeries);
            context.SaveChanges();
            var userComic = new UserComic { Comic = c, User = u };
            context.UserComics.Add(userComic);
            context.SaveChanges();
            var comicCreator = new ComicCreator { Comic = c, Creator = cr };
            context.ComicCreators.Add(comicCreator);
            context.SaveChanges();
            context.UserSeries.Remove(userSeries);
            context.SaveChanges();
            context.UserComics.Remove(userComic);
            context.SaveChanges();
            context.ComicCreators.Remove(comicCreator);
            context.SaveChanges();

        }
    }
}