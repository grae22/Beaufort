using Beaufort;

namespace Components
{
  class HighRpmEngine : IComponent, IEngine
  {
    public int Speed { get; private set; } = 10000;
  }
}
