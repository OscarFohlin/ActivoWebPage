namespace ActivoWebPage.Models
{
    public class HomeViewModel
    {
        public List<Event?> Events { get; set; } = new List<Event?>();
        public List<Activity?> Activities { get; set; } = new List<Activity?>();
        public Advertisements? RandomAdvertisement { get; set; }
        public List<Tag?> Tags { get; set; } = new List<Tag?>();
    }
}
