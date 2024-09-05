namespace Ecount.Kjd.Project.CSharp
{
    public class ApiUtils
    {
        public static ApiResult<T> Success<T>(T response)
        {
            return new ApiResult<T>(true, response, null);
        }

        public static ApiResult<object> Error(string message, int status)
        {
            return new ApiResult<object>(false, null, new ApiError(status, message));
        }

        public static ApiResult<object> Error(BaseException exception)
        {
            return new ApiResult<object>(false, null, new ApiError(exception.Status, exception.Message));
        }

        public class ApiResult<T>
        {
            public bool success { get; }
            public T response { get; }
            public ApiError error { get; }

            public ApiResult(bool success, T response, ApiError error)
            {
                this.success = success;
                this.response = response;
                this.error = error;
            }
        }

        public class ApiError
        {
            public int status { get; }
            public string message { get; }

            public ApiError(int status, string message)
            {
                this.status = status;
                this.message = message;
            }
        }
    }
}