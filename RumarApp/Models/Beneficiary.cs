using System.ComponentModel.DataAnnotations;

namespace RumarApp.Models
{
    public class Beneficiary : Entity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string FisrtName { get; set; }
        [StringLength(60)]
        public string LastName { get; set; }
        public string FullName => $"{FisrtName + " " + LastName}";
        [StringLength(12)]
        public string Identification { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        public int RelationshipTypeId { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }

    }
}
