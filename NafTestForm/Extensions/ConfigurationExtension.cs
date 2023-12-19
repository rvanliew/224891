using Microsoft.Extensions.Configuration;
using System;

namespace NafTestForm.Extensions
{
    public static class ConfigurationExtension
    {
        public static T GetRequiredValue<T>(this IConfiguration configuration, string key)
        {
            T value = configuration.GetValue<T>(key);

            if (typeof(T) == typeof(string) && (value == null || string.IsNullOrWhiteSpace(value.ToString())))
            {
                throw new InvalidOperationException($"Missing required application setting: {key}");
            }
            if (value.Equals(default(T)))
            {
                throw new InvalidOperationException($"Missing required application setting: {key}");
            }
            return value;
        }
    }
}
