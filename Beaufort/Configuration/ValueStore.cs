using System;
using System.Collections.Generic;

namespace Beaufort.Configuration
{
  class ValueStore : IValueStore
  {
    //-------------------------------------------------------------------------

    Dictionary<string, object> ValuesByKey = new Dictionary<string, object>();

    // IValueStore ============================================================

    public bool Exists( string key )
    {
      return ValuesByKey.ContainsKey( key );
    }

    //-------------------------------------------------------------------------

    public void SetValue<T>( string key, T value )
    {
      if( Exists( key ) )
      {
        CheckProvidedTypeMatchesKeyValueType( key, typeof( T ) );

        ValuesByKey[ key ] = value;
      }
      else
      {
        ValuesByKey.Add( key, value );
      }
    }

    //-------------------------------------------------------------------------

    public T GetValue<T>( string key,
                          T defaultValue = default( T ) )
    {
      if( Exists( key ) == false )
      {
        return defaultValue;
      }

      CheckProvidedTypeMatchesKeyValueType( key, typeof( T ) );

      return (T)ValuesByKey[ key ];
    }

    //=========================================================================

    void CheckProvidedTypeMatchesKeyValueType( string key, Type provided )
    {
      if( Exists( key ) == false )
      {
        return;
      }

      Type required = ValuesByKey[ key ].GetType();

      if( provided == required )
      {
        return;
      }

      throw new InvalidCastException(
        string.Format(
          "Incorrect type provided '{0}' for key '{1}', required '{2}'.",
          provided.Name,
          key,
          required.Name ) );
    }

    //-------------------------------------------------------------------------
  }
}
