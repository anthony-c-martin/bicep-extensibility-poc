namespace Extensibility.Core.Models
{
    using Newtonsoft.Json.Linq;

    public class Resource
    {
        public string? Type { get; set; }

        public Import? Import { get; set; }

        public JObject? Properties { get; set; }
    }
}