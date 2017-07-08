using NUnit.Framework;
using Beaufort;

namespace Beaufort_Test
{
  [TestFixture]
  [Category( "ComponentContainer" )]
  public class ComponentContainer_Test
  {
    //-------------------------------------------------------------------------

    public class TestComponent : BaseComponent
    {
      public byte UpdateCount { get; private set; }
      public ushort DeltaTimeMs { get; private set; }

      public override void Update( ushort deltaTimeMs )
      {
        UpdateCount++;
        DeltaTimeMs = deltaTimeMs;
      }
    }

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
      IComponent component =
        TestObject.AddComponent(
          typeof( TestComponent ).AssemblyQualifiedName,
          "TestComponent" );

      Assert.NotNull( component );

      Assert.True( TestObject.Contains( "TestComponent" ) );

      Assert.AreEqual(
        typeof( TestComponent ),
        TestObject[ "TestComponent" ].GetType() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ComponentUpdateIsCalledOnce()
    {
      IComponent component =
        TestObject.AddComponent(
          typeof( TestComponent ).AssemblyQualifiedName,
          "TestComponent" );

      TestObject.Update( 1 );

      Assert.AreEqual( 1, ((TestComponent)component).UpdateCount );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ComponentUpdateIsWithCorrectDeltaTime()
    {
      IComponent component =
        TestObject.AddComponent(
          typeof( TestComponent ).AssemblyQualifiedName,
          "TestComponent" );

      TestObject.Update( 123 );

      Assert.AreEqual( 123, ((TestComponent)component).DeltaTimeMs );
    }

    //-------------------------------------------------------------------------
  }
}
