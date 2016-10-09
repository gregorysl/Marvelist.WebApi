using System.ComponentModel.DataAnnotations.Schema;

namespace Marvelist.Core.Infrastructure
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
