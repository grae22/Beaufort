using System;
using NUnit.Framework;
using Beaufort.Configuration;

namespace Beaufort_Test.Configuration
{
  [TestFixture]
  [Category( "ValueStore" )]
  class ValueStore_Test
  {
    //-------------------------------------------------------------------------

    ValueStore TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new ValueStore();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ValueExistsAfterBeingSet()
    {
      TestObject.SetValue( "TestValue", 123 );

      Assert.True( TestObject.Exists( "TestValue" ) );
    }

    //-------------------------------------------------------------------------
    
    [Test]
    public void ValueIsCorrectAfterBeingSet()
    {
      TestObject.SetValue( "TestValue", 123 );

      Assert.AreEqual( 123, TestObject.GetValue<int>( "TestValue" ) );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ValueUpdateAfterBeingChanged()
    {
      TestObject.SetValue( "TestValue", 123 );
      TestObject.SetValue( "TestValue", 321 );

      Assert.True( TestObject.Exists( "TestValue" ) );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnGetValueWithIncorrectType()
    {
      TestObject.SetValue( "TestValue", "ABC" );

      try
      {
        TestObject.GetValue<int>( "TestValue" );
      }
      catch( InvalidCastException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnSetExistingValueWithDifferentType()
    {
      TestObject.SetValue( "TestValue", 123 );

      try
      {
        TestObject.SetValue( "TestValue", "ABC" );
      }
      catch( InvalidCastException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ConvertNumericToString()
    {
      TestObject.SetValue( "Test", 123 );
      TestObject.SetValue( "Test", "456" );

      Assert.AreEqual( 456, TestObject.GetValue<int>( "Test" ) );
    }

    //-------------------------------------------------------------------------
    
    [Test]
    public void ConvertNumericStringToNumeric()
    {
      TestObject.SetValue( "Test", "456" );
      TestObject.SetValue( "Test", 123 );

      Assert.AreEqual( 123, TestObject.GetValue<int>( "Test" ) );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SerialiseToJson()
    {
      TestObject.SetValue( "TestInt", 123 );
      TestObject.SetValue( "TestString", "ABC" );

      string serialisedStore = TestObject.Serialise();

      Assert.AreEqual(
        "{\"TestInt\":123,\"TestString\":\"ABC\"}",
        serialisedStore );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DeserialiseFromJson()
    {
      TestObject.Deserialise( "{\"TestInt\":123,\"TestString\":\"ABC\"}" );

      Assert.True( TestObject.Exists( "TestInt" ) );
      Assert.AreEqual( 123, TestObject.GetValue<int>( "TestInt" ) );

      Assert.True( TestObject.Exists( "TestString" ) );
      Assert.AreEqual( "ABC", TestObject.GetValue<string>( "TestString" ) );
    }

    //-------------------------------------------------------------------------
  }
}
