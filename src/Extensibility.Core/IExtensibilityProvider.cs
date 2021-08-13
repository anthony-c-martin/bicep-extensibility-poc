namespace Extensibility.Core
{
    public interface IExtensibilityProvider
    {
        IResourceOperations? TryGetResource(string typeString);
    }
}
