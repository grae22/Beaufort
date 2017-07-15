using NUnit.Framework;
using Moq;
using Beaufort;
using Beaufort.Configuration;
using Beaufort.Exceptions;

namespace Beaufort_Test
{
  [TestFixture]
  [Category( "BaseComponent" )]
  public class BaseComponent_Test
  {
    //-------------------------------------------------------------------------

    Mock<BaseComponent> TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new Mock<BaseComponent>();
    }
    
    //-------------------------------------------------------------------------

    [Test]
    public void SetValidName()
    {
      bool result = TestObject.Object.SetName( "TestObject" );

      Assert.True( result );
      Assert.AreEqual( "TestObject", TestObject.Object.Name );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void SetZeroLengthName()
    {
      bool result = TestObject.Object.SetName( string.Empty );

      Assert.False( result );
      Assert.AreEqual( "Unnamed Component", TestObject.Object.Name );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void NoExceptionOnConfigureIfValueStoreInjected()
    {
      // We want the base Configure() method to be called.
      TestObject.CallBase = true;

      TestObject.Object.InjectValueStore( new Mock<IValueStore>().Object );
      TestObject.Object.Configure();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ExceptionOnConfigureWhenValueStoreNotInjected()
    {
      try
      {
        // We want the base Configure() method to be called.
        TestObject.CallBase = true;

        TestObject.Object.Configure();
      }
      catch( NullValueStoreException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------
  }
}
