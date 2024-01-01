using StudyCase.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Services
{
    public interface IHttpRequestService
    {
        Task<ApiResponseDto> GetAsync(string uri);
    }
}
