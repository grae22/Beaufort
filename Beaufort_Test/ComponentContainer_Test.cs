using System;
using System.Linq;
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

      IComponent retrievedComponent =
        TestObject
          .Components
          .FirstOrDefault( c => c.Name == "TestComponent" );

      Assert.NotNull( retrievedComponent );

      Assert.AreEqual(
        typeof( TestComponent ),
        retrievedComponent.GetType() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void TypeLoadExceptionWhenComponentFailsToInstantiate()
    {
      try
      {
        TestObject.AddComponent( "SomeNonExistentType", "Name" );
      }
      catch( TypeLoadException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ArgumentExceptionOnInvalidComponentName()
    {
      try
      {
        TestObject.AddComponent(
          typeof( TestComponent ).AssemblyQualifiedName,
          "" );
      }
      catch( ArgumentException )
      {
        Assert.Pass();
      }

      Assert.Fail();
    }

    //-------------------------------------------------------------------------

    [Test]
    public void TypeLoadExceptionWhenComponentDoesntImplementIComponent()
    {
      try
      {
        TestObject.AddComponent( "System.Int32", "Name" );
      }
      catch( TypeLoadException )
      {
        Assert.Pass();
      }

      Assert.Fail();
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
