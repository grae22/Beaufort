using Beaufort;

namespace Components
{
  class HighRpmEngine : BaseComponent, IEngine
  {
    public int Speed { get; private set; } = 10000;
  }
}
