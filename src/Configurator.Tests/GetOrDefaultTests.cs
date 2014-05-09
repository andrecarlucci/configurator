using System;
using NUnit.Framework;
using Should;

namespace Configurator.Tests
{
    public class GetOrDefaultTests : BaseTest
    {
        [Test]
        public void Should_Get_Int()
        {
            Configurator.GetOrDefault<int>("test-int").ShouldEqual(5);
        }

        [Test]
        public void Should_Get_DateTime()
        {
            Configurator
                .GetOrDefault<DateTime>("test-datetime")
                .ShouldEqual(new DateTime(2013, 1, 1));
        }

        [Test]
        public void Should_Get_String()
        {
            Configurator
                .GetOrDefault<string>("test-string")
                .ShouldEqual("test");
        }

        [Test]
        public void Should_Get_Decimal()
        {
            Configurator
                .GetOrDefault<decimal>("test-decimal")
                .ShouldEqual(9.5m);
        }

        [Test]
        public void Should_Get_Boolean()
        {
            Configurator
                .GetOrDefault<bool>("test-bool")
                .ShouldEqual(true);
        }

        [Test]
        public void Should_Throw_Int()
        {
            Configurator
                .GetOrDefault("test-empty", 0)
                .ShouldEqual(0);
        }

        [Test]
        public void Should_Throw_DateTime()
        {
            Configurator
                .GetOrDefault("test-empty", new DateTime(2013, 1, 1))
                .ShouldEqual(new DateTime(2013, 1, 1));
        }

        [Test]
        public void Should_Throw_String()
        {
            Configurator
                .GetOrDefault("test-empty", "test")
                .ShouldEqual("test");
        }

        [Test]
        public void Should_Throw_Decimal()
        {
            Configurator
                .GetOrDefault("test-empty", 9.5m)
                .ShouldEqual(9.5m);
        }

        [Test]
        public void Should_Throw_Boolean()
        {
            Configurator
                .GetOrDefault("test-empty", true)
                .ShouldEqual(true);
        }
    }
}