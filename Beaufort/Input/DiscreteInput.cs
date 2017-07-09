using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Beaufort.Input
{
  public class DiscreteInput : BaseComponent, IInput<byte>
  {
    //-------------------------------------------------------------------------

    public byte Value { get; private set; }

    public IReadOnlyDictionary<byte, string> StateNamesByValue { get; private set; }

    Dictionary<byte, string> _StateNamesByValue = new Dictionary<byte, string>();

    //-------------------------------------------------------------------------

    public DiscreteInput( Tuple<byte, string>[] stateNamesByValue )
    {
      StateNamesByValue = new ReadOnlyDictionary<byte, string>( _StateNamesByValue );

      PopulateValues( stateNamesByValue );
    }

    //-------------------------------------------------------------------------

    void PopulateValues( Tuple<byte, string>[] stateNamesByValue )
    {
      _StateNamesByValue.Clear();

      foreach( var value in stateNamesByValue )
      {
        _StateNamesByValue.Add( value.Item1, value.Item2 );
      }
    }

    //-------------------------------------------------------------------------
  }
}
