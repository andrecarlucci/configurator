using System;

namespace Configurator
{
    public class ConfigurationValueNotFoundException : Exception
    {
        public ConfigurationValueNotFoundException(string key)
            : base("The key '{0}' has no value and is required.".FormatWith(key)) {}
    }
}