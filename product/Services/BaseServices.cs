using Newtonsoft.Json;
using product.Models;
using product.Services.IServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace product.Services
{
    public class BaseServices : IBaseServices
    {
        private readonly DBp db;
        private readonly ResponseDto responseDto;
        private readonly IHttpClientFactory httpClientFactory;
        public BaseServices(DBp dB, IHttpClientFactory httpClientFactory)
        {
            db = dB;
            responseDto = new ResponseDto();
            this.httpClientFactory = httpClientFactory;

        }

        public async Task<ResponseDto> result(requestdto requestdto)
        {
            HttpClient httpClient = httpClientFactory.CreateClient("product");//ساخت client مجازی
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            if (requestdto != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestdto.data), Encoding.UTF8, "application/json");
            }
            message.RequestUri = new Uri(requestdto.url);// به کدام url ارسال میشود
            switch (requestdto.httpmetod)//request از چه نوعی است
            {
                case 1:
                    message.Method = HttpMethod.Post;
                    break;
                case 2:
                    message.Method = HttpMethod.Get;
                    break;
                case 3:
                    message.Method = HttpMethod.Put;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }
            HttpResponseMessage? responsem = null;
            responsem = await httpClient.SendAsync(message);
            switch (responsem.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    return new ResponseDto() { issucses = false, data = null, message = "Unauthorized" };

                    break;
                case System.Net.HttpStatusCode.NotFound:
                    return new ResponseDto() { issucses = false, data = null, message = "NotFound" };

                    break;
                case System.Net.HttpStatusCode.BadRequest:
                    return new ResponseDto() { issucses = false, data = null, message = "BadRequest" };

                    break;

                default:
                    var apicontent = await responsem.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<ResponseDto>(apicontent);

                    return response;
                    break;

            }
        }
    }
}
