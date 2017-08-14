using NUnit.Framework;
using InputComponents;

namespace InputComponents_Test
{
  [TestFixture]
  [Category("Switch")]
  internal class Switch_Test
  {
    //-------------------------------------------------------------------------

    private Switch _testObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      _testObject = new Switch();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void States()
    {
      Assert.AreEqual("Off", _testObject.GetStates()[0]);
      Assert.AreEqual("On", _testObject.GetStates()[1]);
    }

    //-------------------------------------------------------------------------
  }
}