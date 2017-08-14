using Beaufort.Input;

namespace TestComponents
{
  internal interface ICar
  {
    IEngine Engine { set; }
    IInput<byte> Ignition { set; }

    double SpeedKph { get; }
  }
}