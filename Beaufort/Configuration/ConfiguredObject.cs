namespace Beaufort.Configuration
{
  public abstract class ConfiguredObject : IConfiguredObject
  {
    //-------------------------------------------------------------------------

    IValueStore ValueStore;

    //-------------------------------------------------------------------------

    public ConfiguredObject()
    {

    }

    //-------------------------------------------------------------------------

    public void Configure()
    {
      Configure( ValueStore );
    }

    //-------------------------------------------------------------------------

    public virtual void Configure( IValueStore valueStore ) { }

    //-------------------------------------------------------------------------
  }
}
