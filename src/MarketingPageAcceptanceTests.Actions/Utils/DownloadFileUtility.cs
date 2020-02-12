using System.IO;
using System.Net;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    public static class DownloadFileUtility
    {
        public static void DownloadFile(string fileName, string downloadPath, string downloadLink)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(downloadLink, Path.Combine(downloadPath, fileName));
            }
        }
    }
}
