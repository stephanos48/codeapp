using Microsoft.AspNetCore.Http;

namespace codeapp.API.Helpers
{
    public static class Extensions
    {
        
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Accesss-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}