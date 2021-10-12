using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Infraestructure
{
    public interface ISoftDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
        int? DeletedByUserId { get; set; }
        string DeletedReason { get; set; }
    }
}
