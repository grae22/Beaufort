namespace Beaufort
{
  public interface IComponent
  {
    //-------------------------------------------------------------------------

    // Component instance's name.
    string Name { get; }

    //-------------------------------------------------------------------------

    // Attempts to set the instance's name, returns 'false' on error.
    bool SetName( string name );

    //-------------------------------------------------------------------------
    
    // When called, the component should perform all necessary logic and update
    // its internal state as well as any output properties.
    void Update( ushort deltaTimeMs );

    //-------------------------------------------------------------------------
  }
}
