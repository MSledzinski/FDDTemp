namespace NotesWebApp.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public static class HttpProxy
    {
        private static readonly HttpClient HttpClient;

        static HttpProxy()
        {
            HttpClient = new HttpClient { BaseAddress = new Uri(Configuration.BackendServiceUri) };
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<TData> Get<TData>(string path) 
        {
            var responseMessage = await HttpClient.GetAsync(path);
            responseMessage.EnsureSuccessStatusCode();

            return await responseMessage.Content.ReadAsAsync<TData>();
        }

        public static async Task<Uri> Post<TData>(TData data, string path)
        {
            var responseMessage = await HttpClient.PostAsJsonAsync(path, data);
            responseMessage.EnsureSuccessStatusCode();

            return responseMessage.Headers.Location;
        }
    }
}