using System;
using System.IO;
using System.Text.Json;
using BitVenture.Application.Models;
using BitVenture.Application.Services;

namespace BitVenture.Application
{
    public class JsonFileProcessor : IJsonFileProcessor
    {

        private readonly IEndPointCallService _endPointCall;
        private readonly IResponseProcessorService _responseProcessorService;
        public JsonFileProcessor(IEndPointCallService endPointCall, IResponseProcessorService responseProcessorService)
        {
            _endPointCall = endPointCall;
            _responseProcessorService = responseProcessorService;
        }
        public void Process(string path)
        {

            string jsonServices = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var service = JsonSerializer.Deserialize<JsonService>(jsonServices, options);

            Console.WriteLine("Processing service endpoints ...");

            foreach (var item in service.Services)
            {
                foreach (var endPoint in item.EndPoints)
                {                    
                    var response = _endPointCall.Call($"{item.BaseUrl}{endPoint.Resource}").GetAwaiter().GetResult();
                    _responseProcessorService.Process(item, response, endPoint);
                }
            }
            
        }
    }
}
