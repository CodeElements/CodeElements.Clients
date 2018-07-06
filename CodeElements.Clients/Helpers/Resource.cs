using System.Net.Http;
using YourRootNamespace.Clients.Extensions;

namespace YourRootNamespace.Clients.Helpers
{
    public abstract class Resource<TResource> : IResourceId where TResource : IResourceId, new()
    {
        public abstract string ResourceUri { get; }

        protected static string CombineUrlWithResource(string url, string resource)
        {
            if (resource == null)
                return url;
            return url + "/" + resource;
        }

        protected static RequestBuilder CreateRequest(HttpVerb verb = HttpVerb.Get, object resource = null,
            object content = null) =>
            CreateRequest(verb, resource, content == null ? null : new JsonContent(content));

        protected static RequestBuilder CreateRequest(HttpVerb verb, object resource, HttpContent content) =>
            new RequestBuilder(CombineUrlWithResource(new TResource().ResourceUri, resource?.ToString()))
            {
                Content = content,
                HttpMethod = verb.ToMethod()
            };
    }
}