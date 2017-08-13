using System.Runtime.CompilerServices;
using Beaufort;
using Beaufort.Input;

namespace TestComponents
{
  class Car : BaseComponent, ICar
  {
    public IEngine Engine { get; set; }
    public IInput<byte> Ignition { get; set; }

    public double SpeedKph { get; private set; }

    private byte _ignitionStateStart;
    private byte _ignitionStateOn;
    private bool _isEngineRunning;

    public override void Configure()
    {
      _ignitionStateStart = Configuration.GetValue("IgnitionStateStart", (byte)0);
      _ignitionStateOn = Configuration.GetValue("IgnitionStateOn", (byte)0);
    }

    protected override void UpdateConfigurationData()
    {
      Configuration.SetValue("IgnitionStateStart", _ignitionStateStart);
      Configuration.SetValue("IgnitionStateOn", _ignitionStateOn);
    }

    public override void Update(ushort deltaTimeMs)
    {
      if (Ignition == null)
      {
        return;
      }

      if (Ignition.Value == 0)
      {
        _isEngineRunning = false;
      }
      else if (Ignition.Value == _ignitionStateStart)
      {
        _isEngineRunning = true;
      }
      else if (Engine != null &&
               _isEngineRunning &&
               Ignition.Value == _ignitionStateOn)
      {
        SpeedKph += deltaTimeMs * 0.0001 * Engine.Speed;
      }
    }
  }
}