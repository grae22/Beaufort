using Beaufort.Configuration;

namespace Beaufort
{
  public abstract class BaseComponent : IComponent, IConfiguredObject
  {
    // IComponent =============================================================

    public string Name { get; private set; } = "Unnamed Component";

    //-------------------------------------------------------------------------

    public bool SetName( string name )
    {
      if( name.Length > 0 )
      {
        Name = name;

        return true;
      }

      return false;
    }

    //-------------------------------------------------------------------------

    public virtual void Update( ushort deltaTimeMs ) { }

    // IConfiguredObject =====================================================

    public virtual void Configure( IValueStore valueStore ) { }

    //-------------------------------------------------------------------------
  }
}
