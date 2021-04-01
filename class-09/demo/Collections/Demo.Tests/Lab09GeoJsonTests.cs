using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xunit;

namespace Demo.Tests
{
    public class Lab09GeoJsonTests
    {
        [Fact]
        public void Can_read_JSON_from_file()
        {
            // Arrange
            string filename = "data.json";
            string data = File.ReadAllText(filename);
            Assert.NotEmpty(data);

            // Assert
            RootObject root = JsonConvert.DeserializeObject<RootObject>(data);
        }

    }

    class RootObject
    {
        public string type { get; set; }

        public List<Feature> features { get; set; }
    }

    class Feature
    {
        public string type { get; set; }

        // TODO: geomertries, properties
    }
}
