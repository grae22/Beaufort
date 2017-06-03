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

    //-------------------------------------------------------------------------

    [Test]
    public void GetComponentsFromAssembly()
    {
      Dictionary<string, Type> components;

      ComponentUtils.GetComponents(
        Assembly.GetExecutingAssembly(),
        out components );

      Assert.True( components.ContainsKey( typeof( TestComponent1 ).FullName ) );
      Assert.True( components.ContainsKey( typeof( TestComponent2 ).FullName ) );
    }

    //-------------------------------------------------------------------------
  }
}
