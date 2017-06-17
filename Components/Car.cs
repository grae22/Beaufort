using Beaufort;

namespace Components
{
  class Car : BaseComponent, ICar
  {
    public IEngine Engine { get; set; }
    public IEngine Engine2 { get; set; }
  }
}
