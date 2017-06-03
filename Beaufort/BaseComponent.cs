namespace Beaufort
{
  public class BaseComponent : IComponent
  {
    //-------------------------------------------------------------------------

    public string Name { get; private set; }

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
  }
}
