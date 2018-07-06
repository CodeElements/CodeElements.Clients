using System.Net.Http;
using System.Threading.Tasks;

namespace YourRootNamespace.Clients
{
    public interface IRestClient
    {
        Task<HttpResponseMessage> SendMessage(HttpRequestMessage request);
    }
}