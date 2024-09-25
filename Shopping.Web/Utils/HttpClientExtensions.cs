using System.Net.Http.Headers;
using System.Text.Json;

namespace Shopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode) 
            {
                throw new ArgumentException("Something went wrong calling the API:" + $"{responseMessage.ReasonPhrase}");
            }
            var dataAsString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
        }
        public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T Data)
        {
            var dataAsString = JsonSerializer.Serialize(Data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return await httpClient.PostAsync(url, content);
        }        
        public static async Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T Data)
        {
            var dataAsString = JsonSerializer.Serialize(Data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return await httpClient.PutAsync(url, content);
        }
    }
}
