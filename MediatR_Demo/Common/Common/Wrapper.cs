using System;
using System.Threading.Tasks;

namespace Common.Common
{
    public class Wrapper : IWrapper
    {
        public async Task<T> Wrap<T>(Func<Task<T>> func)
        {
            Console.WriteLine("Before WrapFunction");
            return await func();
        }
    }
}
