using Beaufort.Input;

namespace TestComponents
{
  internal interface ICar
  {
    IEngine Engine { set; }
    IIgnitionSwitch Ignition { set; }

    double SpeedKph { get; }
  }
}