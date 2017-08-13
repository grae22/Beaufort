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

    DiscreteInput _testObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      _testObject = new DiscreteInput();

      _testObject.AddState(0, "Off");
      _testObject.AddState(1, "On");
    }

    //-------------------------------------------------------------------------

    [Test]
    public void InitialValueIsFirstInCollection()
    {
      _testObject.RemoveAllStates();

      _testObject.AddState(1, "On");
      _testObject.AddState(0, "Off");

      Assert.AreEqual(1, _testObject.Value);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionWhenStateValuesNotUnique()
    {
      try
      {
        _testObject.RemoveAllStates();

        _testObject.AddState(0, "State1");
        _testObject.AddState(0, "State2");
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
        _testObject.RemoveAllStates();

        _testObject.AddState(0, "State");
        _testObject.AddState(1, "State");
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
      Assert.True(_testObject.GetStates().ContainsKey(0));
      Assert.AreEqual("Off", _testObject.GetStates()[0]);

      Assert.True(_testObject.GetStates().ContainsKey(1));
      Assert.AreEqual("On", _testObject.GetStates()[1]);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnInvalidUpdateValueType()
    {
      try
      {
        _testObject.UpdateValue("abc");
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
        _testObject.UpdateValue((byte)2);
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
      _testObject.UpdateValue((byte)1);

      Assert.AreEqual(1, _testObject.Value);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ConfigureStatesFromStore()
    {
      var store = new Mock<IValueStore>();

      store.Setup(x => x.Exists("States")).Returns(true);

      store.Setup(
          x => x.GetValue<Dictionary<byte, string>>(It.IsAny<string>(), null))
        .Returns(() => new Dictionary<byte, string>
        {
          {10, "ABC"},
          {11, "DEF"}
        });

      _testObject.InjectValueStore(store.Object);

      _testObject.Configure();

      Assert.True(_testObject.GetStates().ContainsKey(10));
      Assert.True(_testObject.GetStates().ContainsKey(11));

      Assert.AreEqual("ABC", _testObject.GetStates()[10]);
      Assert.AreEqual("DEF", _testObject.GetStates()[11]);
    }

    //-------------------------------------------------------------------------    

    [Test]
    public void UpdateStoreWithStates()
    {
      var store = new ValueStore();

      _testObject.InjectValueStore(store);
      _testObject.GetConfigurationData();

      Assert.True(store.Exists("States"));

      var states = store.GetValue("States", new Dictionary<byte, string>());

      Assert.True(states.ContainsKey(0));
      Assert.True(states.ContainsKey(1));

      Assert.AreEqual("Off", states[0]);
      Assert.AreEqual("On", states[1]);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void RemoveOneState()
    {
      _testObject.RemoveState(0);

      Assert.AreEqual(1, _testObject.GetStates().Count);
      Assert.True(_testObject.GetStates().ContainsKey(1));
    }

    //-------------------------------------------------------------------------

    [Test]
    public void RemoveAllStates()
    {
      _testObject.RemoveAllStates();

      Assert.AreEqual(0, _testObject.GetStates().Count);
    }

    //-------------------------------------------------------------------------
  }
}