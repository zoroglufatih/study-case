using StudyCase.Application.Dto;
using StudyCase.Application.Services;

namespace StudyCase.Infrastructure.Services
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
