﻿using System.Collections.Generic;

namespace Beaufort
{
  public interface IStateBasedValue<T>
  {
    // Adds a state value/name. Value & name must be unique.
    void AddState( T value, string name );

    // Removes a state using its value.
    void RemoveState( T value );

    // Remove all states.
    void RemoveAllStates();

    // Returns all states as value/name tuples.
    IReadOnlyDictionary<T, string> GetStates();
  }
}
