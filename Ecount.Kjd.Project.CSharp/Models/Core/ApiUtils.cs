using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class ApiUtils
    {

        public static ApiResult<T> Success<T>(T response)
        {
            return new ApiResult<T>(true, response, null);
        }

        public static ApiResult<object> Error(string message, HttpStatusCode status)
        {
            return new ApiResult<object>(false, null, new ApiError(status.value(), message));
        }

        public static ApiResult<object> Error(BaseException exception)
        {
            return new ApiResult<>(false, null, new ApiError(exception.getCode(), exception.getMessage()));
        }

        public class ApiResult<T>
        {
            public bool Success { get; }
            public T Response { get; }
            public ApiError Error { get; }

            public ApiResult(bool success, T response, ApiError error)
            {
                Success = success;
                Response = response;
                Error = error;
            }
        }

        public class ApiError
        {
            public int Status { get; }
            public string Message { get; }

            public ApiError(int status, string message)
            {
                Status = status;
                Message = message;
            }
        }
    }
}