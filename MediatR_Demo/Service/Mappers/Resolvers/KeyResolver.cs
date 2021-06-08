using AutoMapper;
using System;
namespace Service.Mappers.Resolvers
{
    public class KeyResolver<TKey> : IValueResolver<object, object, TKey>
    {
        private readonly string _key;

        public KeyResolver(string key)
        {
            _key = key;
        }

        public TKey Resolve(object source, object destination, TKey destMember, ResolutionContext context)
        {
            if (context.Items.ContainsKey(_key) && context.Items[_key] != null)
            {
                if (typeof(TKey).IsAssignableFrom(context.Items[_key].GetType()))
                {
                    return (TKey)context.Items[_key];
                }
                else
                {
                    throw new Exception(
                        $"Type of Key [{_key}] is invalid. Actual Type : [{context.Items[_key].GetType().Name}]. Expected Type : [{typeof(TKey).Name}].");
                }
            }
            return default;
        }
    }
}
