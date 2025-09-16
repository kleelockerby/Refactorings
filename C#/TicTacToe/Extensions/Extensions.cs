using System.Reflection;

namespace TicTacToe.Extensions 
{
    public static class Extensions
    {
        public static bool IsValidInteger(this string? input, out int index)
        {
            if (int.TryParse(input, out index))
            {
                return true;
            }
            index = -1;
            return false;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
        {
            if (dictionary.TryGetValue(key, out TValue value))
            {
                return value;
            }
            return defaultValue;
        }

        public static TReturn CallPrivateMethod<TReturn>(this object obj, string methodName, params object?[] parameters)
        {
            var type = obj.GetType();
            var method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance)
                         ?? throw new MissingMethodException($"Method '{methodName}' not found in type '{type.FullName}'.");

            var result = method.Invoke(obj, parameters);
            return (TReturn)result!;
        }
    }
}
