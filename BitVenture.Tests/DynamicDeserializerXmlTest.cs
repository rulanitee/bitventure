using System.Xml;
using Xunit;

namespace BitVenture.Tests
{
    public class DynamicDeserializerXmlTest
    {
        [Fact]
        public void ShouldDeserializeXmlToDynamicObject()
        {
            var xml = @"<?xml version=""1.0"" encoding=""UTF - 8""?>
                            <geoPlugin>
                                <geoplugin_request>105.184.92.37</geoplugin_request>     
                                <geoplugin_status>200</geoplugin_status>     
                                <geoplugin_delay>2ms</geoplugin_delay>
                                <geoplugin_city>Johannesburg</geoplugin_city>
                            </geoPlugin>";
            XmlDocument xmlObject = new();
            xmlObject.LoadXml(xml);
            var value = xmlObject.DocumentElement.SelectSingleNode("geoplugin_city").InnerText;
            Assert.Equal("Johannesburg", value);
        }
    }
}
