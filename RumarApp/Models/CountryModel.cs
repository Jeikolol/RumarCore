namespace RumarApp.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CodeAndDescription => $"{Code}-{Description}";
    }
}
