namespace Beaufort.Configuration
{
  public interface IConfiguredObject
  {
    // Injects an IValueStore that can contain configuration data.
    void InjectValueStore(IValueStore valueStore);

    // Returns the component's value-store.
    IValueStore GetValueStore();

    // Returns configuration data in string form.
    // TODO: Remove this - made redundant by GetValueStore().
    string GetConfigurationData();

    // Component will configure or throw an exception if some UNEXPECTED condition
    // prevents this (NOTE: exceptions should not be used where flow-control is
    // appropriate). The assumption here is that a component will configure unless
    // something fatal happens (e.g. missing configuration data due to corruption),
    // hence the lack of a boolean return.
    void Configure();
  }
}