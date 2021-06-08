using System;
using System.Threading.Tasks;

namespace Common.Common
{
    public interface IWrapper
    {
        Task<T> Wrap<T>(Func<Task<T>> func);
    }
}