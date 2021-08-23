using System;

namespace RumarApp.Models
{
    public class Entity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedReason { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
