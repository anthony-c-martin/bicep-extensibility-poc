namespace Extensibility.Core.Models
{
    using Newtonsoft.Json.Linq;

    public class Import
    {
        public string? Provider { get; set; }

        public string? Version { get; set; }

        public JObject? Config { get; set; }
    }
}