using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MarketingPageAcceptanceTests.TestData.Azure
{
    public sealed class AzureBlobStorage
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly List<string> listOfBlobContainerNames = new List<string>();
        public List<string> listOfSolutionIds = new List<string>();

        public AzureBlobStorage(string connectionString)
        {
            blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task InsertFileToStorage(string containerName, string solutionId, string fileName,
            string fullFilePath)
        {
            if (!listOfSolutionIds.Contains(solutionId)) listOfSolutionIds.Add(solutionId);

            if (!listOfBlobContainerNames.Contains(containerName)) listOfBlobContainerNames.Add(containerName);

            var currentContainer = blobServiceClient.GetBlobContainerClient(containerName);
            currentContainer.CreateIfNotExists();

            var blobClient = currentContainer.GetBlobClient(Path.Combine(solutionId, fileName));
            using var uploadFileStream = File.OpenRead(fullFilePath);
            var response = await blobClient
                .UploadAsync(uploadFileStream, new BlobHttpHeaders())
                .ConfigureAwait(false);

            response.GetRawResponse().Status.Should().Be(201);
        }

        public async Task ClearStorage()
        {
            foreach (var directory in listOfSolutionIds)
                foreach (var container in listOfBlobContainerNames)
                {
                    var currentContainer = blobServiceClient.GetBlobContainerClient(container);
                    foreach (var blob in currentContainer.GetBlobs(prefix: directory))
                        await currentContainer.DeleteBlobAsync(blob.Name);
                }
        }
    }
}