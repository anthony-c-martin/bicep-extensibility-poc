namespace Extensibility.AzureStorage.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
    using Extensibility.Core.Models;
    using Extensibility.Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public async Task Save_container()
        {
            await CrudHelper.Save(new Resource
            {
                Type = "container",
                Import = TestHelper.BuildImport(),
                Properties = new JObject
                {
                    ["name"] = "TestContainer",
                }
            }, CancellationToken.None);
        }
    }
}
