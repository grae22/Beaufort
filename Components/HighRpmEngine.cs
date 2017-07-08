using Beaufort;

namespace Components
{
  class HighRpmEngine : BaseComponent, IEngine
  {
    public int Speed { get; private set; } = 10000;

    public override void Update( ushort deltaTimeMs )
    {

    }
  }
}
