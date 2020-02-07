using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FluentAssertions;

namespace MarketingPageAcceptanceTests.TestData.Azure
{
    public sealed class AzureBlobStorage
    {
        public Dictionary<string, string> SolutionIdsToGuids = new Dictionary<string, string>();
        private List<string> listOfBlobContainerNames = new List<string>();
        private BlobServiceClient blobServiceClient;

        public AzureBlobStorage(string connectionString)
        {
            blobServiceClient = new BlobServiceClient(connectionString);            
        }

        public async Task InsertFileToStorage(string containerName, string solutionId, string fileName, string fullFilePath)
        {
            InsertIntoMapping(solutionId);
            if (!listOfBlobContainerNames.Contains(containerName))
            {
                listOfBlobContainerNames.Add(containerName);
            }
            var currentContainer = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = currentContainer.GetBlobClient(Path.Combine(SolutionIdsToGuids[solutionId], fileName));
            using var uploadFileStream = File.OpenRead(fullFilePath);
            var response = await blobClient
                .UploadAsync(uploadFileStream, new BlobHttpHeaders())
                .ConfigureAwait(false);

            response.GetRawResponse().Status.Should().Be(201);            
        }

        public async Task ClearStorage()
        {
            foreach (var directory in SolutionIdsToGuids.Values)
            {
                foreach (var container in listOfBlobContainerNames)
                {
                    var currentContainer = blobServiceClient.GetBlobContainerClient(container);
                    foreach (var blob in currentContainer.GetBlobs(prefix: directory))
                    {
                        await currentContainer.DeleteBlobAsync(blob.Name);
                    }
                }
            }
        }

        //I don't think we need this
        public string TryToGetGuidFromSolutionId(string solutionId)
        {
            if (!SolutionIdsToGuids.TryGetValue(solutionId, out string slnId))
            {
                slnId = solutionId;
            }
            return slnId;
        }

        private void InsertIntoMapping(string solutionId)
        {
            if (!SolutionIdsToGuids.ContainsKey(solutionId))
            {
                SolutionIdsToGuids[solutionId] = Guid.NewGuid().ToString();
            }
        }
    }
}
