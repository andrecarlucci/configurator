using System;
using NUnit.Framework;
using Should;

namespace Configurator.Tests
{
    public class GetOrDefaultTests : BaseTest
    {
        private IConfigurator _configurator;

        [SetUp]
        public void Setup()
        {
            _configurator = new Configurator();
        }

        [Test]
        public void Should_Get_Int()
        {
            _configurator.GetOrDefault<int>("test-int").ShouldEqual(5);
        }

        [Test]
        public void Should_Get_DateTime()
        {
            _configurator
                .GetOrDefault<DateTime>("test-datetime")
                .ShouldEqual(new DateTime(2013, 1, 1));
        }

        [Test]
        public void Should_Get_String()
        {
            _configurator
                .GetOrDefault<string>("test-string")
                .ShouldEqual("test");
        }

        [Test]
        public void Should_Get_Decimal()
        {
            _configurator
                .GetOrDefault<decimal>("test-decimal")
                .ShouldEqual(9.5m);
        }

        [Test]
        public void Should_Get_Boolean()
        {
            _configurator
                .GetOrDefault<bool>("test-bool")
                .ShouldEqual(true);
        }

        [Test]
        public void Should_Throw_Int()
        {
            _configurator
                .GetOrDefault("test-empty", 0)
                .ShouldEqual(0);
        }

        [Test]
        public void Should_Throw_DateTime()
        {
            _configurator
                .GetOrDefault("test-empty", new DateTime(2013, 1, 1))
                .ShouldEqual(new DateTime(2013, 1, 1));
        }

        [Test]
        public void Should_Throw_String()
        {
            _configurator
                .GetOrDefault("test-empty", "test")
                .ShouldEqual("test");
        }

        [Test]
        public void Should_Throw_Decimal()
        {
            _configurator
                .GetOrDefault("test-empty", 9.5m)
                .ShouldEqual(9.5m);
        }

        [Test]
        public void Should_Throw_Boolean()
        {
            _configurator
                .GetOrDefault("test-empty", true)
                .ShouldEqual(true);
        }
    }
}