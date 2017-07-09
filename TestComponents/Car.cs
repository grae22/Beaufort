using Beaufort;

namespace TestComponents
{
  class Car : BaseComponent, ICar
  {
    public IEngine Engine { get; set; }
    public IEngine Engine2 { get; set; }

    public double SpeedKph { get; private set; }

    public override void Update( ushort deltaTimeMs )
    {
      if( Engine != null )
      {
        SpeedKph += deltaTimeMs * 0.0001 * Engine.Speed;
      }
    }
  }
}
