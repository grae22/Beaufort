namespace Beaufort.Input
{
  public interface IInput<T> : IComponent
  {
    T Value { get; }
  }
}
