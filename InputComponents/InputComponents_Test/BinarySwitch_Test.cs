﻿using NUnit.Framework;
using InputComponents;

namespace InputComponents_Test
{
  [TestFixture]
  [Category("BinarySwitch")]
  public class BinarySwitch_Test
  {
    //-------------------------------------------------------------------------

    BinarySwitch TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new BinarySwitch();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void States()
    {
      Assert.AreEqual("Off", TestObject.GetStates()[0]);
      Assert.AreEqual("On", TestObject.GetStates()[1]);
    }

    //-------------------------------------------------------------------------
  }
}