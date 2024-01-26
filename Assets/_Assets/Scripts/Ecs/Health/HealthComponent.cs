using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Assets.Scripts.Ecs.Health
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct HealthComponent : IComponent, IDisposable
    {
        public int health;
        public GameObject gameObject;

        public void Dispose() => Object.Destroy(gameObject);
    }
}