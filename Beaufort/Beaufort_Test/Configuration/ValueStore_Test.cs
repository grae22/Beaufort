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
      TestObject.SetValue( "TestValue", 123 );

      try
      {
        TestObject.GetValue<string>( "TestValue" );
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
        TestObject.SetValue( "TestValue", "" );
      }
      catch( InvalidCastException )
      {
        Assert.Pass();
      }

      Assert.Fail();
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
  }
}
