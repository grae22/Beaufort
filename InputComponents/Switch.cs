using System;
using Beaufort.Input;

namespace InputComponents
{
  public class Switch : DiscreteInput
  {
    //-------------------------------------------------------------------------

    public Switch( Tuple<byte, string>[] stateNamesByValue )
    {
      SetStates( stateNamesByValue );
    }

    //-------------------------------------------------------------------------
  }
}
