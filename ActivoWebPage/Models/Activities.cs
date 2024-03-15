using System;
namespace ActivoWebPage.Models
{
    public class Activities
    {
        public int activityID { get; set; }

        public string? name { get; set; }

        public string? description { get; set; }

        public string? imageLink { get; set; }

        public string? openHours { get; set; }

        public string? url { get; set; }

        public int? categoryID { get; set; }

        public Category[]? category { get; set; }

        public int? placesID { get; set; }

        public DateTime? timestamp { get; set; }

        public Tag[]? tags { get; set; }
    }
}
