namespace ActivoWebPage.Models
{
    public class Advertisements
    {

        public int advertisementID {  get; set; }
        public string? imageSource { get; set; }
        public string? imageLink { get; set; }
        public int totalViews { get; set; }
        public DateTime? timeStamp { get; set; }
        public string? imageDimension { get; set; }
        public int userID { get; set; }

    }
}
