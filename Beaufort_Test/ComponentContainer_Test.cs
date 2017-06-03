using NUnit.Framework;
using Beaufort;

namespace Beaufort_Test
{
  [TestFixture]
  [Category( "ComponentContainer" )]
  public class ComponentContainer_Test
  {
    //-------------------------------------------------------------------------

    ComponentContainer TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new ComponentContainer();
    }
    

    //-------------------------------------------------------------------------

    [Test]
    public void AddComponent()
    {

    }

    //-------------------------------------------------------------------------
  }
}
