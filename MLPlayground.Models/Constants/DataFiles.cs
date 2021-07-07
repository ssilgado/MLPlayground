using System.IO;

namespace MLPlayground.Models.Constants
{
    public class DataFiles
    {
        private static readonly string AssetsRelativePath = @"../../../../MLPlayground.Models/assets";
        private static readonly string AssetsPath = GetAbsolutePath(AssetsRelativePath);
        public static readonly string ImageDataSourceTsv = Path.Combine(AssetsPath, "inputs", "inception", "memegeneratortest.tsv");
        public static readonly string ImagesFolder = Path.Combine(AssetsPath, "inputs", "images");
        public static readonly string InceptionPb = Path.Combine(AssetsPath, "inputs", "inception", "tensorflow_inception_graph.pb");
        public static readonly string LabelsTxt = Path.Combine(AssetsPath, "inputs", "inception", "imagenet_comp_graph_label_strings.txt");

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new(typeof(DataFiles).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
    }
}