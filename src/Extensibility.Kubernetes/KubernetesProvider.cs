namespace Extensibility.Kubernetes
{
    using System.Collections.Generic;
    using Extensibility.Core;

    public class KubernetesProvider : IExtensibilityProvider
    {
        private static readonly IReadOnlyDictionary<string, IResourceOperations> OperationsLookup = new Dictionary<string, IResourceOperations>
        {
        };

        public IResourceOperations? TryGetResource(string typeString)
            => OperationsLookup.TryGetValue(typeString, out var operations) ? operations : null;
    }
}