using System;
using System.Collections;
using System.Configuration;
using System.Linq;

namespace Configurator
{
    public class Configurator : IConfigurator
    {
        public static char DefaultArraySeparator = ',';

        public char ArraySeparator { get; set; }
        public Configurator()
        {
            ArraySeparator = DefaultArraySeparator;
        }
        
        public T Get<T>(string key, bool required = false)
        {
            return (T) Get(typeof (T), key, required);
        }

        public object Get(Type t, string key, bool required = false)
        {
            EnsureKeyExists(key);
            var value = ConfigurationManager.AppSettings[key];
            if (String.IsNullOrEmpty(@value) && required)
            {
                throw new ConfigurationValueNotFoundException(key);
            }
            return t.IsArray ? 
                CreateArrayFromValue(t, value) : 
                Convert.ChangeType(@value, t);
        }

        private Array CreateArrayFromValue(Type t, string value)
        {
            var values = value.Split(ArraySeparator);
            var array = Array.CreateInstance(t.GetElementType(), values.Length);
            for (int i = 0; i < values.Length; i++)
            {
                array.SetValue(Convert.ChangeType(values[i], t.GetElementType()), i);
            }
            return array;
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