
using System.ComponentModel.DataAnnotations;

namespace RumarApp.Enums
{
    public enum TransactionTypeEnum
    {
        [Display(Name = "Efectivo")]
        Cash = 1,
        [Display(Name = "Transferencia")]
        Transfer,
        [Display(Name = "Cheque")]
        Check
    }

    public enum TransactionPaymentEnum
    {
        [Display(Name = "Pago Diario")]
        DailyPayment = 1,
        [Display(Name = "Pago Quincenal")]
        BiweeklyPayment,
        [Display(Name = "Pago Mensual")]
        MonthlyPayment
    }
}
