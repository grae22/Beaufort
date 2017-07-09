namespace Beaufort.Input
{
  class DiscreteInput : BaseComponent, IInput<byte>
  {
    //-------------------------------------------------------------------------

    public byte Value { get; private set; }

    //-------------------------------------------------------------------------
  }
}
