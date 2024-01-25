using _Assets.Scripts.Ecs.Events;
using _Assets.Scripts.Ecs.Health;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OnDamageDestroySystem))]
    public class OnDamageDestroySystem : UpdateSystem
    {
        private Event<DamagedEvent> _damagedEvent;

        public override void OnAwake() {
            _damagedEvent = World.GetEvent<DamagedEvent>();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var evt in _damagedEvent.publishedChanges) {
                Destroy(evt.targetEntityId);
            }
        }

        private void Destroy(EntityId target)
        {
            if (World.TryGetEntity(target, out var entity))
            {
                var healthComponent = entity.GetComponent<HealthComponent>();
                if (healthComponent.health <= 0)
                {
                    Destroy(healthComponent.gameObject);
                }
            }
        }
    }
}