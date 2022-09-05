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
        public int Quote { get; set; }
        public int RemainingPayments { get; set; }
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
            var capital = Capital;

            //Generate QuoteNumber
            for (i = 1; i <= RemainingPayments; i++)
            {
                var param = new PayLoanParameter
                {
                    LoanId = Id,
                    Client = Client.FullName,
                    Balance = capital,
                    Interest = TaxType.Percentage / 1200,
                    Plazo = Convert.ToDouble(RemainingPayments),
                    PaymentDate = CreatedOn,
                    NextDate = DateTime.UtcNow,
                };

                param.Row = i;
                param.InterestMontlhy = 0;
                param.Capital = 0;
                param.Mora = 0;

                //Amortizacion totales y principales
                param.Quote = param.Balance *
                              (param.Interest / (decimal)(1 - Math.Pow(1 + (double)param.Interest, -param.Plazo)));
                param.InterestMontlhy = (param.Interest * param.Balance);

                capital = (param.Balance - param.Quote + param.InterestMontlhy);

                param.Capital = param.Quote - param.InterestMontlhy;
                param.PaymentDate = param.NextDate.AddDays(i);
                param.Mora = (double)(param.Quote * CalculatorHelper.percentageOneValue(0.05m));

                AmortizationData.Add(param);
            }
        }

        public void CalculateBiweeklyPayment()
        {
            //Generate QuoteNumber
            int i;
            int days = 15;
            var capital = Capital;

            for (i = 1; i <= RemainingPayments; i++, days += 15)
            {
                var param = new PayLoanParameter
                {
                    LoanId = Id,
                    Client = Client.FullName,
                    Balance = capital,
                    Interest = TaxType.Percentage / 1200,
                    Plazo = Convert.ToDouble(RemainingPayments),
                    PaymentDate = CreatedOn,
                    NextDate = DateTime.UtcNow,
                    Row = i
                };

                param.InterestMontlhy = 0;
                param.Capital = 0;
                param.Mora = 0;

                //Amortizacion totales y principales
                param.Quote = param.Balance *
                              (param.Interest / (decimal)(1 - Math.Pow(1 + (double)param.Interest, -param.Plazo)));

                param.InterestMontlhy = (param.Interest * param.Balance);
                capital = (param.Balance - param.Quote + param.InterestMontlhy);

                param.Capital = param.Quote - param.InterestMontlhy;
                param.PaymentDate = param.NextDate.AddDays(days);
                param.Mora = (double)(param.Quote * CalculatorHelper.percentageOneValue(0.05m));

                AmortizationData.Add(param);
            }
        }

        public void CalculateMonthlyPayment()
        {
            int i;
            var capital = Capital;

            //Generate QuoteNumber
            for (i = 1; i <= RemainingPayments; i++)
            {
                var param = new PayLoanParameter
                {
                    LoanId = Id,
                    Client = Client.FullName,
                    Balance = capital,
                    Interest = TaxType.Percentage / 1200,
                    Plazo = Convert.ToDouble(RemainingPayments),
                    PaymentDate = CreatedOn,
                    NextDate = DateTime.UtcNow,
                    Row = i
                };

                param.InterestMontlhy = 0;
                param.Capital = 0;
                param.Mora = 0;
                
                //Amortizacion totales y principales
                param.Quote = param.Balance * (param.Interest / (decimal)(1 - Math.Pow(1 + (double)param.Interest, -param.Plazo)));
                param.InterestMontlhy = (param.Interest * param.Balance);
                capital = (param.Balance - param.Quote + param.InterestMontlhy);

                param.Capital = param.Quote - param.InterestMontlhy;
                param.PaymentDate = param.NextDate.AddMonths(i);
                param.Mora = (double)(param.Quote * CalculatorHelper.percentageOneValue(0.05m));

                AmortizationData.Add(param);
            }
        }
    }
}
