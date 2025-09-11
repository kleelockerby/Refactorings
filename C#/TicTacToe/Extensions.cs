using System.Reflection;

namespace TicTacToe 
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

        public static IEnumerable<Type> FindSubClasses(this Type baseType)
        {
            Assembly assembly = baseType.Assembly;
            return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            if (dictionary.TryGetValue(key, out TValue value))
            {
                return value;
            }
            return defaultValue;
        }
    }
}
