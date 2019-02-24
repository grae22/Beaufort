using Beaufort;

namespace TestComponents
{
  internal class Car : BaseComponent, ICar
  {
    public IEngine Engine { get; set; }
    public IIgnitionSwitch Ignition { get; set; }

    public double SpeedKph { get; private set; }

    private bool _isEngineRunning;
    
    public override void Update(ushort deltaTimeMs)
    {
      if (Ignition == null)
      {
        return;
      }

      if (Ignition.IsOffSelected)
      {
        _isEngineRunning = false;
      }
      else if (Ignition.IsStartSelected)
      {
        _isEngineRunning = true;
      }
      else if (Engine != null &&
               _isEngineRunning &&
               Ignition.IsOnSelected)
      {
        SpeedKph += deltaTimeMs * 0.0001 * Engine.Speed;
      }
    }
  }
}