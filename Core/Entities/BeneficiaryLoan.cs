namespace Core.Entities
{
    public class BeneficiaryLoan : Entity
    {
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
