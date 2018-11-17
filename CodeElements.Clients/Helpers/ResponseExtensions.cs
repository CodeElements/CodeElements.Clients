using System.Net.Http;
using System.Threading.Tasks;

namespace YourRootNamespace.Clients.Helpers
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    static class ResponseExtensions
    {
        public static Task<T> Return<T>(this Task<HttpResponseMessage> response)
        {
            return new ResponseFactory<T>(response).ToResult();
        }

        public static ResponseFactory<T> Wrap<T>(this Task<HttpResponseMessage> response)
        {
            return new ResponseFactory<T>(response);
        }
    }
}