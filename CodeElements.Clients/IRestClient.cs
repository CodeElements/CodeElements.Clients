using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace YourRootNamespace.Clients
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    interface IRestClient
    {
        Task<HttpResponseMessage> SendMessage(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}