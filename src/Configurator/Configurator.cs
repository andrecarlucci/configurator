using System;
using System.Configuration;
using System.Linq;

namespace Configurator
{
    public class Configurator : IConfigurator
    {
        public T Get<T>(string key, bool required = false)
        {
            return (T) Get(typeof (T), key, required);
        }

        public object Get(Type t, string key, bool required = false)
        {
            EnsureKeyExists(key);
            var @value = ConfigurationManager.AppSettings[key];
            if (String.IsNullOrEmpty(@value) && required)
            {
                throw new ConfigurationValueNotFoundException(key);
            }
            return Convert.ChangeType(@value, t);
        }

        public T GetOrDefault<T>(string key, T defaultValue = default(T))
        {
            EnsureKeyExists(key);
            var @value = ConfigurationManager.AppSettings[key];
            if (String.IsNullOrEmpty(@value))
            {
                return defaultValue;
            }
            return (T) Convert.ChangeType(@value, typeof (T));
        }

        public string GetConnectionString(string name)
        {
            var connection = ConfigurationManager.ConnectionStrings[name];
            if (connection == null)
            {
                throw new ConnectionStringNotFoundException(name);
            }
            return connection.ConnectionString;
        }

        private void EnsureKeyExists(string key)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                throw new ConfigurationKeyNotFoundException(key);
            }
        }
    }
}