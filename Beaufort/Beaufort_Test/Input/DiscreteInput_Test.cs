using System;
using NUnit.Framework;
using Beaufort.Input;

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
      TestObject =
        new DiscreteInput(
          new Tuple<byte, string>[]
          {
            new Tuple<byte, string>( 0, "Off" ),
            new Tuple<byte, string>( 1, "On" )
          }
        );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void InitialValue()
    {
      Assert.AreEqual( 0, TestObject.Value );
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
  }
}
