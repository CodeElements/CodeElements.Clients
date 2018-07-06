using System.Collections.Specialized;
using System.Net.Http;

namespace YourRootNamespace.Clients.Helpers
{
    public interface IRequestBuilder
    {
        HttpMethod HttpMethod { get; set; }
        HttpContent Content { get; set; }
        NameValueCollection Query { get; }

        HttpRequestMessage Build();
    }
}