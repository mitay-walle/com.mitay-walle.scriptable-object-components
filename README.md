# Unity3d ScriptableObject components model
Allow to compose CSharp plain classes at ScriptableObject, with SerializeReference, and use it with similar API as GameObject/Component such as:
- AddComponent<T>()
- AddComponent(T)
- GetComponent<T>()
- TryGetComponent<T>(out T)
- RemoveComponent<T>()
- RemoveComponent(T)
