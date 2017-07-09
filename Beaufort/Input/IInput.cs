namespace Beaufort.Input
{
  interface IInput<T> : IComponent
  {
    T Value { get; }
  }
}
