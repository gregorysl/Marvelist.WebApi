using System;

namespace Marvelist.Core.Infrastructure
{
    public interface IAuditableEntity
    {
        DateTime UpdateAt { get; set; }
        DateTime CreateAt { get; set; }
        string CreateBy { get; set; }
        string UpdateBy { get; set; }
    }
}
