using System;
using System.Collections.Generic;
using System.Xml;
using BitVenture.Application.Extensions;
using BitVenture.Application.Handlers;
using BitVenture.Application.Models;

namespace BitVenture.Application.Services
{
    [HandlerType(HandlerType.XML)]
    public class XmlResponseHandler : IResponseHandler
    {
        public void Handle(string response, EndPoint endPoint, IEnumerable<Identifier> identifiers) 
        {
            XmlDocument xmlObject = new();
            xmlObject.LoadXml(response);
            foreach (var endPointResponse in endPoint.Response)
            {
                var value = xmlObject.DocumentElement.SelectSingleNode(endPointResponse.Element).InnerText;
                var identifier = identifiers.GetValue(endPointResponse.Identifier);
                if (identifier.Equals(value)) 
                {                    
                    Console.WriteLine($"Expected response: {identifier} and actual response: {value}, match");
                }
                
            }
            
        }
    }
}
