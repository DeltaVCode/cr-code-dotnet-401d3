using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            // Act
            RootObject root = JsonConvert.DeserializeObject<RootObject>(data);

            JObject.Parse(data);

            // Assert
            Assert.Equal("FeatureCollection", root.type);
            Assert.NotEmpty(root.features);

            int neighborhoodCount = root.features
                .Select(f => f.properties.neighborhood)
                .Distinct()
                .Count();

            Assert.Equal(40, neighborhoodCount);
        }

        [Fact]
        public void Can_read_JSON_from_file_with_JObject()
        {
            // Arrange
            string filename = "data.json";
            string data = File.ReadAllText(filename);
            Assert.NotEmpty(data);

            // Act
            JObject root = JObject.Parse(data);

            // Assert
            Assert.Equal("FeatureCollection", root["type"]);
            Assert.NotEmpty(root["features"]);

            int neighborhoodCount = root["features"]
                .Select(f => f["properties"]["neighborhood"])
                .Distinct()
                .Count();

            Assert.Equal(40, neighborhoodCount);
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

        public Geometry geometry { get; set; }

        public FeatureProperties properties { get; set; }
    }

    public class FeatureProperties
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }

        public double[] coordinates { get; set; }
    }
}
