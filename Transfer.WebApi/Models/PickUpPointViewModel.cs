namespace Transfer.WebApi.Models
{
    public class PickUpPointViewModel
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int Latitude { get; set; }
        public int LongiTude { get; set; }
        public string Name { get; set; }
    }
}
