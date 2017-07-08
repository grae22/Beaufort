using System;
using System.Linq;
using System.Collections.Generic;

namespace Beaufort
{
  public class ComponentContainer : IComponentContainerInfo
  {
    //-------------------------------------------------------------------------

    public string Name { get; private set; }

    //-------------------------------------------------------------------------

    public IComponent this[ string componentName ]
    {
      get
      {
        return _Components.FirstOrDefault( x => x.Name == componentName );
      }
    }

    //-------------------------------------------------------------------------

    List<IComponent> _Components = new List<IComponent>();

    //-------------------------------------------------------------------------

    public ComponentContainer( string name )
    {
      Name = name;
    }

    // IComponentContainerInfo ================================================

    public IReadOnlyCollection<IComponent> Components
    {
      get
      {
        return _Components.AsReadOnly();
      }
    }

    //=========================================================================

    public IComponent AddComponent( string fullTypeName,
                                    string instanceName )
    {
      IComponent newComponent = InstantiateComponent( fullTypeName, instanceName );

      if( newComponent == null )
      {
        throw new NullReferenceException(
          string.Format(
            "Failed to instantiate component of type \"{0}\" with name \"{1}\".",
            fullTypeName,
            instanceName ) );
      }

      bool namedOk = newComponent.SetName( instanceName );

      if( namedOk == false )
      {
        throw new ArgumentException(
          string.Format(
            "Failed to name object of type \"{0}\" with name \"{1}\".",
            fullTypeName,
            instanceName ),
          nameof( instanceName ) );
      }

      _Components.Add( newComponent );

      return newComponent;
    }

    //-------------------------------------------------------------------------

    public bool Contains( string componentInstanceName )
    {
      return this[ componentInstanceName ] != null;
    }

    //-------------------------------------------------------------------------

    public void Update( ushort deltaTimeMs )
    {
      _Components.ForEach( c => c.Update( deltaTimeMs ) );
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
