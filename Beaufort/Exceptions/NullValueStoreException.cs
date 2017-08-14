using System;

namespace Beaufort.Exceptions
{
  internal class NullValueStoreException : ApplicationException
  {
    //-------------------------------------------------------------------------

    public NullValueStoreException(IComponent component)
    :
      base($"Null value-store in component '{component.Name}'.")
    {
    }

    //-------------------------------------------------------------------------
  }
}