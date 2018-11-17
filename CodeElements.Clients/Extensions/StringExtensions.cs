namespace YourRootNamespace.Clients.Extensions
{
#if CLIENTS_INTERNAL
    internal
#else
    public
#endif
    static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
    }
}