using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Beaufort.Input
{
  public class DiscreteInput : BaseComponent, IInput<byte>
  {
    //-------------------------------------------------------------------------

    const int MIN_STATE_COUNT = 2;

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
        var states = ValueStore.GetValue<Tuple<byte, string>[]>( "States", null );

        SetStates( states );
      }
    }

    // IInput =================================================================

    public void UpdateValue( object value )
    {
      ValidateValue( value );

      Value = (byte)value;
    }

    //=========================================================================

    public void SetStates( Tuple<byte, string>[] stateNamesByValue )
    {
      ValidateStates( stateNamesByValue );
      PopulateValues( stateNamesByValue );
      ApplyDefaultState();
    }

    //-------------------------------------------------------------------------

    void ValidateStates( Tuple<byte, string>[] stateNamesByValue )
    {
      ValidateStateCount( stateNamesByValue.Length );
      ValidateStateValuesAreUnique( stateNamesByValue );
      ValidateStateNamesAreUnique( stateNamesByValue );
    }

    //-------------------------------------------------------------------------

    void ValidateStateCount( int count )
    {
      if( count < MIN_STATE_COUNT )
      {
        throw new ArgumentException(
          string.Format(
            "Too few states for input '{0}', at least 2 are required.",
            Name ) );
      }
    }

    //-------------------------------------------------------------------------

    void ValidateStateValuesAreUnique( Tuple<byte, string>[] stateNamesByValue )
    {
      var values = new List<byte>();

      foreach( var state in stateNamesByValue )
      {
        byte value = state.Item1;

        if( values.Contains( value ) )
        {
          throw new ArgumentException(
            string.Format(
              "State values not unique for input '{0}', value '{1}' isn't unique.",
              Name,
              value ),
            nameof( stateNamesByValue ) );
        }

        values.Add( value );
      }
    }

    //-------------------------------------------------------------------------

    void ValidateStateNamesAreUnique( Tuple<byte, string>[] stateNamesByValue )
    {
      var names = new List<string>();

      foreach( var state in stateNamesByValue )
      {
        string name = state.Item2;

        if( names.Contains( name ) )
        {
          throw new ArgumentException(
            string.Format(
              "State names not unique for input '{0}', name '{1}' isn't unique.",
              Name,
              name ),
            nameof( stateNamesByValue ) );
        }

        names.Add( name );
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

    void ApplyDefaultState()
    {
      Value = DefaultValue;
    }

    //-------------------------------------------------------------------------
  }
}
