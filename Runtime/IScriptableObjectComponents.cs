using System.Collections.Generic;

namespace Mitaywalle.ScriptableObjectComponents
{
    public interface IScriptableObjectComponents
    {
        List<IScriptableObjectComponent> Components { get;}
        void AddComponent<T>() where T : class, IScriptableObjectComponent, new();
        void AddComponent(IScriptableObjectComponent component);
        
        T GetComponent<T>() where T : class, IScriptableObjectComponent, new();
        bool TryGetComponent<T>(out T component) where T : class, IScriptableObjectComponent, new();
        
        void RemoveComponent<T>() where T : class, IScriptableObjectComponent, new();
        void RemoveComponent(IScriptableObjectComponent component);
    }
}