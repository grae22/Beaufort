using System.Collections.Generic;

namespace Beaufort
{
  public interface IComponentContainer
  {
    IReadOnlyCollection<IComponent> Components { get; }
  }
}