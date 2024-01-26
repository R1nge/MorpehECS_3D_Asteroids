using _Assets.Scripts.Ecs.Asteroid;
using _Assets.Scripts.Ecs.Events;
using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Services.Spawners;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damage
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OnDamageSpawnNewAsteroid))]
    public class OnDamageSpawnNewAsteroid : UpdateSystem
    {
        private AsteroidsSpawner _asteroidsSpawner;
        private Event<DamagedEvent> _damagedEvent;

        public void Inject(AsteroidsSpawner asteroidsSpawner) => _asteroidsSpawner = asteroidsSpawner;

        public override void OnAwake() => _damagedEvent = World.GetEvent<DamagedEvent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (var evt in _damagedEvent.publishedChanges)
            {
                SpawnNewAsteroid(evt.TargetEntityId);
            }
        }

        private void SpawnNewAsteroid(EntityId target)
        {
            if (World.TryGetEntity(target, out var entity))
            {
                var healthComponent = entity.GetComponent<HealthComponent>();
                if (healthComponent.health <= 0)
                {
                    if (entity.Has<AsteroidComponent>())
                    {
                        var asteroid = entity.GetComponent<AsteroidComponent>();
                        //Check against overflow
                        if ((byte)asteroid.asteroidSize > 1)
                        {
                            if (asteroid.asteroidSize - 1 == 0)
                            {
                                _asteroidsSpawner.SpawnRandomAsteroid();
                            }
                            else
                            {
                                _asteroidsSpawner.SpawnWithSize(asteroid.asteroidSize - 1, asteroid.transform.position);
                            }
                        }
                        
                        healthComponent.Dispose();
                    }
                }
            }
        }
    }
}