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
            new Tuple<byte, string>( 0, "Off" ),
            new Tuple<byte, string>( 1, "On" ),
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
