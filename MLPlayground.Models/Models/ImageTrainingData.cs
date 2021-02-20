using System.IO;

using MLPlayground.Models.Constants;

namespace MLPlayground.Models.Models
{
    public class ImageTrainingData
    {


        public string ImageName { get; set; }
        public string ImageLocation
        {
            get { return Path.Combine(DataFiles.ImagesFolder, $"{ImageName}.jpeg"); }
        }
        public string ImageClassification { get; set; }
    }
}