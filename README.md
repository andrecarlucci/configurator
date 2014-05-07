[![Build status](https://ci.appveyor.com/api/projects/status/o3f88yrnsg8ghdra)](https://ci.appveyor.com/project/luisrudge/configurator)
configurator
============

####Stop writing your ConfigurationManagerWrapper!

##How to use:
###Simple Get
Your app config:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="test-int" value="5"/>
    <add key="test-datetime" value="2013-01-01"/>
    <add key="test-string" value="test"/>
    <add key="test-decimal" value="9.5"/>
    <add key="test-bool" value="true"/>
    <add key="test-empty" value=""/>
  </appSettings>
  <connectionStrings>
    <add name="connection" connectionString="connection-string"/>
  </connectionStrings>
</configuration>
```

Your code:
```csharp
IConfigurator configurator = new Configurator();

//Simple Get
configurator.Get<int>("test-int").ShouldEqual(5);
configurator.Get<DateTime>("test-datetime").ShouldEqual(new DateTime(2013, 1, 1));
configurator.Get<string>("test-string").ShouldEqual("test");
configurator.Get<decimal>("test-decimal").ShouldEqual(9.5m);
configurator.Get<bool>("test-bool").ShouldEqual(true);

//Get required value
configurator.Get<int>("test-empty", required: true); //throws ConfigurationValueNotFoundException

//Get non-existent key
configurator.Get<int>("this-key-doesnt-exist"); //throws ConfigurationKeyNotFoundException

//Get connection string by name
configurator.GetConnectionString("connection").ShouldEqual("connection-string");

//Get inexistent connection string by name
configurator.GetConnectionString("connection-nope"); //throws ConnectionStringNotFoundException

```

###Mapping Classes
Your app config:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="testInt" value="5"/>
    <add key="testDatetime" value="2013-01-01"/>
    <add key="testString" value="test"/>
    <add key="testDecimal" value="9.5"/>
    <add key="testBool" value="true"/>
    <add key="testEmpty" value=""/>
  </appSettings>
</configuration>
```

Your code:
```csharp
public class MappingTestConfig
{
    public int TestInt { get; set; }
    public DateTime TestDatetime { get; set; }
    public string TestString { get; set; }
    public decimal TestDecimal { get; set; }
    public bool TestBool { get; set; }
    public string TestEmpty { get; set; }
}

IConfigurator configurator = new Configurator();

var config = configurator.Map<MappingTestConfig>();
config.TestInt.ShouldEqual(5);
config.TestDatetime.ShouldEqual(new DateTime(2013, 1, 1));
config.TestString.ShouldEqual("test");
config.TestDecimal.ShouldEqual(9.5m);
config.TestBool.ShouldEqual(true);
```
