using System;
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
        assembly.GetTypes()
          .Where( x =>
            typeof( IComponent ).IsAssignableFrom( x ) &&
            x.IsClass &&
            x.IsAbstract == false )
          .ToList();

      foreach( Type type in foundComponentTypes )
      {
        components.Add( type.AssemblyQualifiedName, type );
      }
    }

    //-------------------------------------------------------------------------

    public static void GetDependencies( Type componentType,
                                        out Dictionary<string, Type> dependencyTypesByName )
    {
      dependencyTypesByName = new Dictionary<string, Type>();

      List<PropertyInfo> dependencyProperties =
        componentType.GetProperties().Where(
          prop =>
            typeof( IComponent ).IsAssignableFrom( prop.PropertyType ) &&
            prop.GetSetMethod() != null )
          .ToList();

      foreach( PropertyInfo info in dependencyProperties )
      {
        dependencyTypesByName.Add( info.Name, info.PropertyType );
      }
    }

    //-------------------------------------------------------------------------
  }
}
