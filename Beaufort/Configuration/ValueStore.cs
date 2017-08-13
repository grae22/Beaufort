using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Beaufort.Configuration
{
  internal class ValueStore : IValueStore
  {
    //-------------------------------------------------------------------------

    private Dictionary<string, object> _valuesByKey = new Dictionary<string, object>();

    // IValueStore ============================================================

    public bool Exists(string key)
    {
      return _valuesByKey.ContainsKey(key);
    }

    //-------------------------------------------------------------------------

    public void SetValue<T>(string key, T value)
    {
      if (Exists(key))
      {
        ThrowExceptionIfTypeConversionFails(value, _valuesByKey[key].GetType());

        _valuesByKey[key] = value;
      }
      else
      {
        _valuesByKey.Add(key, value);
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

      ThrowExceptionIfTypeConversionFails(_valuesByKey[key], typeof(T));

      return (T)Convert.ChangeType(_valuesByKey[key], typeof(T));
    }

    //-------------------------------------------------------------------------

    public string Serialise()
    {
      return JsonConvert.SerializeObject(_valuesByKey);
    }

    //-------------------------------------------------------------------------

    public void Deserialise(string serialisedStore)
    {
      _valuesByKey =
        JsonConvert.DeserializeObject<Dictionary<string, object>>(
          serialisedStore);
    }

    //=========================================================================

    private static void ThrowExceptionIfTypeConversionFails(object value, Type required)
    {
      try
      {
        Convert.ChangeType(value, required);
      }
      catch (Exception ex)
      {
        throw new InvalidCastException(
          $"Cannot convert value '{value}' of type '{value.GetType().Name}' to required type '{required.Name}'.",
          ex);
      }
    }

    //-------------------------------------------------------------------------
  }
}