using System;
using System.Reflection;
using System.Collections.Generic;
using NUnit.Framework;
using Beaufort;

namespace Beaufort_Test
{
  [TestFixture]
  [Category( "ComponentUtils" )]
  public class ComponentUtils_Test
  {
    //-------------------------------------------------------------------------

    class TestComponent1 : IComponent { }
    class TestComponent2 : IComponent { }
    interface TestInterface : IComponent { }
    struct TestStruct : IComponent { }

    //-------------------------------------------------------------------------

    [Test]
    public void GetComponentsFromAssemblyReturnsComponentTypes()
    {
      Dictionary<string, Type> components;

      ComponentUtils.GetComponents(
        Assembly.GetExecutingAssembly(),
        out components );

      Assert.True( components.ContainsKey( typeof( TestComponent1 ).FullName ) );
      Assert.True( components.ContainsKey( typeof( TestComponent2 ).FullName ) );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void GetComponentsFromAssemblyReturnsOnlyComponentTypes()
    {
      Dictionary<string, Type> components;

      ComponentUtils.GetComponents(
        Assembly.GetExecutingAssembly(),
        out components );

      Assert.AreEqual( 2, components.Count );
    }

    //-------------------------------------------------------------------------
  }
}
