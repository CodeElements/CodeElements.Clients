using System;
using System.Net.Http;
using YourRootNamespace.Clients.Helpers;

namespace YourRootNamespace.Clients.Extensions
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    static class HttpVerbExtensions
    {
        public static HttpMethod ToMethod(this HttpVerb verb)
        {
            switch (verb)
            {
                case HttpVerb.Get:
                    return HttpMethod.Get;
                case HttpVerb.Post:
                    return HttpMethod.Post;
                case HttpVerb.Put:
                    return HttpMethod.Put;
                case HttpVerb.Delete:
                    return HttpMethod.Delete;
                case HttpVerb.Patch:
                    return new HttpMethod("PATCH");
                default:
                    throw new ArgumentOutOfRangeException(nameof(verb), verb, null);
            }
        }
    }
}