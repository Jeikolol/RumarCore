using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RumarApp.Helpers;
using RumarApp.Infraestructure;
using RumarApp.Parameters;

namespace RumarApp.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public long Capital { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public long CapitalToShow { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal Quote { get; set; }
        public decimal RemainingPayments { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Notes { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClientId { get; set; }
        public virtual ClientViewModel Client { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionTypeId { get; set; }
        public virtual TransactionTypeModel TransactionType { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TransactionPaymentId { get; set; }
        public virtual TransactionPaymentModel TransactionPayment { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int ClientTypeId { get; set; }
        public virtual ClientTypeModel ClientType { get; set; }
        public virtual ICollection<BeneficiaryModel> Beneficiary { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsFullPaid { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public int TaxTypeId { get; set; }
        public virtual TaxTypeModel TaxType { get; set; }

        public List<PayLoanParameter> AmortizationData { get; set; } = new List<PayLoanParameter>();

        public void CalculateDailyPayment()
        {
            int i;

            //Generate QuoteNumber
            for (i = 1; i <= RemainingPayments; i++)
            {
                var param = new PayLoanParameter
                {
                    LoanId = Id,
                    Client = Client.FullName,
                    Capital = Capital,
                    Interest = Convert.ToDouble(TaxType.Percentage) / 1200,
                    Plazo = Convert.ToDouble(RemainingPayments),
                    PaymentDate = CreatedOn,
                    NextDate = DateTime.UtcNow,
                    Row = i,
                };

                param.Quote = Capital *
                              (param.Interest / (1 - Math.Pow(1 + param.Interest, -param.Plazo)));
                param.InterestMontlhy = 0;
                param.Amortization = 0;
                param.AmortizationTotal = 0;
                param.Mora = 0;
                param.InterestMontlhy = (param.Interest * Capital);
                param.Capital = (param.Capital - param.Quote + param.InterestMontlhy);

                //Amortizacion totales y principales

                param.AmortizationTotal += (param.Quote - param.InterestMontlhy);
                param.Amortization = param.Quote - param.InterestMontlhy;
                param.PaymentDate = param.NextDate.AddDays(param.Row);
                param.Mora = param.Quote * (double) CalculatorHelper.percentageOneValue(0.05m);

                AmortizationData.Add(param);
            }
        }

        public void CalculateBiweeklyPayment()
        {
            int i = 1;

            var param = new PayLoanParameter
            {
                LoanId = Id,
                Client = Client.FullName,
                Capital = Capital,
                Interest = Convert.ToDouble(TaxType.Percentage) / 1200,
                Plazo = Convert.ToDouble(RemainingPayments),
                PaymentDate = CreatedOn,
                NextDate = DateTime.UtcNow,
            };

            //Generate QuoteNumber

            int days = 15;

            for (i = 1; i <= param.Plazo; i++, days += 15)
            {
                param.Row = i;
                param.Quote = param.Capital *
                              (param.Interest / (1 - Math.Pow(1 + param.Interest, -param.Plazo)));

                param.InterestMontlhy = 0;
                param.Amortization = 0;
                param.AmortizationTotal = 0;
                param.Mora = 0;
                param.InterestMontlhy = (param.Interest * param.Capital);
                param.Capital = (param.Capital - param.Quote + param.InterestMontlhy);

                //Amortizacion totales y principales

                param.AmortizationTotal += (param.Quote - param.InterestMontlhy);
                param.Amortization = param.Quote - param.InterestMontlhy;
                param.PaymentDate = param.NextDate.AddDays(days);
                param.Mora = param.Quote * (double)CalculatorHelper.percentageOneValue(0.05m);

                AmortizationData.Add(param);
            }
        }

        public void CalculateMonthlyPayment()
        {
            int i = 1;

            var param = new PayLoanParameter
            {
                LoanId = Id,
                Client = Client.FullName,
                Capital = Capital,
                Interest = Convert.ToDouble(TaxType.Percentage) / 1200,
                Plazo = Convert.ToDouble(RemainingPayments),
                PaymentDate = CreatedOn,
                NextDate = DateTime.UtcNow,
                Row = 1
            };

            //Generate QuoteNumber


            for (i = 1; i <= param.Plazo; i++)
            {
                param.Row = i;
                param.Quote = param.Capital * (param.Interest / (1 - Math.Pow(1 + param.Interest, -param.Plazo)));
                param.InterestMontlhy = 0;
                param.Amortization = 0;
                param.AmortizationTotal = 0;
                param.Mora = 0;
                param.InterestMontlhy = (param.Interest * param.Capital);
                param.Capital = (param.Capital - param.Quote + param.InterestMontlhy);

                //Amortizacion totales y principales

                param.AmortizationTotal += (param.Quote - param.InterestMontlhy);
                param.Amortization = param.Quote - param.InterestMontlhy;
                param.PaymentDate = param.NextDate.AddMonths(param.Row);
                param.Mora = param.Quote * (double)CalculatorHelper.percentageOneValue(0.05m);

                AmortizationData.Add(param);
            }
        }
    }
}
