using Beaufort;

namespace Components
{
  class Car : BaseComponent, ICar
  {
    public IEngine Engine { private get; set; }
  }
}
