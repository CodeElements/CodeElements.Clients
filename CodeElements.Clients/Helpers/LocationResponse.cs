using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace YourRootNamespace.Clients.Helpers
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    static class LocationResponse
    {
        public static async Task<T> CreateFromLocationId<T>(this Task<HttpResponseMessage> task, Func<int, T> createObj)
        {
            var response = await task;
            var location = response.Headers.Location;
            return createObj(int.Parse(location.Segments.Last()));
        }
    }
}