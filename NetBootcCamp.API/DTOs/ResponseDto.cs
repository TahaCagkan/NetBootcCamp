using System.Text.Json.Serialization;

namespace NetBootcCamp.API.DTOs
{
    public struct NoContent;

    public record ResponseDto<T>
    {
        public T? Data { get; init; }
        [JsonIgnore]
        public bool IsSuccess {  get; init; }
        public List<string>? FailMessages { get; init; }
        //static factory methods
        public static ResponseDto<T> Success(T data)
        {
            return new ResponseDto<T> 
            { 
                Data = data,
                IsSuccess = true,                
            };
        }
        public static ResponseDto<T> Success()
        {
            return new ResponseDto<T>
            {
                IsSuccess = true
            };
        }
        public static ResponseDto<T> Fail(List<string> messages)
        {
            return new ResponseDto<T>
            {
                IsSuccess = false,
                FailMessages = messages
            };
        }

        public static ResponseDto<T> Fail(string messages)
        {
            return new ResponseDto<T>
            {
                IsSuccess = false,
                FailMessages = new List<string> { messages }
            };
        }
    }
}
