using System;

namespace Common.Common
{
    public interface IActionResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }

        Tuple<string, object>[] Parameters { get; }
    }

    public interface IActionResult<T> : IActionResult
    {
        T Data { get; }
    }
}
