using System.IO;
using System.Linq;
using System.Net;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    public static class DownloadFileUtility
    {
        public static void DownloadFile(string fileName, string downloadPath, string downloadLink)
        {
            downloadLink = DownloadFileUtility.TransformLocalHost(downloadLink);
            CreateDirectory(downloadPath);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(downloadLink, Path.Combine(downloadPath, fileName));
            }
        }

        public static string TransformLocalHost(string urlIn)
        {
            var urlOut = urlIn;
            if (urlIn.Contains("host.docker.internal"))
            {
                urlOut = urlOut.Replace("host.docker.internal", "localhost");
            }
            return urlOut;
        }

        public static bool CompareTwoFiles(string filePath1, string filePath2)
        {
            return new FileInfo(filePath1).Length == new FileInfo(filePath2).Length &&
                File.ReadAllBytes(filePath1).SequenceEqual(File.ReadAllBytes(filePath2));
        }

        private static void CreateDirectory(string directory)
        {
            System.IO.Directory.CreateDirectory(directory);
        }
    }
}
