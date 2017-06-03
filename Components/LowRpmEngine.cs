using Beaufort;

namespace Components
{
  class LowRpmEngine : BaseComponent, IEngine
  {
    public int Speed { get; private set; } = 1500;
  }
}
