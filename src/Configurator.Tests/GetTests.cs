using System;
using NUnit.Framework;
using Should;

namespace Configurator.Tests
{
    [SetCulture("en-US")]
    [SetUICulture("en-US")]
    public class GetTests
    {
        private IConfigurator _configurator;

        [SetUp]
        public void Setup()
        {
            _configurator = new Configurator();
        }

        [Test]
        [ExpectedException(typeof (ConfigurationKeyNotFoundException))]
        public void Should_Validate_Key()
        {
            _configurator.Get<int>("test-int2");
        }

        [Test]
        [ExpectedException(typeof (ConnectionStringNotFoundException))]
        public void Should_Validate_ConnectionString()
        {
            _configurator.GetConnectionString("connection-nope");
        }

        [Test]
        public void Should_Get_ConnectionString()
        {
            _configurator
                .GetConnectionString("connection")
                .ShouldEqual("connection-string");
        }

        [Test]
        public void Should_Get_Int()
        {
            _configurator
                .Get<int>("test-int")
                .ShouldEqual(5);
        }

        [Test]
        public void Should_Get_DateTime()
        {
            _configurator
                .Get<DateTime>("test-datetime")
                .ShouldEqual(new DateTime(2013, 1, 1));
        }

        [Test]
        public void Should_Get_String()
        {
            _configurator
                .Get<string>("test-string")
                .ShouldEqual("test");
        }

        [Test]
        public void Should_Get_Decimal()
        {
            _configurator
                .Get<decimal>("test-decimal")
                .ShouldEqual(9.5m);
        }

        [Test]
        public void Should_Get_Boolean()
        {
            _configurator
                .Get<bool>("test-bool")
                .ShouldEqual(true);
        }
    }
}