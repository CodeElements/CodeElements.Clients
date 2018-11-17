namespace YourRootNamespace.Clients.Helpers
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    enum HttpVerb
    {
        Get,
        Post,
        Put,
        Delete,
        Patch
    }
}