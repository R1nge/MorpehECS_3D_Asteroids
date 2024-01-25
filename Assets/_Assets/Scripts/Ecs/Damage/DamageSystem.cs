using _Assets.Scripts.Ecs.Events;
using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Requests;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Collections;
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
        private Request<DamageRequest> damageRequest;
        private Event<DamagedEvent> damagedEvent;

        public override void OnAwake()
        {
            damageRequest = World.GetRequest<DamageRequest>();
            damagedEvent = World.GetEvent<DamagedEvent>();
            damagedEvent.Subscribe(ApplyDamage);
        }

        public override void OnUpdate(float deltaTime)
        {
            //Consumes a request sent by some one else
            foreach (var request in damageRequest.Consume())
            {
                //Sends an event
                damagedEvent.NextFrame(new DamagedEvent
                {
                    targetEntityId = request.targetEntityId
                });
            }
        }

        private void ApplyDamage(FastList<DamagedEvent> damageEvents)
        {
            foreach (var damageEvent in damageEvents)
            {
                if (World.TryGetEntity(in damageEvent.targetEntityId, out var entity))
                {
                    entity.GetComponent<HealthComponent>().health -= damageEvent.damage;
                }
            }
        }
    }
}