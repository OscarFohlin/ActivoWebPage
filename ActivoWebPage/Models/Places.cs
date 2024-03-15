namespace ActivoWebPage.Models
{
    public class Places
    {
        public int PlacesID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int Capacity { get; set; }
        public string? Facilities { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
