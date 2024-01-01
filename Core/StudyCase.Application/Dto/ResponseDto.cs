using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudyCase.Application.Dto
{
    public class ResponseDto<T> where T : class
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        [JsonIgnore]
        public List<string> Errors { get; set; }
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new() { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new() { Data = default(T), StatusCode = statusCode, IsSuccessful = true };
        }

        public static ResponseDto<T> Fail(List<string> erors, int statusCode)
        {
            return new()
            {
                Errors = erors,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new()
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
