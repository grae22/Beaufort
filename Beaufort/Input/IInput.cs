namespace Beaufort.Input
{
  public interface IInput : IComponent
  {
    void UpdateValue(object value);
  }

  public interface IInput<T> : IInput
  {
    T Value { get; }
  }
}