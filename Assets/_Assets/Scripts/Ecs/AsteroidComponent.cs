using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs
{
    public struct AsteroidComponent : IComponent, IDisposable
    {
        public void Dispose()
        {
            Debug.Log("Dispose asteroid");
        }
    }
}