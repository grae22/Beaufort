using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Beaufort
{
  class ComponentUtils
  {
    //-------------------------------------------------------------------------

    public static void GetComponents( Assembly assembly,
                                      out Dictionary<string, Type> components )
    {
      components = new Dictionary<string, Type>();

      IEnumerable<Type> foundComponentTypes =
        assembly.GetTypes()
          .Where( x => x.GetType().IsInstanceOfType( typeof( IComponent ) ) )
          .ToList();

      foreach( Type type in foundComponentTypes )
      {
        components.Add( type.FullName, type );
      }
    }

    //-------------------------------------------------------------------------
  }
}
