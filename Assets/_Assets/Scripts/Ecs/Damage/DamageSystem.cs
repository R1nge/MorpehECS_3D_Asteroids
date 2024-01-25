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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DamageSystem))]
    public class DamageSystem : UpdateSystem
    {
        private Request<DamageRequest> _damageRequest;
        private Event<DamagedEvent> _damagedEvent;

        public override void OnAwake()
        {
            _damageRequest = World.GetRequest<DamageRequest>();
            _damagedEvent = World.GetEvent<DamagedEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            //Consumes a request sent by some one else
            foreach (var request in _damageRequest.Consume())
            {
                ApplyDamage(request.targetEntityId, request.damage);
                
                //Sends an event
                _damagedEvent.NextFrame(new DamagedEvent
                {
                    targetEntityId = request.targetEntityId
                });
            }
        }

        private void ApplyDamage(EntityId entityId, int damage)
        {
            if (World.TryGetEntity(entityId, out var entity))
            {
                entity.GetComponent<HealthComponent>().health -= damage;
            }
        }
    }
}