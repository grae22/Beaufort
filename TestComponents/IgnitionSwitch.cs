using Beaufort.Input;

namespace TestComponents
{
  internal class IgnitionSwitch : DiscreteInput, IIgnitionSwitch
  {
    public bool IsOffSelected { get; set; }
    public bool IsStartSelected { get; set; }
    public bool IsOnSelected { get; set; }

    public IgnitionSwitch()
    {
      AddState((byte)0, "Off");
      AddState((byte)1, "Start");
      AddState((byte)2, "On");
    }

    public override void Update(ushort deltaTimeMs)
    {
      IsOffSelected = Value == 0;
      IsStartSelected = Value == 1;
      IsOnSelected = Value == 2;
    }
  }
}
