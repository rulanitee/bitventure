using System.Net.Http;
using System.Threading.Tasks;

namespace BitVenture.Application.Services
{
    public class EndPointCallService : IEndPointCallService
    {
        public async Task<string> Call(string endPoint)
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(endPoint);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
