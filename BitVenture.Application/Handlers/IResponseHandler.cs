using System.Collections.Generic;
using BitVenture.Application.Models;

namespace BitVenture.Application.Services
{
    public interface IResponseHandler
    {
        void Handle(string response, EndPoint endPoint, IEnumerable<Identifier> identifiers);
    }
}
