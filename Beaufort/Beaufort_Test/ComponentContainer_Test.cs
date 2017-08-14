using System;
using System.Linq;
using NUnit.Framework;
using Beaufort;

namespace Beaufort_Test
{
  [TestFixture]
  [Category("ComponentContainer")]
  internal class ComponentContainer_Test
  {
    //-------------------------------------------------------------------------

    internal class TestComponent : BaseComponent
    {
      public byte UpdateCount { get; private set; }
      public ushort DeltaTimeMs { get; private set; }

      public override void Update(ushort deltaTimeMs)
      {
        UpdateCount++;
        DeltaTimeMs = deltaTimeMs;
      }
    }

    //-------------------------------------------------------------------------

    private ComponentContainer _testObject;

    //-------------------------------------------------------------------------

    [SetUp]
    public void SetUp()
    {
      _testObject = new ComponentContainer("TestObject");
    }

    //-------------------------------------------------------------------------

    [Test]
    public void AddComponent()
    {
      IComponent component =
        _testObject.AddComponent(
          typeof(TestComponent).AssemblyQualifiedName,
          "TestComponent");

      Assert.NotNull(component);

      IComponent retrievedComponent =
        _testObject
          .Components
          .FirstOrDefault(c => c.Name == "TestComponent");

      Assert.NotNull(retrievedComponent);

      Assert.AreEqual(
        typeof(TestComponent),
        retrievedComponent.GetType());
    }

    //-------------------------------------------------------------------------

    [Test]
    public void TypeLoadExceptionWhenComponentFailsToInstantiate()
    {
      try
      {
        _testObject.AddComponent("SomeNonExistentType", "Name");
      }
      catch (TypeLoadException)
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
        _testObject.AddComponent(
          typeof(TestComponent).AssemblyQualifiedName,
          "");
      }
      catch (ArgumentException)
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
        _testObject.AddComponent("System.Int32", "Name");
      }
      catch (TypeLoadException)
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
        _testObject.AddComponent(
          typeof(TestComponent).AssemblyQualifiedName,
          "TestComponent");

      _testObject.Update(1);

      Assert.AreEqual(1, ((TestComponent)component).UpdateCount);
    }

    //-------------------------------------------------------------------------

    [Test]
    public void ComponentUpdateIsWithCorrectDeltaTime()
    {
      IComponent component =
        _testObject.AddComponent(
          typeof(TestComponent).AssemblyQualifiedName,
          "TestComponent");

      _testObject.Update(123);

      Assert.AreEqual(123, ((TestComponent)component).DeltaTimeMs);
    }

    //-------------------------------------------------------------------------
  }
}