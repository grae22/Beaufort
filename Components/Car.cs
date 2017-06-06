using Beaufort;

namespace Components
{
  class Car : BaseComponent
  class Car : BaseComponent, ICar
  {
    public IEngine Engine { get; private set; }
  }
}
