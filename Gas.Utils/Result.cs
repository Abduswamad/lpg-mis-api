
using Gas.Utils.Interface;

namespace Gas.Utils
{
    public class Result<T> : IResult<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
        public bool Succeeded { get; set; }

        #region Non Async Methods 

        #region Success Methods 

        public static Result<T> Success()
        {
            return new Result<T> 
            { 
                Succeeded = true,
                Code = 200
            };
        }

        public static Result<T> Success(string message)
        {
            return new Result<T> 
            {
                Succeeded = true,
                Message =  message ,
                Code = 200
            };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Succeeded = true,
                Message = "Successful",
                Data = data,
                Code = 200
            };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T>
            {
                Succeeded = true,
                Message =  message ,
                Data = data,
                Code = 200
            };
        }

        #endregion

        #region Failure Methods 

        public static Result<T> Failure()
        {
            return new Result<T>
            {
                Succeeded = false,
                Code = 100
            };
        }
        public static Result<T> Failure(string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Message = message,
                Code = 100
            };
        }
        public static Result<T> Failure(string message, int code)
        {
            return new Result<T>
            {
                Succeeded = false,
                Message =  message ,
                Code = code
            };
        }

        public static Result<T> Failure(T data)
        {
            return new Result<T>
            {
                Succeeded = false,
                Message = "Failed",
                Data = data,
                Code = 100
            };
        }

        public static Result<T> Failure(T data, string message)
        {
            return new Result<T>
            {
                Succeeded = false,
                Message =  message,
                Data = data,
                Code = 100
            };
        }

        public static Result<T> Failure(T data, string message,int code)
        {
            return new Result<T>
            {
                Succeeded = false,
                Message = message,
                Data = data,
                Code = code
            };
        }

        public static Result<T> Failure(Exception exception)
        {
            return new Result<T>
            {
                Succeeded = false,
                Message =  exception.Message,
                Code = 100
            };
        }

        #endregion

        #endregion

        #region Async Methods 

        #region Success Methods 

        public static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        #endregion

        #region Failure Methods 

        public static Task<Result<T>> FailureAsync()
        {
            return Task.FromResult(Failure());
        }
        public static Task<Result<T>> FailureAsync(string message)
        {
            return Task.FromResult(Failure(message));
        }

        public static Task<Result<T>> FailureAsync(string message, int code)
        {
            return Task.FromResult(Failure(message, code));
        }

        public static Task<Result<T>> FailureAsync(T data)
        {
            return Task.FromResult(Failure(data));
        }

        public static Task<Result<T>> FailureAsync(T data, string message, int code)
        {
            return Task.FromResult(Failure(data, message, code));
        }

        public static Task<Result<T>> FailureAsync(Exception exception)
        {
            return Task.FromResult(Failure(exception));
        }

        #endregion

        #endregion
    }

}
