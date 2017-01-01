using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
            Property(t => t.ComicId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_ComicUser", 1) { IsUnique = true }));
            Property(t => t.UserId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_ComicUser", 2) { IsUnique = true }));
        }
    }
}
