using System;
using System.Collections.Generic;
using Beaufort.Configuration;

namespace Beaufort
{
  public class ComponentContainer : IComponentContainer
  {
    //-------------------------------------------------------------------------

    public string Name { get; }

    //-------------------------------------------------------------------------

    private readonly List<IComponent> _components = new List<IComponent>();

    //-------------------------------------------------------------------------

    public ComponentContainer(string name)
    {
      Name = name;
    }

    // IComponentContainerInfo ================================================

    public IReadOnlyCollection<IComponent> Components
    {
      get
      {
        return _components.AsReadOnly();
      }
    }

    //=========================================================================

    public IComponent AddComponent(string fullTypeName,
                                   string instanceName)
    {
      IComponent newComponent;

      try
      {
        newComponent = InstantiateComponent(fullTypeName, instanceName);
      }
      catch (ArgumentException ex)
      {
        throw new TypeLoadException(
          $"Failed to instantiate component of type \"{fullTypeName}\" with name \"{instanceName}\".",
          ex);
      }

      InitialiseComponent(newComponent, instanceName);

      _components.Add(newComponent);

      return newComponent;
    }

    //-------------------------------------------------------------------------

    public void Update(ushort deltaTimeMs)
    {
      UpdateComponents(deltaTimeMs);
    }

    //-------------------------------------------------------------------------

    private IComponent InstantiateComponent(string fullTypeName,
                                            string instanceName)
    {
      object newObject;

      try
      {
        Type type = Type.GetType(fullTypeName, true);

        newObject = Activator.CreateInstance(type);
      }
      catch (TypeLoadException ex)
      {
        throw new ArgumentException(
          $"Failed to instantiate object of type \"{fullTypeName}\" with name \"{instanceName}\".",
          nameof(fullTypeName),
          ex);
      }

      IComponent newComponent = newObject as IComponent;

      if (newComponent == null)
      {
        throw new ArgumentException(
          $"Failed to cast object of type \"{fullTypeName}\" with name \"{instanceName}\" to \"{typeof(IComparable).Name}\".",
          nameof(fullTypeName));
      }

      return newComponent;
    }

    //-------------------------------------------------------------------------

    private void InitialiseComponent(IComponent component, string componentName)
    {
      SetComponentName(component, componentName);
      InitialiseComponentValueStore(component);
    }

    //-------------------------------------------------------------------------

    private void SetComponentName(IComponent component, string name)
    {
      bool namedOk = component.SetName(name);

      if (namedOk == false)
      {
        throw new ArgumentException(
          $"Failed to name object of type \"{component.GetType().FullName}\" with name \"{name}\".",
          nameof(name));
      }
    }

    //-------------------------------------------------------------------------

    private static void InitialiseComponentValueStore(IComponent component)
    {
      var configuredObject = component as IConfiguredObject;

      configuredObject?.InjectValueStore(new ValueStore());
    }

    //-------------------------------------------------------------------------

    private void UpdateComponents(ushort deltaTimeMs)
    {
      _components.ForEach(c => c.Update(deltaTimeMs));
    }

    //-------------------------------------------------------------------------
  }
}