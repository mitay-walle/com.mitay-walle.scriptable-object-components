using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mitaywalle.ScriptableObjectComponents.Samples.Scripts
{
    [CreateAssetMenu]
    public class Item : ScriptableObjectWithComponents
    {
        public override List<IScriptableObjectComponent> Components { get; protected set; } = new()
        {
            new Damageable(),
            new Variables(),
        };
    }

    [Serializable]
    public class Damageable : IScriptableObjectComponent
    {
        public Vector2Int Damage = new Vector2Int(5, 10);
        [Range(0,100)]public int CritChance = 30;
    }

    [Serializable]
    public class Variables : IScriptableObjectComponent
    {
        public List<string> Keys = new List<string> { "Durability","Count" };
        public List<float> Values = new List<float> { 100,3 };
    }
}