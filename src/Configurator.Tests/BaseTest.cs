using NUnit.Framework;

namespace Configurator.Tests
{
    [SetCulture("en-US")]
    [SetUICulture("en-US")]
    public abstract class BaseTest
    {
        protected IConfigurator Configurator { get; set; }

        [SetUp]
        public void Setup() {
            Configurator = new Configurator();
        }
    }
}