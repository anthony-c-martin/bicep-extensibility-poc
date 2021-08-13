namespace Extensibility.AzureStorage.Tests
{
    using Extensibility.Core.Models;
    using Newtonsoft.Json.Linq;

    public static class TestHelper
    {
        public static Import BuildImport(string connectionString = "UseDevelopmentStorage=true")
        {
            // TODO find a way to persist connection string settings securely, to avoid relying on the storage emulator
            return new Import
            {
                Provider = "AzureStorage",
                Version = "0.1",
                Config = new JObject
                {
                    ["connectionString"] = connectionString,
                },
            };
        }
    }
}
