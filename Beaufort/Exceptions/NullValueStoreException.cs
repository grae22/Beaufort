using System;

namespace Beaufort.Exceptions
{
  class NullValueStoreException : ApplicationException
  {
    //-------------------------------------------------------------------------

    public NullValueStoreException( IComponent component )
    :
      base(
        string.Format(
          "Null value-store in component '{0}'.",
          component.Name ) )
    {
      
    }

    //-------------------------------------------------------------------------
  }
}
