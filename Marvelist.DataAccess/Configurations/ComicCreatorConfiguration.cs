using System.Data.Entity.ModelConfiguration;
using Marvelist.Entities;

namespace Marvelist.DataAccess.Configurations
{
    class ComicCreatorConfiguration : EntityTypeConfiguration<ComicCreator>
    {
        public ComicCreatorConfiguration()
        {
            ToTable("ComicCreators");
            
            //HasRequired(e => e.Comic).WithMany(x => x.ComicCreator).Map(s => s.MapKey("ComicId")).WillCascadeOnDelete(false);
            //HasRequired(e => e.Creator).WithMany(x => x.ComicCreator).Map(s => s.MapKey("CreatorId")).WillCascadeOnDelete(false);
        }
    }
}
