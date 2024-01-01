using StudyCase.UI.Models;

namespace StudyCase.UI.Services.Abstracts
{
    public interface IHttpRequestService
    {
        Task<ApiResponseDto> GetAsync(string uri);
    }
}
