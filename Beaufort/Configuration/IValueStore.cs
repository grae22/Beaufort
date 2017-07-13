namespace Beaufort.Configuration
{
  public interface IValueStore
  {
    // Returns true if the value exists.
    bool Exists( string key );

    // Sets a value.
    // Throws exception if value key already exists for value of a different type.
    void SetValue<T>( string key, T value );

    // Retrieves the value, returns the default-value if key isn't found.
    // Throws exception if value is of a type other than the requested type.
    T GetValue<T>( string key, T defaultValue );

    // Serialises the store to a string.
    string Serialise();

    // Deserialises the store from a string.
    void Deserialise( string serialisedStore );
  }
}
