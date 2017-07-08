using Beaufort;

namespace Components
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
        SpeedKph += deltaTimeMs * 0.001 * Engine.Speed;
      }
    }
  }
}
