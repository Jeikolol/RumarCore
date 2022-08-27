using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RumarApp.Helpers;
using RumarApp.Parameters;

namespace RumarApp.Models
{
    public class LoanModel
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Capital { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal CapitalToShow { get; set; }
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
            var capital = (double)Capital;

            //Generate QuoteNumber
            for (i = 1; i <= RemainingPayments; i++)
            {
                var param = new PayLoanParameter
                {
                    LoanId = Id,
                    Client = Client.FullName,
                    Capital = capital,
                    Interest = Convert.ToDouble(TaxType.Percentage) / 1200,
                    Plazo = Convert.ToDouble(RemainingPayments),
                    PaymentDate = CreatedOn,
                    NextDate = DateTime.UtcNow,
                };

                param.Row = i;
                param.InterestMontlhy = 0;
                param.Amortization = 0;
                param.AmortizationTotal = 0;
                param.Mora = 0;

                //Amortizacion totales y principales
                param.Quote = param.Capital *
                              (param.Interest / (1 - Math.Pow(1 + param.Interest, -param.Plazo)));
                param.InterestMontlhy = (param.Interest * param.Capital);

                capital = (param.Capital - param.Quote + param.InterestMontlhy);

                param.Amortization = param.Quote - param.InterestMontlhy;
                param.AmortizationTotal += param.Amortization;
                param.PaymentDate = param.NextDate.AddDays(i);
                param.Mora = param.Quote * (double) CalculatorHelper.percentageOneValue(0.05m);

                AmortizationData.Add(param);
            }
        }

        public void CalculateBiweeklyPayment()
        {
            //Generate QuoteNumber
            int i;
            int days = 15;
            var capital = (double)Capital;

            for (i = 1; i <= RemainingPayments; i++, days += 15)
            {
                var param = new PayLoanParameter
                {
                    LoanId = Id,
                    Client = Client.FullName,
                    Capital = capital,
                    Interest = Convert.ToDouble(TaxType.Percentage) / 1200,
                    Plazo = Convert.ToDouble(RemainingPayments),
                    PaymentDate = CreatedOn,
                    NextDate = DateTime.UtcNow,
                    Row = i
                };

                param.InterestMontlhy = 0;
                param.Amortization = 0;
                param.AmortizationTotal = 0;
                param.Mora = 0;

                //Amortizacion totales y principales
                param.Quote = param.Capital *
                              (param.Interest / (1 - Math.Pow(1 + param.Interest, -param.Plazo)));

                param.InterestMontlhy = (param.Interest * param.Capital);
                capital = (param.Capital - param.Quote + param.InterestMontlhy);

                param.Amortization = param.Quote - param.InterestMontlhy;
                param.AmortizationTotal += param.Amortization;
                param.PaymentDate = param.NextDate.AddDays(days);
                param.Mora = param.Quote * (double)CalculatorHelper.percentageOneValue(0.05m);

                AmortizationData.Add(param);
            }
        }

        public void CalculateMonthlyPayment()
        {
            int i;
            var capital = (double)Capital;

            //Generate QuoteNumber
            for (i = 1; i <= RemainingPayments; i++)
            {
                var param = new PayLoanParameter
                {
                    LoanId = Id,
                    Client = Client.FullName,
                    Capital = capital,
                    Interest = Convert.ToDouble(TaxType.Percentage) / 1200,
                    Plazo = Convert.ToDouble(RemainingPayments),
                    PaymentDate = CreatedOn,
                    NextDate = DateTime.UtcNow,
                    Row = i
                };

                param.InterestMontlhy = 0;
                param.Amortization = 0;
                param.AmortizationTotal = 0;
                param.Mora = 0;
                
                //Amortizacion totales y principales
                param.Quote = param.Capital * (param.Interest / (1 - Math.Pow(1 + param.Interest, -param.Plazo)));
                param.InterestMontlhy = (param.Interest * param.Capital);
                capital = (param.Capital - param.Quote + param.InterestMontlhy);

                param.Amortization = param.Quote - param.InterestMontlhy;
                param.AmortizationTotal += param.Amortization;
                param.PaymentDate = param.NextDate.AddMonths(i);
                param.Mora = param.Quote * (double)CalculatorHelper.percentageOneValue(0.05m);

                AmortizationData.Add(param);
            }
        }
    }
}
