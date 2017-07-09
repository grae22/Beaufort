using System;
using System.Linq;
using System.Collections.Generic;

namespace Beaufort
{
  public class ComponentContainer : IComponentContainer
  {
    //-------------------------------------------------------------------------

    public string Name { get; private set; }

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
      IComponent newComponent;
      
      try
      {
        newComponent = InstantiateComponent( fullTypeName, instanceName );
      }
      catch( ArgumentException ex )
      {
        throw new TypeLoadException(
          string.Format(
            "Failed to instantiate component of type \"{0}\" with name \"{1}\".",
            fullTypeName,
            instanceName ),
          ex );
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
    
    public void Update( ushort deltaTimeMs )
    {
      UpdateComponents( deltaTimeMs );
    }

    //-------------------------------------------------------------------------

    IComponent InstantiateComponent( string fullTypeName,
                                     string instanceName )
    {
      object newObject;

      try
      {
        Type type = Type.GetType( fullTypeName, true );

        newObject = Activator.CreateInstance( type );
      }
      catch( TypeLoadException ex )
      {
        throw new ArgumentException(
          string.Format(
            "Failed to instantiate object of type \"{0}\" with name \"{1}\".",
            fullTypeName,
            instanceName ),
          nameof( fullTypeName ),
          ex );
      }

      IComponent newComponent = newObject as IComponent;

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

    void UpdateComponents( ushort deltaTimeMs )
    {
      _Components.ForEach( c => c.Update( deltaTimeMs ) );
    }

    //-------------------------------------------------------------------------
  }
}
