using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Beaufort.Input
{
  public class DiscreteInput : BaseComponent,
                               IInput<byte>,
                               IStateBasedValue<byte>
  {
    //-------------------------------------------------------------------------

    public byte Value { get; private set; }

    public IReadOnlyDictionary<byte, string> StateNamesByValue { get; private set; }

    Dictionary<byte, string> _StateNamesByValue = new Dictionary<byte, string>();
    byte DefaultValue;

    //-------------------------------------------------------------------------

    public DiscreteInput()
    {
      StateNamesByValue = new ReadOnlyDictionary<byte, string>( _StateNamesByValue );
    }

    // BaseComponent ==========================================================

    public override void Configure()
    {
      if( ValueStore.Exists( "States" ) )
      {
        var states = ValueStore.GetValue<Dictionary<byte, string>>( "States", null );

        foreach( KeyValuePair<byte, string> state in states )
        {
          AddState( state.Key, state.Value );
        }
      }
    }

    // IInput =================================================================

    public void UpdateValue( object value )
    {
      ValidateValue( value );

      Value = (byte)value;
    }

    // IStateBasedValue =======================================================

    public void AddState( byte value, string name )
    {
      ValidateState( value, name );

      _StateNamesByValue.Add( value, name );

      ApplyFirstValueIfCurrentValueIsInvalid();
    }

    //-------------------------------------------------------------------------

    public void RemoveState( byte value )
    {
      _StateNamesByValue.Remove( value );
    }

    //-------------------------------------------------------------------------

    public void RemoveAllStates()
    {
      _StateNamesByValue.Clear();
    }

    //-------------------------------------------------------------------------

    public IReadOnlyDictionary<byte, string> GetStates()
    {
      return StateNamesByValue;
    }

    //=========================================================================

    void ValidateState( byte value, string name )
    {
      ValidateStateValueIsUnique( value );
      ValidateStateNameIsUnique( name );
    }

    //-------------------------------------------------------------------------

    void ValidateStateValueIsUnique( byte value )
    {
      if( _StateNamesByValue.ContainsKey( value ) )
      {
        throw new ArgumentException(
          string.Format(
            "State value not unique for input '{0}', value '{1}' isn't unique.",
            Name,
            value ) );
      }
    }

    //-------------------------------------------------------------------------

    void ValidateStateNameIsUnique( string name )
    {
      if( _StateNamesByValue.ContainsValue( name ) )
      {
        throw new ArgumentException(
          string.Format(
            "State name is not unique for input '{0}', name '{1}' isn't unique.",
            Name,
            name ) );
      }
    }

    //-------------------------------------------------------------------------

    void ValidateValueType( object value )
    {
      if( value.GetType() != typeof( byte ) )
      {
        throw new ArgumentException(
          string.Format(
            "Value is of incorrect type '{0}'.",
            value.GetType().FullName ) );
      }
    }

    //-------------------------------------------------------------------------

    void ValidateValue( object value )
    {
      ValidateValueType( value );

      if( StateNamesByValue.ContainsKey( (byte)value ) == false )
      {
        throw new ArgumentException(
          string.Format(
            "Value '{0}' does not represent a known state.",
            value ) );
      }
    }

    //-------------------------------------------------------------------------

    void PopulateValues( Tuple<byte, string>[] stateNamesByValue )
    {
      _StateNamesByValue.Clear();

      foreach( var value in stateNamesByValue )
      {
        _StateNamesByValue.Add( value.Item1, value.Item2 );
      }

      DefaultValue = stateNamesByValue[ 0 ].Item1;
    }

    //-------------------------------------------------------------------------

    void ApplyFirstValueIfCurrentValueIsInvalid()
    {
      if( _StateNamesByValue.ContainsKey( Value ) )
      {
        return;
      }

      var enumerator = _StateNamesByValue.Keys.GetEnumerator();

      while( enumerator.MoveNext() )
      {
        Value = enumerator.Current;
      }
    }

    //-------------------------------------------------------------------------
  }
}
