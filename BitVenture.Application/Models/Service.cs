using System.Collections.Generic;
using BitVenture.Application.Handlers;

namespace BitVenture.Application.Models
{
    public class Service
    {
        public string BaseUrl { get; set; }
        public string DataType { get; set; } = HandlerType.JSON.ToString(); // Default value is going to be Json
        public bool Enabled { get; set; }
        public ICollection<EndPoint> EndPoints { get; set; }
        public ICollection<Identifier> Identifiers { get; set; }
        public Service()
        {
            EndPoints = new List<EndPoint>();
            
        }
    }
}
