using Microsoft.AspNetCore.Server.HttpSys;
using System.Net;
using System.Text.Json.Serialization;

namespace YMYPHybritSampleProject.Model.Services
{
    public class ServiceResult<T>
    {
      public T? Data { get; set; }

      public List <string> Errors { get; set; }


        [JsonIgnore] public HttpStatusCode Status {  get; set; }

        [JsonIgnore] public bool Issucces =>Errors is null || Errors?.Count == 0;

        [JsonIgnore] public bool IsFail => !Issucces;


        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T> { Data = data, Status = status };



        }

        public static ServiceResult<T> Failure(List<string> errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Errors = errors, Status = status };
        }

        public static ServiceResult<T> Failure(string errror, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Errors = [errror], Status = status };
        }

    }
    public class ServiceResult
    {
        public List<string>? Errors { get; set; }

        [JsonIgnore] public bool IsSuccess => Errors is null || Errors?.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult { Status = status };
        }

        public static ServiceResult Failure(List<string>errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        { return new ServiceResult { Errors = errors,Status=status};
        }

        public static ServiceResult Failure (string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                Errors = [error],
                Status = status
            };
        }
    }
}
