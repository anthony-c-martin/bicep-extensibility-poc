using Extensibility.Core;

namespace Extensibility.Kubernetes
{
    public class KubernetesProvider : IExtensibilityProvider
    {
        // HEY LISTEN: what are the semantics of this? Why do we need this level of indirection
        // vs just throwing inside the IResourceOperations if we don't recognize the type.
        public IResourceOperations? TryGetResource(string typeString)
        {
            return new KubernetesOperations();
        }
    }
}