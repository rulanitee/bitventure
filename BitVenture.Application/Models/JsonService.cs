using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitVenture.Application.Models
{
    public class JsonService
    {
        public ICollection<Service> Services { get; set; }
        public JsonService()
        {
            Services = new List<Service>();
        }
    }
}
