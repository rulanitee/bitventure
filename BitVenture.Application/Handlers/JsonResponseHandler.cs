using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BitVenture.Application.Extensions;
using BitVenture.Application.Handlers;
using BitVenture.Application.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitVenture.Application.Services
{
    [HandlerType(HandlerType.JSON)]
    public class JsonResponseHandler : IResponseHandler
    {
        public void Handle(string response, EndPoint endPoint, IEnumerable<Identifier> identifiers) 
        {
            var jsonResponse = JsonConvert.DeserializeObject<JObject>(response);

            foreach (var endPointResponse in endPoint.Response)
            {
                var value = jsonResponse.SelectToken($"{endPointResponse.Element}")?.ToString();

                if (string.IsNullOrEmpty(value))
                {
                    value = jsonResponse.SelectToken($"contents.{endPointResponse.Element}").ToString();
                }

                var pattern = !string.IsNullOrEmpty(endPointResponse.Regex) ?
                    endPointResponse.Regex :
                    identifiers == null ? endPointResponse.Identifier : identifiers.GetValue(endPointResponse.Identifier);

                var reg = new Regex($@"{pattern}");

                if (reg.Match(value).Success)
                {
                    Console.WriteLine($"Expected response: {pattern} and actual response: {value}, match");
                }

            }
            
        }
    }
}
