using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Domain.Helpers
{
    public static class CollectionExtensions
    {
        public static bool NotNullOrEmpty<T>(this IEnumerable<T> list)
           => list != null && list.Any();

        public static Dictionary<string,string> ObjectToDictionary(this Object obj) => obj.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(p => p.Name, p => p.GetValue(obj, null)?.ToString() ?? string.Empty);

        public static void SetPropertyValue<T>(this T @this, string propertyName, object value)
        {
            Type type = @this.GetType();
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            property.SetValue(@this, value, null);
        }
    }
}
