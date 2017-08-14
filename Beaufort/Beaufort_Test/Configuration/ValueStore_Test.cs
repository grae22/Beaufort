using System;
using NUnit.Framework;
using Beaufort.Configuration;

namespace Beaufort_Test.Configuration
{
  [TestFixture]
  [Category("ValueStore")]
  internal class ValueStore_Test
  {
    //-------------------------------------------------------------------------

    private ValueStore _testObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      _testObject = new ValueStore();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DefaultValueReturnedIfValueNotSet()
    {
      int value = _testObject.GetValue("TestValue", 123);

      Assert.True(_testObject.Exists("TestValue"));
      Assert.AreEqual(123, value);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ValueExistsAfterBeingSet()
    {
      _testObject.SetValue("TestValue", 123);

      Assert.True(_testObject.Exists("TestValue"));
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ValueIsCorrectAfterBeingSet()
    {
      _testObject.SetValue("TestValue", 123);

      Assert.AreEqual(123, _testObject.GetValue<int>("TestValue"));
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ValueUpdateAfterBeingChanged()
    {
      _testObject.SetValue("TestValue", 123);
      _testObject.SetValue("TestValue", 321);

      Assert.True(_testObject.Exists("TestValue"));
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnGetValueWithIncorrectType()
    {
      _testObject.SetValue("TestValue", "ABC");

      try
      {
        _testObject.GetValue<int>("TestValue");
      }
      catch (InvalidCastException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnSetExistingValueWithDifferentType()
    {
      _testObject.SetValue("TestValue", 123);

      try
      {
        _testObject.SetValue("TestValue", "ABC");
      }
      catch (InvalidCastException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ConvertNumericToString()
    {
      _testObject.SetValue("Test", 123);
      _testObject.SetValue("Test", "456");

      Assert.AreEqual(456, _testObject.GetValue<int>("Test"));
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ConvertNumericStringToNumeric()
    {
      _testObject.SetValue("Test", "456");
      _testObject.SetValue("Test", 123);

      Assert.AreEqual(123, _testObject.GetValue<int>("Test"));
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SerialiseToJson()
    {
      _testObject.SetValue("TestInt", 123);
      _testObject.SetValue("TestString", "ABC");

      string serialisedStore = _testObject.Serialise();

      Assert.AreEqual(
        "{" + Environment.NewLine +
        "  \"TestInt\": 123," + Environment.NewLine +
        "  \"TestString\": \"ABC\"" + Environment.NewLine +
        "}",
        serialisedStore);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DeserialiseFromJson()
    {
      _testObject.Deserialise("{\"TestInt\":123,\"TestString\":\"ABC\"}");

      Assert.True(_testObject.Exists("TestInt"));
      Assert.AreEqual(123, _testObject.GetValue<int>("TestInt"));

      Assert.True(_testObject.Exists("TestString"));
      Assert.AreEqual("ABC", _testObject.GetValue<string>("TestString"));
    }

    //-------------------------------------------------------------------------
  }
}