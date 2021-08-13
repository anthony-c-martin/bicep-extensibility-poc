namespace Extensibility.Core
{
    using System.Threading;
    using System.Threading.Tasks;
    using Extensibility.Core.Models;

    public interface IResourceOperations
    {
        Task<Resource> Save(Resource resource, CancellationToken cancellationToken);

        Task<Resource> PreviewSave(Resource resource, CancellationToken cancellationToken);

        Task<Resource> Get(Resource resource, CancellationToken cancellationToken);

        Task Delete(Resource resource, CancellationToken cancellationToken);
    }
}
