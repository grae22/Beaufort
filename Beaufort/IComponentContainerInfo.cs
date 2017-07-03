using System.Collections.Generic;

namespace Beaufort
{
  public interface IComponentContainerInfo
  {
    IReadOnlyCollection<IComponent> Components { get; }
  }
}
