using System.Threading.Tasks;

namespace BitVenture.Application.Services
{
    public interface IEndPointCallService
    {
        Task<string> Call(string endPoint);
    }
}
