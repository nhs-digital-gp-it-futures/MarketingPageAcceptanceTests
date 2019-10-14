using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketingPageAcceptanceTests.Actions.Utils
{
    public sealed class ResetDbEntry : IDisposable
    {
        private readonly string uri;
        private string solutionInfo;
        private readonly HttpClient client;

        public ResetDbEntry(string url, string apiUrl)
        {
            var slnID = url.Split('/').Last();
            uri = $"{apiUrl}/api/v1/solutions/{slnID}";
            client = new HttpClient();
        }

        /// <summary>
        /// Get the solution details to be used at a later stage
        /// </summary>
        /// <returns></returns>
        public async Task GetSolutionDetails()
        {
            solutionInfo = await client.GetStringAsync(uri).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Reset the used solution to ensure a clean start point for all tests
        /// </summary>
        /// <returns></returns>
        public async Task PutSolutionDetails()
        {
            var response = await client.PutAsync(uri, new StringContent(solutionInfo, Encoding.UTF8, "application/json")).ConfigureAwait(continueOnCapturedContext: false); ;
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
