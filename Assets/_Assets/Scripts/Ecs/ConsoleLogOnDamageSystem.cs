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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ConsoleLogOnDamageSystem))]
    public class ConsoleLogOnDamageSystem : UpdateSystem
    {
        private Event<DamagedEvent> damagedEvent;

        public override void OnAwake() {
            damagedEvent = World.GetEvent<DamagedEvent>();
        }

        public override void OnUpdate(float deltaTime) {
            foreach (var evt in damagedEvent.publishedChanges) {
                Log(evt.targetEntityId);
            }
        }

        private void Log(EntityId target)
        {
            if (World.TryGetEntity(target, out var entity))
            {
                Debug.Log(target);
                Debug.Log(entity.GetComponent<HealthComponent>().health);
            }
            
        }
    }
}