using Beaufort;

namespace TestComponents
{
  internal class LowRpmEngine : BaseComponent, IEngine
  {
    public int Speed { get; } = 1500;

    public override void Update(ushort deltaTimeMs)
    {
    }
  }
}