using StudyCase.UI.Models;
using StudyCase.UI.Services.Abstracts;

namespace StudyCase.UI.Services.Concretes
{
    public class HttpRequestService : IHttpRequestService
    {
        public async Task<ApiResponseDto> GetAsync(string uri)
        {
            HttpClient client = new HttpClient();

            var stringResponse = await client.GetAsync(uri);
            var type = stringResponse.Content.Headers.ContentType.MediaType;
            ApiResponseDto responseDto = new()
            {

                ResponseValue = await stringResponse.Content.ReadAsStringAsync(),
                ContentType = type
            };

            return responseDto;
        }
    }
}
