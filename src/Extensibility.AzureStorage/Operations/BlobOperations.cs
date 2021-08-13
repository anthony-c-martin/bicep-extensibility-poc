namespace Extensibility.AzureStorage.Operations
{
    using Azure.Storage.Blobs;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensibility.Core;
    using Extensibility.Core.Models;

    internal class BlobOperations : IResourceOperations
    {
        public async Task Delete(Resource resource, CancellationToken cancellationToken)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<Resource> Get(Resource resource, CancellationToken cancellationToken)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<Resource> PreviewSave(Resource resource, CancellationToken cancellationToken)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        public async Task<Resource> Save(Resource resource, CancellationToken cancellationToken)
        {
            var connectionString = resource.Import!.Config!["connectionString"]!.ToString();

            var containerName = resource.Properties!["containerName"]!.ToString();
            var name = resource.Properties!["name"]!.ToString();
            var base64Content = resource.Properties!["base64Content"]!.ToString();

            var client = new BlobServiceClient(connectionString);

            var bytes = Convert.FromBase64String(base64Content);
            await client
                .GetBlobContainerClient(containerName)
                .GetBlobClient(name)
                .UploadAsync(new MemoryStream(bytes), overwrite: true, cancellationToken);

            return resource;
        }
    }
}
