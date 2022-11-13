using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mitaywalle.ScriptableObjectComponents
{
    [CreateAssetMenu]
    public class ScriptableObjectWithComponents : ScriptableObject, IScriptableObjectComponents
    {
        [field: SerializeReference] public virtual List<IScriptableObjectComponent> Components { get; protected set; }

        public void AddComponent<T>() where T : class, IScriptableObjectComponent, new() => Components.Add(new T());

        [Button]
        public void AddComponent(IScriptableObjectComponent component)
        {
            if (!Components.Contains(component))
            {
                Components.Add(component);
                if (component is IScriptableObjectComponentOnAdd addComponent)
                {
                    addComponent.OnAdd(this);
                }
            }
        }

        public T GetComponent<T>() where T : class, IScriptableObjectComponent, new()
        {
            return (T) Components.Find(component => component is T);
        }

        public bool TryGetComponent<T>(out T component) where T : class, IScriptableObjectComponent, new()
        {
            var found = Components.Find(soComponent => soComponent is T);
            if (found == null)
            {
                component = null;
                return false;
            }

            component = found as T;
            return true;
        }

        public void RemoveComponent<T>() where T : class, IScriptableObjectComponent, new()
        {
            if (TryGetComponent<T>(out T found))
            {
                RemoveComponent(found);
            }
        }

        public void RemoveComponent(IScriptableObjectComponent component)
        {
            if (Components.Contains(component))
            {
                Components.Remove(component);
            }
        }
    }
}