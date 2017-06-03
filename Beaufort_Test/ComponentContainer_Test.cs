using NUnit.Framework;
using Beaufort;

namespace Beaufort_Test
{
  [TestFixture]
  [Category( "ComponentContainer" )]
  public class ComponentContainer_Test
  {
    //-------------------------------------------------------------------------

    public class TestComponent : IComponent { }

    //-------------------------------------------------------------------------

    ComponentContainer TestObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      TestObject = new ComponentContainer( "TestObject" );
    }
    

    //-------------------------------------------------------------------------

    [Test]
    public void AddComponent()
    {
      TestObject.AddComponent(
        typeof( TestComponent ).AssemblyQualifiedName,
        "TestComponent" );

      Assert.True( TestObject.Contains( "TestComponent" ) );

      Assert.AreEqual(
        typeof( TestComponent ),
        TestObject[ "TestComponent" ].GetType() );
    }

    //-------------------------------------------------------------------------
  }
}
