using System.Drawing;

namespace MLPlayground.Models.Models
{
    public class ImageNetData
    {
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string ImageURL { get; set; }
        public string ImageClassification { get; set; }
    }
}