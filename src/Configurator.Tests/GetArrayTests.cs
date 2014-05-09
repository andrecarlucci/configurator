using System;
using NUnit.Framework;
using ConfiguratorNamespace = Configurator;

namespace Configurator.Tests
{
    public class GetArrayTests : BaseTest
    {
        [Test]
        [ExpectedException(typeof (ConfigurationKeyNotFoundException))]
        public void Should_Validate_Key()
        {
            Configurator.Get<int[]>("test-array-int2");
        }

        [Test]
        public void Should_Get_Array_Int()
        {
            CollectionAssert.AreEqual(
                new[] { 1, 2, 3 }, 
                Configurator.Get<int[]>("test-array-int")
            );
        }

        [Test]
        public void Should_Get_Array_DateTime()
        {
            var d1 = new DateTime(2013, 1, 1);
            CollectionAssert.AreEqual(
                new[] { d1, d1, d1 },
                Configurator.Get<DateTime[]>("test-array-datetime")
            );
        }

        [Test]
        public void Should_Get_Array_String()
        {
            CollectionAssert.AreEqual(
                new[] { "test1", "test2", "test3" },
                Configurator.Get<string[]>("test-array-string")
            );
        }

        [Test]
        public void Should_Get_Array_Decimal()
        {
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                Configurator.Get<decimal[]>("test-array-decimal")
            );
        }

        [Test]
        public void Should_Get_Array_Boolean()
        {
            CollectionAssert.AreEqual(
                new[] { true, true, false },
                Configurator.Get<bool[]>("test-array-bool")
            );
        }

        [Test]
        public void Should_Get_Array_Int_with_type()
        {
            CollectionAssert.AreEqual(
               new[] { true, true, false },
               (bool[])Configurator.Get(typeof(bool[]), "test-array-bool")
           );
        }

        [Test]
        public void Should_Get_Array_DateTime_with_type()
        {
            var d1 = new DateTime(2013, 1, 1);
            CollectionAssert.AreEqual(
                new[] { d1, d1, d1 },
                (DateTime[])Configurator.Get(typeof(DateTime[]),"test-array-datetime")
            );
        }

        [Test]
        public void Should_Get_Array_String_with_type()
        {
            CollectionAssert.AreEqual(
                new[] { "test1", "test2", "test3" },
                (String[])Configurator.Get(typeof(String[]),"test-array-string")
            );
        }

        [Test]
        public void Should_Get_Array_Decimal_with_type()
        {
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                (decimal[])Configurator.Get(typeof(decimal[]), "test-array-decimal")
            );
        }

        [Test]
        public void Should_Get_Array_Boolean_with_type()
        {
            CollectionAssert.AreEqual(
                new[] { true, true, false },
                (bool[])Configurator.Get(typeof(bool[]), "test-array-bool")
            );
        }

        [Test]
        public void Should_set_default_array_separator()
        {
            ConfiguratorNamespace.Configurator.DefaultArraySeparator = ';';
            Configurator = new Configurator();
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                Configurator.Get<decimal[]>("test-array-decimal-semicolon")
            );
            ConfiguratorNamespace.Configurator.DefaultArraySeparator = ',';
        }

        [Test]
        public void Should_favor_instance_property_over_default_array_separator() {
            ConfiguratorNamespace.Configurator.DefaultArraySeparator = '|';
            Configurator = new Configurator {ArraySeparator = ';'};
            CollectionAssert.AreEqual(
                new[] { 9.1m, 9.2m, 9.3m },
                Configurator.Get<decimal[]>("test-array-decimal-semicolon")
            );
            ConfiguratorNamespace.Configurator.DefaultArraySeparator = ',';
        }
    }
}