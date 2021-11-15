using BitVenture.Application.Models;

namespace BitVenture.Application.Services
{
    public interface IResponseProcessorService
    {
        void Process(Service service, string response, EndPoint endPoint);
    }
}
