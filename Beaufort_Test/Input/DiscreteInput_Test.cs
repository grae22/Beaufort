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
      TestObject = new DiscreteInput();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void InitialValue()
    {
      Assert.AreEqual( 0, TestObject.Value );
    }

    //-------------------------------------------------------------------------
  }
}
