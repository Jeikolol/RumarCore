namespace RumarApp.Helpers
{
    public static class DecimalExtension
    {
        public static decimal Round(this decimal value, int places)
        {
            return decimal.Round(value, places);
        }
    }
}
