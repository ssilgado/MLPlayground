using System.Drawing;

namespace MLPlayground.Models.Models
{
    public class ImageClientResponse
    {
        public Image Image { get; set; }
        public bool ResponseSuccessful { get; set; }
        public string Error { get; set; }
    }
}