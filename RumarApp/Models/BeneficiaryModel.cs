using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RumarApp.Models
{
    public class BeneficiaryModel
    {
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
        public int ClientId { get; set; }
        public virtual ClientViewModel Client { get; set; }
        public string RelationshipType { get; set; }
    }
}
