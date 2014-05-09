using System;

namespace Configurator
{
    public interface IConfigurator
    {
        char ArraySeparator { get; set; }
        T Get<T>(string key, bool required = false);
        object Get(Type type, string key, bool required = false);
        T GetOrDefault<T>(string key, T defaultValue = default(T));
        string GetConnectionString(string name);
    }
}