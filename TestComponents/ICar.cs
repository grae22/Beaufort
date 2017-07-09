using Beaufort.Input;

namespace TestComponents
{
  interface ICar
  {
    IEngine Engine { set; }
    IInput<byte> Ignition { set; }

    double SpeedKph { get; }
  }
}
