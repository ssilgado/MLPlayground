using System.Drawing;

namespace MLPlayground.Models.Models
{
    public class ImageClientResponse
    {
        public Image Image { get; set; }
        public string[] Errors { get; set; }
    }
}