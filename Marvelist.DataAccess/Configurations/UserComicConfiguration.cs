using System.Data.Entity.ModelConfiguration;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Configurations
{
    public class UserComicConfiguration : EntityTypeConfiguration<UserComic>
    {
        public UserComicConfiguration()
        {
            ToTable("UserComics");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(c => c.Date).HasColumnType("datetime2");

            //HasRequired(e => e.Comic).WithMany(x => x.UserComic).Map(s => s.MapKey("ComicId")).WillCascadeOnDelete(false);
            //HasRequired(e => e.User).WithMany(x => x.Comics).Map(s => s.MapKey("UserId")).WillCascadeOnDelete(false);
        }
    }
}
