using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using BitVenture.Application.Extensions;
using BitVenture.Application.Models;
using Xunit;

namespace BitVenture.Tests
{
    public class IdentifiersExtensionTest
    {
        [Fact]
        public void ShouldGetValueFromDictionaryUsingKey()
        {
            IEnumerable<Identifier> identifiers = new List<Identifier>() {
                new Identifier { Key = "my.city", Value = "Johannesburg"},
                new Identifier { Key = "my.ip", Value = "105.184.92.37"},
                new Identifier { Key = "director.reference.001", Value = "George Lucas"}
            };
            var value = identifiers.GetValue("my.ip");
            Assert.Matches("105.184.92.37", value);

        }

        [Fact]
        public void ShouldGetValueFromDeserializeServiceWithIdentifiers()
        {
            var json = "{ \"services\": [ { \"baseURL\": \"http\", \"datatype\": \"JSON\", \"enabled\": true, \"endpoints\": [], \"identifiers\": [ { \"key\": \"my.city\", \"value\": \"Johannesburg\" }, { \"key\": \"my.ip\", \"value\": \"105.184.92.37\" } ] } ] }";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var service = JsonSerializer.Deserialize<JsonService>(json, options);
            Assert.True(service.Services.First().Identifiers.Count() > 0);
            var keyValuePairs = service.Services.First().Identifiers;
            var value = keyValuePairs.GetValue("my.city");
            Assert.Matches("Johannesburg", value);
        }
    }
}
