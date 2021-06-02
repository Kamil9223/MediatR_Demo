using System;

namespace Common.Common
{
    /// <summary>
    /// Type of output parameter used by Services implementation.
    /// </summary>
    public class ActionResult : IActionResult
    {
        protected ActionResult(bool isSuccess, string message, params Tuple<string, object>[] parameters)
        {
            IsSuccess = isSuccess;
            ErrorMessage = message;
            Parameters = parameters;
        }

        /// <summary>
        /// Error message that can be send to the Client
        /// </summary>
        public string ErrorMessage { get; }

        public bool IsFailure => IsSuccess == false;
        public bool IsSuccess { get; }
        public Tuple<string, object>[] Parameters { get; }

        public static IActionResult Failure(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult(false, errorMessage, parameters);
        }

        public static IActionResult Success()
        {
            return new ActionResult(true, null, null);
        }

        public static IActionResult Ignore(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult(false, errorMessage, parameters);
        }

        public static IActionResult FailureFrom(IActionResult result)
        {
            return new ActionResult(false, result.ErrorMessage, result.Parameters);
        }
    }

    /// <summary>
    /// Parametrized type of output parameter used by Services implementation.
    /// </summary>
    public class ActionResult<T> : ActionResult, IActionResult<T>
    {
        protected ActionResult(bool isSuccess, string errorMessage, T data, params Tuple<string, object>[] parameters)
            : base(isSuccess, errorMessage, parameters)
        {
            Data = data;
        }

        public T Data { get; }

        public static IActionResult<T> Failure(string errorMessage)
        {
            return new ActionResult<T>(false, errorMessage, default);
        }

        public new static IActionResult<T> Failure(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult<T>(false, errorMessage, default, parameters);
        }

        new public static IActionResult<T> FailureFrom(IActionResult result)
        {
            return new ActionResult<T>(false, result.ErrorMessage, default, result.Parameters);
        }

        public static IActionResult<T> Success(T data)
        {
            return new ActionResult<T>(true, null, data);
        }

        public new static IActionResult<T> Ignore(string errorMessage, params Tuple<string, object>[] parameters)
        {
            return new ActionResult<T>(false, errorMessage, default, parameters);
        }
    }
}
