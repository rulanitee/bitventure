using System.Collections.Generic;
using System.Linq;
using BitVenture.Application.Extensions;
using BitVenture.Application.Handlers;
using BitVenture.Application.Models;

namespace BitVenture.Application.Services
{
    public class ResponseProcessorService : IResponseProcessorService
    {
        private readonly IEnumerable<IResponseHandler> _handlers;
        public ResponseProcessorService(IEnumerable<IResponseHandler> handlers)
        {
            _handlers = handlers;
        }
        public void Process(Service service, string response, EndPoint endPoint)
        {
            IResponseHandler handler = _handlers.Where(x => service.DataType.Equals(x.GetType().GetAttributeValue((HandlerTypeAttribute h) => h.TypeOfHandler.ToString()))).FirstOrDefault();
            if (handler == null) 
            {
                throw new System.ApplicationException($"Couldn't find handler for {service.DataType}");
            }
            handler.Handle(response, endPoint, service.Identifiers);
        }
    }
}
