using StudyCase.Application.Dto;
using StudyCase.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Infrastructure.Services
{
    public class GetDataProxy
    {
        private readonly int bufferSize;
        private readonly List<ApiResponseDto> responses;

        public Task<ApiResponseDto> Parse(string uri)
        {
            if(responses.Count == bufferSize)
            {
                foreach (var item in responses)
                {
                    
                }
            }

            return null;
        }
    }
}
