using Beaufort;

namespace Components
{
  class LowRpmEngine : IComponent, IEngine
  {
    public int Speed { get; private set; } = 1500;
  }
}
