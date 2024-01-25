using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Health
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HealthSystem))]
    public class HealthSystem : UpdateSystem
    {
        private Filter _asteroid;
        private Filter _health;

        public override void OnAwake()
        {
            _asteroid = World.Filter.With<AsteroidComponent>().With<HealthComponent>().Build();
            _health = World.Filter.With<HealthComponent>().Build();
            World.GetStash<HealthComponent>().AsDisposable();
            World.GetStash<AsteroidComponent>().AsDisposable();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var asteroid in _asteroid)
            {
                if (asteroid.GetComponent<HealthComponent>().health <= 0)
                {
                    asteroid.Dispose();
                }
            }
            
            foreach (var entity in _health)
            {
                if (entity.GetComponent<HealthComponent>().health <= 0)
                {
                    entity.Dispose();
                }
            }
        }
    }
}