namespace Extensibility.AzureStorage
{
    using System.Collections.Generic;
    using Extensibility.Core;
    using Extensibility.AzureStorage.Operations;

    public class AzureStorageProvider : IExtensibilityProvider
    {
        private static readonly IReadOnlyDictionary<string, IResourceOperations> OperationsLookup = new Dictionary<string, IResourceOperations>
        {
            ["blob"] = new BlobOperations(),
            ["container"] = new ContainerOperations(),
        };

        public IResourceOperations? TryGetResource(string typeString)
            => OperationsLookup.TryGetValue(typeString, out var operations) ? operations : null;
    }
}