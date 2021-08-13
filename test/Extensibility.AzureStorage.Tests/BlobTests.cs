namespace Extensibility.AzureStorage.Tests
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensibility.Core.Models;
    using Extensibility.Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    [TestClass]
    public class BlobTests
    {
        [TestMethod]
        public async Task Save_blob()
        {
            // Blob requires a container first - create it here.
            await CrudHelper.Save(new Resource
            {
                Type = "container",
                Import = TestHelper.BuildImport(),
                Properties = new JObject
                {
                    ["name"] = "blobTest",
                }
            }, CancellationToken.None);

            await CrudHelper.Save(new Resource
            {
                Type = "blob",
                Import = TestHelper.BuildImport(),
                Properties = new JObject
                {
                    ["containerName"] = "blobTest",
                    ["name"] = "testfile.txt",
                    ["base64Content"] = Convert.ToBase64String(Encoding.UTF8.GetBytes("Extensibility Test!")),
                }
            }, CancellationToken.None);
        }
    }
}