using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Beaufort.Configuration
{
  class ValueStore : IValueStore
  {
    //-------------------------------------------------------------------------

    Dictionary<string, object> ValuesByKey = new Dictionary<string, object>();

    // IValueStore ============================================================

    public bool Exists(string key)
    {
      return ValuesByKey.ContainsKey(key);
    }

    //-------------------------------------------------------------------------

    public void SetValue<T>(string key, T value)
    {
      if (Exists(key))
      {
        ThrowExceptionIfTypeConversionFails(value, ValuesByKey[key].GetType());

        ValuesByKey[key] = value;
      }
      else
      {
        ValuesByKey.Add(key, value);
      }
    }

    //-------------------------------------------------------------------------

    public T GetValue<T>(string key,
                         T defaultValue = default(T))
    {
      if (Exists(key) == false)
      {
        SetValue(key, defaultValue);
        return defaultValue;
      }

      ThrowExceptionIfTypeConversionFails(ValuesByKey[key], typeof(T));

      return (T)Convert.ChangeType(ValuesByKey[key], typeof(T));
    }

    //-------------------------------------------------------------------------

    public string Serialise()
    {
      return JsonConvert.SerializeObject(ValuesByKey);
    }

    //-------------------------------------------------------------------------

    public void Deserialise(string serialisedStore)
    {
      ValuesByKey =
        JsonConvert.DeserializeObject<Dictionary<string, object>>(
          serialisedStore);
    }

    //=========================================================================

    void ThrowExceptionIfTypeConversionFails(object value, Type required)
    {
      try
      {
        Convert.ChangeType(value, required);
      }
      catch (Exception ex)
      {
        throw new InvalidCastException(
          $"Cannot convert value '{value}' to required type '{required.Name}'.",
          ex);
      }
    }

    //-------------------------------------------------------------------------
  }
}