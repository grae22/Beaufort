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

    //-------------------------------------------------------------------------

    public void SetStates( Tuple<byte, string>[] stateNamesByValue )
    {
      ValidateStates( stateNamesByValue );
      PopulateValues( stateNamesByValue );
      ApplyDefaultState();
    }

    //-------------------------------------------------------------------------

    void ValidateStates( Tuple<byte, string>[] stateNamesByValue )
    {
      ValidateSufficientStateCount( stateNamesByValue.Length );
      ValidateStatesValuesAreUnique( stateNamesByValue );
      ValidateStatesNamesAreUnique( stateNamesByValue );
    }

    //-------------------------------------------------------------------------

    void ValidateSufficientStateCount( int count )
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

    void ValidateStatesValuesAreUnique( Tuple<byte, string>[] stateNamesByValue )
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

    void ValidateStatesNamesAreUnique( Tuple<byte, string>[] stateNamesByValue )
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
