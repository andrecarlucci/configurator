using System;
using NUnit.Framework;
using Should;

namespace Configurator.Tests
{
    [SetCulture("en-US")]
    [SetUICulture("en-US")]
    public class GetArrayTests
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
            _configurator.Get<int[]>("test-array-int2");
        }

        [Test]
        public void Should_Get_Array_Int()
        {
            CollectionAssert.AreEqual(
                new[] { 1, 2, 3 }, 
                _configurator.Get<int[]>("test-array-int")
            );
        }

        [Test]
        public void Should_Get_Array_DateTime()
        {
            var d1 = new DateTime(2013, 1, 1);
            CollectionAssert.AreEqual(
                new[] { d1, d1, d1 },
                _configurator.Get<DateTime[]>("test-array-datetime")
            );
        }

        [Test]
        public void Should_Get_Array_String()
        {
            CollectionAssert.AreEqual(
                new[] { "test1", "test2", "test3" },
                _configurator.Get<string[]>("test-array-string")
            );
        }

        [Test]
        public void Should_Get_Array_Decimal()
        {
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                _configurator.Get<decimal[]>("test-array-decimal")
            );
        }

        [Test]
        public void Should_Get_Array_Boolean()
        {
            CollectionAssert.AreEqual(
                new[] { true, true, false },
                _configurator.Get<bool[]>("test-array-bool")
            );
        }

        [Test]
        public void Should_Get_Array_Int_with_type()
        {
            CollectionAssert.AreEqual(
               new[] { true, true, false },
               (bool[])_configurator.Get(typeof(bool[]), "test-array-bool")
           );
        }

        [Test]
        public void Should_Get_Array_DateTime_with_type()
        {
            var d1 = new DateTime(2013, 1, 1);
            CollectionAssert.AreEqual(
                new[] { d1, d1, d1 },
                (DateTime[])_configurator.Get(typeof(DateTime[]),"test-array-datetime")
            );
        }

        [Test]
        public void Should_Get_Array_String_with_type()
        {
            CollectionAssert.AreEqual(
                new[] { "test1", "test2", "test3" },
                (String[])_configurator.Get(typeof(String[]),"test-array-string")
            );
        }

        [Test]
        public void Should_Get_Array_Decimal_with_type()
        {
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                (decimal[])_configurator.Get(typeof(decimal[]), "test-array-decimal")
            );
        }

        [Test]
        public void Should_Get_Array_Boolean_with_type()
        {
            CollectionAssert.AreEqual(
                new[] { true, true, false },
                (bool[])_configurator.Get(typeof(bool[]), "test-array-bool")
            );
        }

        [Test]
        public void Should_set_default_array_separator()
        {
            Configurator.DefaultArraySeparator = ';';
            _configurator = new Configurator();
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                _configurator.Get<decimal[]>("test-array-decimal-semicolon")
            );
            Configurator.DefaultArraySeparator = ',';
        }

        [Test]
        public void Should_favor_instance_property_over_default_array_separator() {
            Configurator.DefaultArraySeparator = '|';
            _configurator = new Configurator {ArraySeparator = ';'};
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                _configurator.Get<decimal[]>("test-array-decimal-semicolon")
            );
            Configurator.DefaultArraySeparator = ',';
        }
    }
}