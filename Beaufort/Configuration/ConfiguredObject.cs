namespace Beaufort.Configuration
{
  public abstract class ConfiguredObject : IConfiguredObject
  {
    //-------------------------------------------------------------------------

    IValueStore ValueStore;

    //-------------------------------------------------------------------------

    public void Configure()
    {
      Configure( ValueStore );
    }

    // IConfiguredObject ======================================================

    public string GetConfigurationData()
    {
      return ValueStore.Serialise();
    }

    //-------------------------------------------------------------------------

    public virtual void Configure( IValueStore valueStore ) { }

    //=========================================================================
  }
}
