using System;
using NUnit.Framework;
using InputComponents;

namespace InputComponents_Test
{
  [TestFixture]
  [Category( "Switch" )]
  public class Switch_Test
  {
    //-------------------------------------------------------------------------

    Switch TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject =
        new Switch(
          new Tuple<byte, string>[]
          {
            new Tuple<byte, string>( 0, "On" ),
            new Tuple<byte, string>( 1, "Off" ),
          }
        );
    }
    
    //-------------------------------------------------------------------------

    [Test]
    public void Test123()
    {

    }

    //-------------------------------------------------------------------------
  }
}
