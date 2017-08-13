using Beaufort.Configuration;
using Beaufort.Exceptions;

namespace Beaufort
{
  public abstract class BaseComponent : IComponent, IConfiguredObject
  {
    //-------------------------------------------------------------------------

    protected IValueStore Configuration { get; private set; }

    // IComponent =============================================================

    public string Name { get; private set; } = "Unnamed Component";

    //-------------------------------------------------------------------------

    public bool SetName(string name)
    {
      if (name.Length == 0)
      {
        return false;
      }

      Name = name;

      return true;
    }

    //-------------------------------------------------------------------------

    // Default implementation does nothing.

    public virtual void Update(ushort deltaTimeMs)
    {
    }

    // IConfiguredObject ======================================================

    public void InjectValueStore(IValueStore valueStore)
    {
      Configuration = valueStore;
    }

    //-------------------------------------------------------------------------

    public IValueStore GetValueStore()
    {
      return Configuration;
    }

    //-------------------------------------------------------------------------

    public virtual string GetConfigurationData()
    {
      UpdateConfigurationData();

      return Configuration.Serialise();
    }

    //-------------------------------------------------------------------------

    // Default implementation does nothing.

    public virtual void Configure()
    {
      ThrowExceptionIfNoValueStore();
    }

    //=========================================================================

    // Default implementation does nothing.

    protected virtual void UpdateConfigurationData()
    {
      ThrowExceptionIfNoValueStore();
    }

    //-------------------------------------------------------------------------

    private void ThrowExceptionIfNoValueStore()
    {
      if (Configuration == null)
      {
        throw new NullValueStoreException(this);
      }
    }

    //-------------------------------------------------------------------------
  }
}