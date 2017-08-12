using Beaufort.Input;

namespace InputComponents
{
  public class BinarySwitch : DiscreteInput
  {
    //-------------------------------------------------------------------------

    public BinarySwitch()
    {
      AddState(0, "Off");
      AddState(1, "On");
    }

    //-------------------------------------------------------------------------
  }
}