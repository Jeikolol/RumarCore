using System;
using System.ComponentModel.DataAnnotations;

namespace RumarApp.Parameters
{
    public class PayLoanParameter
    {
        public int LoanId { get; set; }
        public string Client { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{C2}")]
        public double Capital { get; set; }

        public string CapitalFormatted => Capital.ToString("C2");

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{C2}")]
        public double Interest { get; set; }
        public string InterestFormatted => Interest.ToString("C2");

        public double Plazo { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{C2}")]
        public double Quote { get; set; }
        public string QuoteFormatted => Quote.ToString("C2");

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{C2}")]
        public double InterestMontlhy { get; set; }
        public string InterestMontlhyFormatted => InterestMontlhy.ToString("C2");

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{C2}")]
        public double Amortization { get; set; }
        public string AmortizationFormatted => Amortization.ToString("C2");

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{C2")]
        public double AmortizationTotal { get; set; }
        public string AmortizationTotalFormatted => AmortizationTotal.ToString("C2");

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{C2}")]
        public double Mora { get; set; }
        public string MoraFormatted => Mora.ToString("C2");

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime PaymentDate { get; set; }
        public string PaymentDateFormatted => PaymentDate.ToString("dd/MM/yyyy");

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime NextDate { get; set; }
        public string NextDateFormatted => NextDate.ToString("dd/MM/yyyy");

        public int Row { get; set; }
    }
}
