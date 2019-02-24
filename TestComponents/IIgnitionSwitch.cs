using Beaufort;

namespace TestComponents
{
  internal interface IIgnitionSwitch : IComponent
  {
    bool IsOffSelected { get; }
    bool IsStartSelected { get; }
    bool IsOnSelected { get; }
  }
}
