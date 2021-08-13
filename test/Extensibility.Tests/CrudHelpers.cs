namespace Extensibility.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensibility.Core;
    using Extensibility.Core.Models;

    public static class CrudHelper
    {
        private static IResourceOperations GetResourceOperations(Resource resource)
        {
            var providerName = resource.Import?.Provider ?? throw new InvalidOperationException($"resource.Import.Provider should not be null");
            var typeString = resource.Type ?? throw new InvalidOperationException($"resource.Type should not be null");

            var provider = Providers.TryGetProvider(providerName) ?? throw new InvalidOperationException($"Failed to find provider \"{providerName}\"");
            var operations = provider.TryGetResource(typeString) ?? throw new InvalidOperationException($"Failed to find resource \"{typeString}\" in provider \"{providerName}\"");

            return operations;
        }

        public static async Task Delete(Resource resource, CancellationToken cancellationToken)
        {
            await GetResourceOperations(resource).Delete(resource, cancellationToken);
        }

        public static async Task<Resource> Get(Resource resource, CancellationToken cancellationToken)
        {
            return await GetResourceOperations(resource).Get(resource, cancellationToken);
        }

        public static async Task<Resource> PreviewSave(Resource resource, CancellationToken cancellationToken)
        {
            return await GetResourceOperations(resource).PreviewSave(resource, cancellationToken);
        }

        public static async Task<Resource> Save(Resource resource, CancellationToken cancellationToken)
        {
            return await GetResourceOperations(resource).Save(resource, cancellationToken);
        }
    }
}
