using NUnit.Framework;
using Moq;
using Beaufort;
using Beaufort.Configuration;
using Beaufort.Exceptions;

namespace Beaufort_Test
{
  [TestFixture]
  [Category("BaseComponent")]
  internal class BaseComponent_Test
  {
    //-------------------------------------------------------------------------

    private Mock<BaseComponent> _testObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      _testObject = new Mock<BaseComponent>();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SetValidName()
    {
      bool result = _testObject.Object.SetName("TestObject");

      Assert.True(result);
      Assert.AreEqual("TestObject", _testObject.Object.Name);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SetZeroLengthName()
    {
      bool result = _testObject.Object.SetName(string.Empty);

      Assert.False(result);
      Assert.AreEqual("Unnamed Component", _testObject.Object.Name);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void NoExceptionOnConfigureIfValueStoreInjected()
    {
      // We want the base Configure() method to be called.
      _testObject.CallBase = true;

      _testObject.Object.InjectValueStore(new Mock<IValueStore>().Object);
      _testObject.Object.Configure();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnConfigureWhenValueStoreNotInjected()
    {
      try
      {
        // We want the base Configure() method to be called.
        _testObject.CallBase = true;

        _testObject.Object.Configure();
      }
      catch (NullValueStoreException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void NoExceptionOnGetConfigurationDataIfValueStoreInjected()
    {
      // We want the base Configure() method to be called.
      _testObject.CallBase = true;

      _testObject.Object.InjectValueStore(new Mock<IValueStore>().Object);
      _testObject.Object.GetConfigurationData();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionGetConfigureDataWhenValueStoreNotInjected()
    {
      try
      {
        // We want the base Configure() method to be called.
        _testObject.CallBase = true;

        _testObject.Object.GetConfigurationData();
      }
      catch (NullValueStoreException)
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------
  }
}