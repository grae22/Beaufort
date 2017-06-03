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
  }
}
