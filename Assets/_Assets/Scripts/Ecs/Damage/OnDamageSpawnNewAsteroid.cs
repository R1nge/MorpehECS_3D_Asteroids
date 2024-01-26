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
                if (entity.Has<HealthComponent>())
                {
                    var healthComponent = entity.GetComponent<HealthComponent>();
                    if (healthComponent.health <= 0)
                    {
                        if (entity.Has<AsteroidComponent>())
                        {
                            var asteroid = entity.GetComponent<AsteroidComponent>();
                            Debug.Log($"Asteroid size: {asteroid.asteroidSize - 1}");
                            
                            //If 0, then 0 - 1 = 255 because of overflow
                            if ((byte)asteroid.asteroidSize - 1 > 0 && (byte)asteroid.asteroidSize - 1 < 255)
                            {
                                healthComponent.Dispose();
                                _asteroidsSpawner.SpawnWithSize(asteroid.asteroidSize - 1, asteroid.transform.position);
                            }
                            else
                            {
                                healthComponent.Dispose();
                                _asteroidsSpawner.SpawnRandomAsteroid();
                            }
                        }
                    }
                }
            }
        }
    }
}