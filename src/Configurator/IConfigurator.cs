namespace Configurator
{
    public interface IConfigurator
    {
        T Get<T>(string key, bool required = false);
        T GetOrDefault<T>(string key, T defaultValue = default(T));
        string GetConnectionString(string name);
    }
}