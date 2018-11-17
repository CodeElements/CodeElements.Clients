using System.Collections.Specialized;
using System.Net.Http;

namespace YourRootNamespace.Clients.Helpers
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    interface IRequestBuilder
    {
        HttpRequestMessage Message { get; }
        NameValueCollection Query { get; }

        HttpRequestMessage Build();
    }
}