using System.Drawing;
using System.IO;

using MLPlayground.Models.Constants;

namespace MLPlayground.Models.Models
{
    public class ImageDownloadData
    {
        public string ImageId { get; set; }
        public Image Image { get; set; }
        public string ImageURL { get; set; }
        public string ImageClassification { get; set; }
        public bool ImageAlreadyDownloaded 
        {
            get { return File.Exists(Path.Combine(DataFiles.ImagesFolder, $"{ImageClassification}{ImageId}.jpeg")); }
        }
    }
}