namespace Extensibility.AzureStorage.Operations
{
    using Azure.Storage.Blobs;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensibility.Core;
    using Extensibility.Core.Models;

    internal class ContainerOperations : IResourceOperations
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

            var containerName = resource.Properties!["name"]!.ToString();

            var client = new BlobServiceClient(connectionString);

            await client
                .GetBlobContainerClient(containerName)
                .CreateIfNotExistsAsync();

            return resource;
        }
    }
}
