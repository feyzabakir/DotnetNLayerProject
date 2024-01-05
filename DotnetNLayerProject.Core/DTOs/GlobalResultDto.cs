using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotnetNLayerProject.Core.DTOs
{
    public class GlobalResultDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public static GlobalResultDto<T> Success(int statusCode, T data)
        {
            return new GlobalResultDto<T> { Data = data, StatusCode = statusCode };
        }

        public static GlobalResultDto<T> Success(int statusCode)  //Data göndermek istemezsek
        {
            return new GlobalResultDto<T> { StatusCode = statusCode };
        }

        public static GlobalResultDto<T> Fail(int statusCode, List<string> errors)
        {
            return new GlobalResultDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static GlobalResultDto<T> Fail(int statusCode, string error)
        {
            return new GlobalResultDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
