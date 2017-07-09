using System;
using Beaufort.Input;

namespace InputComponents
{
  public class BinarySwitch : DiscreteInput
  {
    //-------------------------------------------------------------------------

    public BinarySwitch()
    {
      SetStates(
        new Tuple<byte, string>[]
        {
          new Tuple<byte, string>( 0, "Off" ),
          new Tuple<byte, string>( 1, "On" )
        }
      );
    }

    //-------------------------------------------------------------------------
  }
}
