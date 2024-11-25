using Newtonsoft.Json;
using product.Models;
using product.Services.IServices;
using System.Net.Http;

namespace product.Services
{
    public class todosServices : ItodosServices
    {
        private readonly IHttpClientFactory httpClientFactory;

        public todosServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

        }
        public async Task<List<todosdto>> readtodos()
        {
            HttpClient Client = httpClientFactory.CreateClient("todo");//ساخت client مجازی
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri("https://jsonplaceholder.typicode.com/todos");// به کدام url ارسال میشود
            message.Method = HttpMethod.Get;
            HttpResponseMessage? responsem = null;
            responsem = await Client.SendAsync(message);
            switch (responsem.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    return new List<todosdto>() { };

                    break;
                case System.Net.HttpStatusCode.NotFound:
                    return new List<todosdto>() { };

                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    return new List<todosdto>() { };

                    break;

                default:
                    var apicontent = await responsem.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<List<todosdto>>(apicontent);

                    return response;
                    break;

            }
        }
    }
}
