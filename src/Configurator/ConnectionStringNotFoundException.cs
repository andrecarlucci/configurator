using System;

namespace Configurator
{
    public class ConnectionStringNotFoundException : Exception
    {
        public ConnectionStringNotFoundException(string name)
            : base("The connection string '{0}' was not found.".FormatWith(name)) {}
    }
}