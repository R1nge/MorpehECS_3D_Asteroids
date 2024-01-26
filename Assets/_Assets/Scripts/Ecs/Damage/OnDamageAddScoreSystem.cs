using _Assets.Scripts.Ecs.Asteroid;
using _Assets.Scripts.Ecs.Events;
using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Requests;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damage
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OnDamageAddScoreSystem))]
    public class OnDamageAddScoreSystem : UpdateSystem
    {
        private Event<DamagedEvent> _damagedEvent;
        private Request<AddPointsRequest> _addPointsRequest;

        public override void OnAwake()
        {
            _damagedEvent = World.GetEvent<DamagedEvent>();
            _addPointsRequest = World.GetRequest<AddPointsRequest>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var evt in _damagedEvent.publishedChanges)
            {
                if (evt.IsPlayer)
                {
                    AddScore(evt.TargetEntityId);    
                }
            }
        }

        private void AddScore(EntityId target)
        {
            if (World.TryGetEntity(target, out var entity))
            {
                var healthComponent = entity.GetComponent<HealthComponent>();
                if (healthComponent.health <= 0)
                {
                    if (entity.Has<AsteroidComponent>())
                    {
                        _addPointsRequest.Publish(new AddPointsRequest
                        {
                            points = entity.GetComponent<AsteroidComponent>().points
                        });
                    }
                }
            }
        }
    }
}