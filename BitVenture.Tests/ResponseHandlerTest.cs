using System.Collections.Generic;
using System.Linq;
using BitVenture.Application.Services;
using BitVenture.Application.Extensions;
using Xunit;
using BitVenture.Application.Handlers;

namespace BitVenture.Tests
{
    public class ResponseHandlerTest
    {

        private readonly List<IResponseHandler> _handlers = new()
        {
            new JsonResponseHandler(),
            new XmlResponseHandler()
        };

        [Fact]
        public void ShouldMatchResponseHandlerByAttribute()
        {
            var dataType = HandlerType.JSON.ToString();
            var handler = _handlers.Where(x => dataType.Equals(x.GetType().GetAttributeValue((HandlerTypeAttribute h) => h.TypeOfHandler.ToString()))).FirstOrDefault();
            Assert.Matches("JsonResponseHandler", handler.GetType().Name);
        }
    }
}
