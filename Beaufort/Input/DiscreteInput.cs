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

    private readonly Dictionary<byte, string> _stateNamesByValue = new Dictionary<byte, string>();

    // BaseComponent ==========================================================

    public override void Configure()
    {
      ApplyStatesFromConfiguartion();
    }

    //-------------------------------------------------------------------------

    protected override void UpdateConfigurationData()
    {
      UpdateConfigurationWithStates();
    }

    // IInput =================================================================

    public void UpdateValue(object value)
    {
      ValidateValue(value);

      Value = (byte)value;
    }

    // IStateBasedValue =======================================================

    public void AddState(byte value, string name)
    {
      ValidateState(value, name);

      _stateNamesByValue.Add(value, name);

      ApplyFirstValueIfCurrentValueIsInvalid();
    }

    //-------------------------------------------------------------------------

    public void RemoveState(byte value)
    {
      _stateNamesByValue.Remove(value);
    }

    //-------------------------------------------------------------------------

    public void RemoveAllStates()
    {
      _stateNamesByValue.Clear();
    }

    //-------------------------------------------------------------------------

    public IReadOnlyDictionary<byte, string> GetStates()
    {
      return _stateNamesByValue;
    }

    //=========================================================================

    private void ValidateState(byte value, string name)
    {
      ValidateStateValueIsUnique(value);
      ValidateStateNameIsUnique(name);
    }

    //-------------------------------------------------------------------------

    private void ValidateStateValueIsUnique(byte value)
    {
      if (_stateNamesByValue.ContainsKey(value))
      {
        throw new ArgumentException(
          $"State value not unique for input '{Name}', value '{value}' isn't unique.");
      }
    }

    //-------------------------------------------------------------------------

    private void ValidateStateNameIsUnique(string name)
    {
      if (_stateNamesByValue.ContainsValue(name))
      {
        throw new ArgumentException(
          $"State name is not unique for input '{Name}', name '{name}' isn't unique.");
      }
    }

    //-------------------------------------------------------------------------

    private void ValidateValueType(object value)
    {
      if (value.GetType() != typeof(byte))
      {
        throw new ArgumentException(
          $"Value is of incorrect type '{value.GetType().FullName}'.");
      }
    }

    //-------------------------------------------------------------------------

    private void ValidateValue(object value)
    {
      ValidateValueType(value);

      if (_stateNamesByValue.ContainsKey((byte)value) == false)
      {
        throw new ArgumentException(
          $"Value '{value}' does not represent a known state.");
      }
    }

    //-------------------------------------------------------------------------

    private void ApplyFirstValueIfCurrentValueIsInvalid()
    {
      if (_stateNamesByValue.ContainsKey(Value))
      {
        return;
      }

      var enumerator = _stateNamesByValue.Keys.GetEnumerator();

      while (enumerator.MoveNext())
      {
        Value = enumerator.Current;
      }
    }

    //-------------------------------------------------------------------------

    private void ApplyStatesFromConfiguartion()
    {
      _stateNamesByValue.Clear();

      if (Configuration.Exists("States"))
      {
        var states = Configuration.GetValue<Dictionary<byte, string>>("States", null);

        foreach (KeyValuePair<byte, string> state in states)
        {
          AddState(state.Key, state.Value);
        }
      }
    }

    //-------------------------------------------------------------------------

    private void UpdateConfigurationWithStates()
    {
      var states = Configuration.GetValue("States", new Dictionary<byte, string>());
      states.Clear();

      foreach (var state in _stateNamesByValue)
      {
        states.Add(state.Key, state.Value);
      }
    }

    //-------------------------------------------------------------------------
  }
}