using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedReason { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
