namespace Beaufort.Configuration
{
  interface IConfiguredObject
  {
    void Configure( IValueStore valueStore );
  }
}
