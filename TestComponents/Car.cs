using Beaufort;
using Beaufort.Input;

namespace TestComponents
{
  class Car : BaseComponent, ICar
  {
    public IEngine Engine { get; set; }
    public IInput<byte> Ignition { get; set; }

    public double SpeedKph { get; private set; }

    public override void Update( ushort deltaTimeMs )
    {
      if( Engine != null &&
          Ignition?.Value > 0 )
      {
        SpeedKph += deltaTimeMs * 0.0001 * Engine.Speed;
      }
    }
  }
}
