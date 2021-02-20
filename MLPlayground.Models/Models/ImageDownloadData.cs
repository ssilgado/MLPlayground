using System.Drawing;

namespace MLPlayground.Models.Models
{
    public class ImageDownloadData
    {
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string ImageURL { get; set; }
        public string ImageClassification { get; set; }
    }
}