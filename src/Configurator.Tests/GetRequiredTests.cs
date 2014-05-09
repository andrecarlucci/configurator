using System;
using NUnit.Framework;

namespace Configurator.Tests
{
    public class GetRequiredTests : BaseTest
    {
        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_Int()
        {
            Configurator.Get<int>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_DateTime()
        {
            Configurator.Get<DateTime>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_String()
        {
            Configurator.Get<string>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_Decimal()
        {
            Configurator.Get<decimal>("test-empty", true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Should_Throw_Boolean()
        {
            Configurator.Get<bool>("test-empty", true);
        }
    }
}