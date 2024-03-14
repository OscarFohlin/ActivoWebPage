namespace ActivoWebPage.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public int UserID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int? PlacesID { get; set; }

        public decimal? Price { get; set; }

        public string? URL { get; set; }

        public int? CategoryID { get; set; }

        public DateTime? TimeStamp { get; set; }

        public string[]? ImageData { get; set; }

        public int[]? TagID { get; set; }
    }
}
