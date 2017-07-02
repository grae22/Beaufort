using System;
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

    class TestComponent2 : BaseComponent
    {
      public TestComponent1 Dependency { private get; set; }
    }

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
        });
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DependencyTypes()
    {
      Dictionary<string, Type> dependencyTypesByName;

      ComponentUtils.GetDependencyTypes(
        typeof( TestComponent2 ),
        out dependencyTypesByName );

      Assert.AreEqual( 1, dependencyTypesByName.Count );

      Assert.AreEqual(
        nameof( TestComponent2.Dependency ),
        dependencyTypesByName.Keys.First() );

      Assert.AreEqual(
        typeof( TestComponent1 ),
        dependencyTypesByName.Values.First() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DependencyInstanceNullWhenNotSet()
    {
      TestComponent2 component = new TestComponent2();
      Dictionary<string, IComponent> dependenciesByName;

      ComponentUtils.GetDependencyInstances(
        component,
        out dependenciesByName );

      Assert.AreEqual( 1, dependenciesByName.Count );
      Assert.IsNull( dependenciesByName.Values.First() );
    }

    //-------------------------------------------------------------------------

    [Test]
    public void DependencyInstanceValue()
    {
      var dependency = new TestComponent1();

      TestComponent2 component = new TestComponent2
      {
        Dependency = dependency
      };

      Dictionary<string, IComponent> dependenciesByName;

      ComponentUtils.GetDependencyInstances(
        component,
        out dependenciesByName );

      Assert.AreEqual( 1, dependenciesByName.Count );
      Assert.AreSame( dependency, dependenciesByName.Values.First() );
    }

    //-------------------------------------------------------------------------
  }
}
