using System;
using System.Collections.Generic;

namespace Beaufort.Input
{
  public class DiscreteInput : BaseComponent,
    IInput<byte>,
    IStateBasedValue<byte>
  {
    //-------------------------------------------------------------------------

    public byte Value { get; private set; }

    Dictionary<byte, string> StateNamesByValue = new Dictionary<byte, string>();

    // BaseComponent ==========================================================

    public override void Configure()
    {
      if (ValueStore.Exists("States"))
      {
        var states = ValueStore.GetValue<Dictionary<byte, string>>("States", null);

        foreach (KeyValuePair<byte, string> state in states)
        {
          AddState(state.Key, state.Value);
        }
      }
    }

    // IInput =================================================================

    public void UpdateValue(object value)
    {
      ValidateValue(value);

      Value = (byte) value;
    }

    // IStateBasedValue =======================================================

    public void AddState(byte value, string name)
    {
      ValidateState(value, name);

      StateNamesByValue.Add(value, name);

      ApplyFirstValueIfCurrentValueIsInvalid();
    }

    //-------------------------------------------------------------------------

    public void RemoveState(byte value)
    {
      StateNamesByValue.Remove(value);
    }

    //-------------------------------------------------------------------------

    public void RemoveAllStates()
    {
      StateNamesByValue.Clear();
    }

    //-------------------------------------------------------------------------

    public IReadOnlyDictionary<byte, string> GetStates()
    {
      return StateNamesByValue;
    }

    //=========================================================================

    void ValidateState(byte value, string name)
    {
      ValidateStateValueIsUnique(value);
      ValidateStateNameIsUnique(name);
    }

    //-------------------------------------------------------------------------

    void ValidateStateValueIsUnique(byte value)
    {
      if (StateNamesByValue.ContainsKey(value))
      {
        throw new ArgumentException(
          string.Format(
            "State value not unique for input '{0}', value '{1}' isn't unique.",
            Name,
            value));
      }
    }

    //-------------------------------------------------------------------------

    void ValidateStateNameIsUnique(string name)
    {
      if (StateNamesByValue.ContainsValue(name))
      {
        throw new ArgumentException(
          string.Format(
            "State name is not unique for input '{0}', name '{1}' isn't unique.",
            Name,
            name));
      }
    }

    //-------------------------------------------------------------------------

    void ValidateValueType(object value)
    {
      if (value.GetType() != typeof(byte))
      {
        throw new ArgumentException(
          string.Format(
            "Value is of incorrect type '{0}'.",
            value.GetType().FullName));
      }
    }

    //-------------------------------------------------------------------------

    void ValidateValue(object value)
    {
      ValidateValueType(value);

      if (StateNamesByValue.ContainsKey((byte) value) == false)
      {
        throw new ArgumentException(
          string.Format(
            "Value '{0}' does not represent a known state.",
            value));
      }
    }

    //-------------------------------------------------------------------------

    void ApplyFirstValueIfCurrentValueIsInvalid()
    {
      if (StateNamesByValue.ContainsKey(Value))
      {
        return;
      }

      var enumerator = StateNamesByValue.Keys.GetEnumerator();

      while (enumerator.MoveNext())
      {
        Value = enumerator.Current;
      }
    }

    //-------------------------------------------------------------------------
  }
}