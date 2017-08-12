using Beaufort.Configuration;
using Beaufort.Exceptions;

namespace Beaufort
{
  public abstract class BaseComponent : IComponent, IConfiguredObject
  {
    //-------------------------------------------------------------------------

    protected IValueStore ValueStore { get; private set; }

    // IComponent =============================================================

    public string Name { get; private set; } = "Unnamed Component";

    //-------------------------------------------------------------------------

    public bool SetName(string name)
    {
      if (name.Length > 0)
      {
        Name = name;

        return true;
      }

      return false;
    }

    //-------------------------------------------------------------------------

    // Default implementation does nothing.

    public virtual void Update(ushort deltaTimeMs)
    {
    }

    // IConfiguredObject ======================================================

    public void InjectValueStore(IValueStore valueStore)
    {
      ValueStore = valueStore;
    }

    //-------------------------------------------------------------------------

    public virtual string GetConfigurationData()
    {
      return ValueStore.Serialise();
    }

    //-------------------------------------------------------------------------

    // Default implementation does nothing.

    public virtual void Configure()
    {
      ThrowExceptionIfNoValueStore();
    }

    //=========================================================================

    void ThrowExceptionIfNoValueStore()
    {
      if (ValueStore == null)
      {
        throw new NullValueStoreException(this);
      }
    }

    //-------------------------------------------------------------------------
  }
}