using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using Beaufort.Input;
using Beaufort.Configuration;

namespace Beaufort_Test.Input
{
  [TestFixture]
  [Category( "DiscreteInput" )]
  class DiscreteInput_Test
  {
    //-------------------------------------------------------------------------

    DiscreteInput TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new DiscreteInput();

      TestObject.SetStates(
        new Tuple<byte, string>[]
        {
          new Tuple<byte, string>( 0, "Off" ),
          new Tuple<byte, string>( 1, "On" )
        }
      );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void InitialValueIsFirstInCollection()
    {
      TestObject.SetStates(
        new Tuple<byte, string>[]
        {
          new Tuple<byte, string>( 1, "On" ),
          new Tuple<byte, string>( 0, "Off" )
        }
      );

      Assert.AreEqual( 1, TestObject.Value );
    }

    //-------------------------------------------------------------------------
    
    [Test]
    public void ExceptionWhenLessThanTwoStates()
    {
      try
      {
        TestObject.SetStates(
          new Tuple<byte, string>[]
          {
            new Tuple<byte, string>( 0, "State1" )
          }
        );
      }
      catch( ArgumentException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionWhenStateValuesNotUnique()
    {
      try
      {
        TestObject.SetStates(
          new Tuple<byte, string>[]
          {
            new Tuple<byte, string>( 0, "State1" ),
            new Tuple<byte, string>( 0, "State2" )
          }
        );
      }
      catch( ArgumentException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionWhenStateNamesNotUnique()
    {
      try
      {
        TestObject.SetStates(
          new Tuple<byte, string>[]
          {
            new Tuple<byte, string>( 0, "State" ),
            new Tuple<byte, string>( 1, "State" )
          }
        );
      }
      catch( ArgumentException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void PossibleValuesAreCorrect()
    {
      Assert.True( TestObject.StateNamesByValue.ContainsKey( 0 ) );
      Assert.AreEqual( "Off", TestObject.StateNamesByValue[ 0 ] );

      Assert.True( TestObject.StateNamesByValue.ContainsKey( 1 ) );
      Assert.AreEqual( "On", TestObject.StateNamesByValue[ 1 ] );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnInvalidUpdateValueType()
    {
      try
      {
        TestObject.UpdateValue( "abc" );
      }
      catch( ArgumentException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnInvalidUpdateValue()
    {
      try
      {
        TestObject.UpdateValue( (byte)2 );
      }
      catch( ArgumentException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void UpdateValue()
    {
      TestObject.UpdateValue( (byte)1 );

      Assert.AreEqual( 1, TestObject.Value );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ConfigureStatesFromStore()
    {
      var store = new Mock<IValueStore>();

      store.Setup( x => x.Exists( "States" ) ).Returns( true );

      store.Setup( x =>
        x.GetValue<Tuple<byte, string>[]>( It.IsAny<string>(), null ) )
        .Returns( () =>
        {
          return new Tuple<byte, string>[]
          {
            new Tuple<byte, string>( 10, "ABC" ),
            new Tuple<byte, string>( 11, "DEF" )
          };
        }
      );
        
      TestObject.Configure( store.Object );

      Assert.True( TestObject.StateNamesByValue.ContainsKey( 10 ) );
      Assert.True( TestObject.StateNamesByValue.ContainsKey( 11 ) );

      Assert.AreEqual( "ABC", TestObject.StateNamesByValue[ 10 ] );
      Assert.AreEqual( "DEF", TestObject.StateNamesByValue[ 11 ] );
    }

    //-------------------------------------------------------------------------    
  }
}
