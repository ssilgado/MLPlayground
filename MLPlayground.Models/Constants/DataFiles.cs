using System.IO;

namespace MLPlayground.Models.Constants
{
    public class DataFiles
    {
        private static string AssetsRelativePath = @"../../../../MLPlayground.Models/assets";
        private static string AssetsPath = GetAbsolutePath(AssetsRelativePath);
        public static string ImageDataSourceTsv = Path.Combine(AssetsPath, "inputs", "inception", "memegeneratortest.tsv");
        public static string ImagesFolder = Path.Combine(AssetsPath, "inputs", "images");
        public static string InceptionPb = Path.Combine(AssetsPath, "inputs", "inception", "tensorflow_inception_graph.pb");
        public static string LabelsTxt = Path.Combine(AssetsPath, "inputs", "inception", "imagenet_comp_graph_label_strings.txt");

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(DataFiles).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
    }
}