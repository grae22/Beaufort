﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Beaufort
{
  public class ComponentUtils
  {
    //-------------------------------------------------------------------------

    public static void GetComponents( Assembly assembly,
                                      out Dictionary<string, Type> components )
    {
      components = new Dictionary<string, Type>();

      IEnumerable<Type> foundComponentTypes =
        assembly
          .GetTypes()
          .Where( type =>
            typeof( IComponent ).IsAssignableFrom( type ) &&
            type.IsClass &&
            type.IsAbstract == false )
          .ToList();

      foreach( Type type in foundComponentTypes )
      {
        components.Add( type.AssemblyQualifiedName, type );
      }
    }

    //-------------------------------------------------------------------------

    public static void GetDependencyTypes( Type componentType,
                                           out Dictionary<string, Type> dependencyTypesByName )
    {
      dependencyTypesByName = new Dictionary<string, Type>();

      IEnumerable<PropertyInfo> dependencyProperties =
        GetDependenciesFromComponentProperties( componentType );

      foreach( PropertyInfo info in dependencyProperties )
      {
        dependencyTypesByName.Add( info.Name, info.PropertyType );
      }
    }

    //-------------------------------------------------------------------------

    public static void GetDependencyInstances( IComponent component,
                                               out Dictionary<string, IComponent> dependenciesByName )
    {
      dependenciesByName = new Dictionary<string, IComponent>();

      IEnumerable<PropertyInfo> dependencyProperties =
        GetDependenciesFromComponentProperties( component.GetType() );

      foreach( PropertyInfo info in dependencyProperties )
      {
        dependenciesByName.Add(
          info.Name,
          info.GetValue( component ) as IComponent );
      }
    }

    //-------------------------------------------------------------------------

    public static void GetDependencyDetails( IComponent component,
                                             out Dictionary<string, Type> dependencyTypesByName,
                                             out Dictionary<string, IComponent> dependenciesByName )
    {
      GetDependencyTypes( component.GetType(), out dependencyTypesByName );
      GetDependencyInstances( component, out dependenciesByName );
    }

    //-------------------------------------------------------------------------

    static IEnumerable<PropertyInfo> GetDependenciesFromComponentProperties( Type componentType )
    {
      return
        componentType
          .GetProperties()
          .Where(
            property =>
              typeof( IComponent ).IsAssignableFrom( property.PropertyType ) &&
              property.GetSetMethod() != null );
    }

    //-------------------------------------------------------------------------
  }
}
