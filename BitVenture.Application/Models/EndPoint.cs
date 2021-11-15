using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitVenture.Application.Models
{
    public class EndPoint
    {
        public string Resource { get; set; }
        public bool Enabled { get; set; }
        public ICollection<Response> Response { get; set; }

        public EndPoint()
        {
            Response = new List<Response>();
        }
    }
}
