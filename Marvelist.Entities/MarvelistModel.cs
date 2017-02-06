using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marvelous;

namespace Marvelist.Entities
{
    public abstract class MarvelistModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public MarvelImage Thumbnail { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
