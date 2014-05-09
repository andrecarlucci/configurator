using System;
using NUnit.Framework;
using Should;

namespace Configurator.Tests
{
    public class GetTests : BaseTest
    {
        [Test]
        [ExpectedException(typeof (ConfigurationKeyNotFoundException))]
        public void Should_Validate_Key()
        {
            Configurator.Get<int>("test-int2");
        }

        [Test]
        [ExpectedException(typeof (ConnectionStringNotFoundException))]
        public void Should_Validate_ConnectionString()
        {
            Configurator.GetConnectionString("connection-nope");
        }

        [Test]
        public void Should_Get_ConnectionString()
        {
            Configurator
                .GetConnectionString("connection")
                .ShouldEqual("connection-string");
        }

        [Test]
        public void Should_Get_Int()
        {
            Configurator
                .Get<int>("test-int")
                .ShouldEqual(5);
        }

        [Test]
        public void Should_Get_DateTime()
        {
            Configurator
                .Get<DateTime>("test-datetime")
                .ShouldEqual(new DateTime(2013, 1, 1));
        }

        [Test]
        public void Should_Get_String()
        {
            Configurator
                .Get<string>("test-string")
                .ShouldEqual("test");
        }

        [Test]
        public void Should_Get_Decimal()
        {
            Configurator
                .Get<decimal>("test-decimal")
                .ShouldEqual(9.5m);
        }

        [Test]
        public void Should_Get_Boolean()
        {
            Configurator
                .Get<bool>("test-bool")
                .ShouldEqual(true);
        }

        [Test]
        public void Should_Get_Int_with_type()
        {
            Configurator
                .Get(typeof (int), "test-int")
                .ShouldEqual(5);
        }

        [Test]
        public void Should_Get_DateTime_with_type()
        {
            Configurator
                .Get(typeof (DateTime), "test-datetime")
                .ShouldEqual(new DateTime(2013, 1, 1));
        }

        [Test]
        public void Should_Get_String_with_type()
        {
            Configurator
                .Get(typeof (string), "test-string")
                .ShouldEqual("test");
        }

        [Test]
        public void Should_Get_Decimal_with_type()
        {
            Configurator
                .Get(typeof (decimal), "test-decimal")
                .ShouldEqual(9.5m);
        }

        [Test]
        public void Should_Get_Boolean_with_type()
        {
            Configurator
                .Get(typeof (bool), "test-bool")
                .ShouldEqual(true);
        }
    }
}