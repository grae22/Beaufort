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
        components.Add( type.FullName, type );
      }
    }

    //-------------------------------------------------------------------------
  }
}
