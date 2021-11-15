using System.Linq;
using System.Text.Json;
using BitVenture.Application.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace BitVenture.Tests
{
    public class DynamicDeserializeObjectTest
    {
        [Fact]
        public void ShouldDeserializeJsonToDynamicObject() 
        {
            var token = "hair_color";
            var response = "{name: \"Tendai\", hair_color: \"black\"}";
            var dynObj = JsonConvert.DeserializeObject<JObject>(response);
            var element = dynObj.SelectToken($"{token}").ToString();
            Assert.Equal("black", element);
        }

        [Fact]
        public void ShouldDeserializeJsonWithNestedValueToDynamicObject()
        {
            var childToken = "translation";
            var response = "{name: \"Tendai\", hair_color: \"black\", contents: {name: \"Foo\", translation: \"froodo\"}}";
            var dynObj = JsonConvert.DeserializeObject<JObject>(response);
            var element = dynObj.SelectToken($"contents.{childToken}").ToString();
            Assert.Equal("froodo", element);
        }

        [Fact]
        public void ShouldDeserializeServiceWithIdentifiers()
        {
            var json = "{ \"services\": [ { \"baseURL\": \"http\", \"datatype\": \"JSON\", \"enabled\": true, \"endpoints\": [], \"identifiers\": [ { \"key\": \"my.ip\", \"value\": \"105.184.92.37\" } ] } ] }";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var service = System.Text.Json.JsonSerializer.Deserialize<JsonService>(json, options);
            Assert.True(service.Services.First().Identifiers.Count() > 0);
        }
    }
}
