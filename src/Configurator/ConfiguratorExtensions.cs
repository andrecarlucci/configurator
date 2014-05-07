using System;
using System.Configuration;
using System.Linq;

namespace Configurator
{
    public static class ConfiguratorExtensions
    {
        public static T Map<T>(this IConfigurator configurator, bool required = false) where T : class
        {
            var obj = Activator.CreateInstance<T>();
            var allKeys = ConfigurationManager.AppSettings.AllKeys.ToDictionary(k => k.ToLower(), v => v);
            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                var propertyName = propertyInfo.Name.ToLower();
                if (!allKeys.ContainsKey(propertyName))
                {
                    throw new ConfigurationKeyNotFoundException(propertyName);
                }
                var config = allKeys[propertyName];
                var type = propertyInfo.PropertyType;
                var @value = configurator.Get(type, config, required);
                propertyInfo.SetValue(obj, @value);
            }
            return obj;
        }
    }
}