namespace Beaufort.Configuration
{
  public interface IValueStore
  {
    // Returns true if the value exists.
    bool Exists( string key );

    // Retrieves the value.
    // Throws exception if type conversion (to passed in object's type) fails.
    T GetValue<T>( string key );
  }
}
