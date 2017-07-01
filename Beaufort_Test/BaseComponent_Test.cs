using NUnit.Framework;
using Moq;
using Beaufort;

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
  }
}
