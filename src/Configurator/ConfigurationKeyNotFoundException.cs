using System;

namespace Configurator
{
    public class ConfigurationKeyNotFoundException : Exception
    {
        public ConfigurationKeyNotFoundException(string key)
            : base("The key '{0}' was not found.".FormatWith(key)) {}
    }
}