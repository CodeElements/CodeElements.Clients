using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;

namespace YourRootNamespace.Clients.Helpers
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    class RequestBuilder : IRequestBuilder
    {
        public RequestBuilder(string baseUrl)
        {
            Message = new HttpRequestMessage();
            Query = new NameValueCollection();
            BaseUrl = baseUrl;
        }

        public HttpRequestMessage Message { get; }
        public string BaseUrl { get; }
        public NameValueCollection Query { get; }

        public HttpRequestMessage Build()
        {
            var url = BaseUrl;
            if (Query.Count > 0)
                url += "?" + string.Join("&",
                           Query.Cast<string>().Select(x =>
                               string.Concat(Uri.EscapeDataString(x), "=", Uri.EscapeDataString(Query[x]))));

            Message.RequestUri = new Uri(url, UriKind.Relative);

            return Message;
        }
    }
}