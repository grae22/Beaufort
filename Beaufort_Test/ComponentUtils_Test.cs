﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Beaufort;

namespace Beaufort_Test
{
  [TestFixture]
  [Category( "ComponentUtils" )]
  public class ComponentUtils_Test
  {
    //-------------------------------------------------------------------------

    class TestComponent1 : BaseComponent { }
    class TestComponent2 : BaseComponent { }
    interface TestInterface : IComponent { }

    struct TestStruct : IComponent
    {
      public string Name { get; }
      public bool SetName( string name ) { return true; }
    }

    //-------------------------------------------------------------------------

    [Test]
    public void GetComponentsFromAssemblyReturnsComponentTypes()
    {
      Dictionary<string, Type> components;

      ComponentUtils.GetComponents(
        Assembly.GetExecutingAssembly(),
        out components );

      Assert.True( components.ContainsKey( typeof( TestComponent1 ).AssemblyQualifiedName ) );
      Assert.True( components.ContainsKey( typeof( TestComponent2 ).AssemblyQualifiedName ) );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void GetComponentsFromAssemblyReturnsOnlyComponentTypes()
    {
      Dictionary<string, Type> components;

      ComponentUtils.GetComponents(
        Assembly.GetExecutingAssembly(),
        out components );

      components.ToList().ForEach(
        x =>
        {
          Assert.True( x.Value.IsClass );
          Assert.False( x.Value.IsAbstract );
          Assert.False( x.Value.IsInterface );
        } );
    }

    //-------------------------------------------------------------------------
  }
}
