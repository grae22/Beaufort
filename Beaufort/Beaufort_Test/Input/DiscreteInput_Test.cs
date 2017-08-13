using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using Beaufort.Input;
using Beaufort.Configuration;

namespace Beaufort_Test.Input
{
  [TestFixture]
  [Category("DiscreteInput")]
  class DiscreteInput_Test
  {
    //-------------------------------------------------------------------------

    DiscreteInput TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new DiscreteInput();

      TestObject.AddState(0, "Off");
      TestObject.AddState(1, "On");
    }

    //-------------------------------------------------------------------------

    [Test]
    public void InitialValueIsFirstInCollection()
    {
      TestObject.RemoveAllStates();

      TestObject.AddState(1, "On");
      TestObject.AddState(0, "Off");

      Assert.AreEqual(1, TestObject.Value);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionWhenStateValuesNotUnique()
    {
      try
      {
        TestObject.RemoveAllStates();

        TestObject.AddState(0, "State1");
        TestObject.AddState(0, "State2");
      }
      catch (ArgumentException)
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
        TestObject.RemoveAllStates();

        TestObject.AddState(0, "State");
        TestObject.AddState(1, "State");
      }
      catch (ArgumentException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void PossibleValuesAreCorrect()
    {
      Assert.True(TestObject.GetStates().ContainsKey(0));
      Assert.AreEqual("Off", TestObject.GetStates()[0]);

      Assert.True(TestObject.GetStates().ContainsKey(1));
      Assert.AreEqual("On", TestObject.GetStates()[1]);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnInvalidUpdateValueType()
    {
      try
      {
        TestObject.UpdateValue("abc");
      }
      catch (ArgumentException)
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
        TestObject.UpdateValue((byte)2);
      }
      catch (ArgumentException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void UpdateValue()
    {
      TestObject.UpdateValue((byte)1);

      Assert.AreEqual(1, TestObject.Value);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ConfigureStatesFromStore()
    {
      var store = new Mock<IValueStore>();

      store.Setup(x => x.Exists("States")).Returns(true);

      store.Setup(
          x => x.GetValue<Dictionary<byte, string>>(It.IsAny<string>(), null))
        .Returns(() =>
          {
            return new Dictionary<byte, string>
            {
              {10, "ABC"},
              {11, "DEF"}
            };
          }
        );

      TestObject.InjectValueStore(store.Object);

      TestObject.Configure();

      Assert.True(TestObject.GetStates().ContainsKey(10));
      Assert.True(TestObject.GetStates().ContainsKey(11));

      Assert.AreEqual("ABC", TestObject.GetStates()[10]);
      Assert.AreEqual("DEF", TestObject.GetStates()[11]);
    }

    //-------------------------------------------------------------------------    

    [Test]
    public void RemoveOneState()
    {
      TestObject.RemoveState(0);

      Assert.AreEqual(1, TestObject.GetStates().Count);
      Assert.True(TestObject.GetStates().ContainsKey(1));
    }

    //-------------------------------------------------------------------------

    [Test]
    public void RemoveAllStates()
    {
      TestObject.RemoveAllStates();

      Assert.AreEqual(0, TestObject.GetStates().Count);
    }

    //-------------------------------------------------------------------------
  }
}