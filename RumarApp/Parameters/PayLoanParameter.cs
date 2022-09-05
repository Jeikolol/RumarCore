using System;
using System.ComponentModel.DataAnnotations;
using RumarApp.Helpers;

namespace RumarApp.Parameters
{
    public class PayLoanParameter
    {
        public int LoanId { get; set; }
        public string Client { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Balance { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Interest { get; set; }

        public double Plazo { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Quote { get; set; }

        public decimal QuoteFormatted => Quote.Round(2);

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal InterestMontlhy { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Capital { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Mora { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime PaymentDate { get; set; }
        public string PaymentDateFormatted => PaymentDate.ToString("dd/MM/yyyy");

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NextDate { get; set; }
        public string NextDateFormatted => NextDate.ToString("dd/MM/yyyy");

        public int Row { get; set; }
    }
}
