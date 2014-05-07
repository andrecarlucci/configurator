using System;
using NUnit.Framework;

namespace Configurator.Tests
{
    public class GetRequiredTests : BaseTest
    {
        private IConfigurator _configurator;

        [SetUp]
        public void Setup()
        {
            _configurator = new Configurator();
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_Int()
        {
            _configurator.Get<int>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_DateTime()
        {
            _configurator.Get<DateTime>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_String()
        {
            _configurator.Get<string>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_Decimal()
        {
            _configurator.Get<decimal>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_Boolean()
        {
            _configurator.Get<bool>("test-empty", true);
        }
    }
}