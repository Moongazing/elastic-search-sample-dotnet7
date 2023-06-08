using System.Net;

namespace TunahanAliOzturk.ElasticSearch.API.DTOs
{
    public record ResponseDto<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public static ResponseDto<T> Success(T data, HttpStatusCode code)
        {
            return new ResponseDto<T>
            {
                Data = data,
                StatusCode = code
            };
        }
        public static ResponseDto<T> Fail(List<string> errors, HttpStatusCode code)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = code
            };
        }

    }
}
