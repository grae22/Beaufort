namespace Beaufort.Configuration
{
  interface IConfiguredObject
  {
    // Returns configuration data in string form.
    string GetConfigurationData();

    // Called so object can configure itself.
    void Configure( IValueStore valueStore );
  }
}
