using Users.Common.Models;

namespace Users.Common.Extensions
{
    public static class ResponseExtensions
    {
        public static bool IsSuccessful(this IServiceResponse response)
        {
            return response?.Success ?? false;
        }

        public static bool IsFailed(this IServiceResponse response)
        {
            return !response?.Success ?? true;
        }

        public static bool IsError(this IServiceResponse response)
        {
            return response?.Exception != null;
        }
    }
}
