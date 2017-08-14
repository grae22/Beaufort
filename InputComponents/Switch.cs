using Beaufort.Input;

namespace InputComponents
{
  public class Switch : DiscreteInput
  {
    //-------------------------------------------------------------------------

    public Switch()
    {
      AddState(0, "Off");
      AddState(1, "On");
    }

    //-------------------------------------------------------------------------
  }
}