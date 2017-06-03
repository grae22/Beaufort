using System;
using System.Collections.Generic;

namespace Beaufort
{
  public class ComponentContainer
  {
    //-------------------------------------------------------------------------

    public string Name { get; private set; }

    //-------------------------------------------------------------------------

    public IComponent this[ string componentName ]
    {
      get
      {
        if( Components.ContainsKey( componentName ) )
        {
          return Components[ componentName ];
        }

        return null;
      }
    }

    //-------------------------------------------------------------------------

    Dictionary<string, IComponent> Components = new Dictionary<string, IComponent>();

    //-------------------------------------------------------------------------

    public ComponentContainer( string name )
    {
      Name = name;
    }

    //-------------------------------------------------------------------------

    public void AddComponent( string fullTypeName,
                              string instanceName )
    {
      if( Components.ContainsKey( instanceName ) )
      {
        throw new ArgumentException(
          string.Format(
            "Component already exists in container \"{0}\" with name \"{1}\".",
            Name,
            instanceName ),
          nameof( instanceName ) );
      }

      IComponent newComponent = InstantiateComponent( fullTypeName, instanceName );

      if( newComponent == null )
      {
        throw new NullReferenceException(
          string.Format(
            "Failed to instantiate component of type \"{0}\" with name \"{1}\".",
            fullTypeName,
            instanceName ) );
      }

      Components.Add( instanceName, newComponent );
    }

    //-------------------------------------------------------------------------

    public bool Contains( string componentInstanceName )
    {
      return Components.ContainsKey( componentInstanceName );
    }

    //-------------------------------------------------------------------------

    IComponent InstantiateComponent( string fullTypeName,
                                     string instanceName )
    {
      Type type = Type.GetType( fullTypeName, true );

      object newObject = Activator.CreateInstance( type );

      if( newObject == null )
      {
        throw new ArgumentException(
          string.Format(
            "Failed to instantiate object of type \"{0}\" with name \"{1}\".",
            fullTypeName,
            instanceName ),
          nameof( fullTypeName ) );
      }

      IComponent newComponent = (IComponent)newObject;

      if( newComponent == null )
      {
        throw new ArgumentException(
          string.Format(
            "Failed to cast object of type \"{0}\" with name \"{1}\" to \"{2}\".",
            fullTypeName,
            instanceName,
            typeof( IComparable ).Name ),
          nameof( fullTypeName ) );
      }

      return newComponent;
    }

    //-------------------------------------------------------------------------
  }
}
