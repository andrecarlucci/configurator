using System;
using NUnit.Framework;
using Should;

namespace Configurator.Tests
{
    public class ConfiguratorExtensionsTests : BaseTest
    {
        [Test]
        public void Should_Map_T()
        {
            var config = Configurator.Map<MappingTestConfig>();
            config.TestInt.ShouldEqual(5);
            config.TestDatetime.ShouldEqual(new DateTime(2013, 1, 1));
            config.TestString.ShouldEqual("test");
            config.TestDecimal.ShouldEqual(9.5m);
            config.TestBool.ShouldEqual(true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationValueNotFoundException))]
        public void Map_Should_Throw_ConfigurationValueNotFoundException_when_required_value_is_empty()
        {
            Configurator.Map<MappingTestConfig>(true);
        }

        [Test]
        [ExpectedException(typeof (ConfigurationKeyNotFoundException))]
        public void Map_Should_Throw_ConfigurationValueNotFoundException_when_key_is_not_found()
        {
            Configurator.Map<KeyNotFoundConfig>(true);
        }
    }

    public class MappingTestConfig
    {
        public int TestInt { get; set; }
        public DateTime TestDatetime { get; set; }
        public string TestString { get; set; }
        public decimal TestDecimal { get; set; }
        public bool TestBool { get; set; }
        public string TestEmpty { get; set; }
    }

    public class KeyNotFoundConfig
    {
        public string NopeConfig { get; set; }
    }
}