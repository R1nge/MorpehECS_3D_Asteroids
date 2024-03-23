using _Assets.Scripts.Ecs.Events;
using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Damage
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OnDamageGameOverSystem))]
    public class OnDamageGameOverSystem : UpdateSystem
    {
        [Inject] private PlayerLivesService _playerLivesService;
        private Event<DamagedEvent> _damagedEvent;

        public override void OnAwake() => _damagedEvent = World.GetEvent<DamagedEvent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (var evt in _damagedEvent.publishedChanges)
            {
                GameOver(evt.TargetEntityId);
            }
        }

        private void GameOver(EntityId target)
        {
            if (World.TryGetEntity(target, out var entity))
            {
                if (entity.Has<PlayerComponent>())
                {
                    if (entity.Has<HealthComponent>())
                    {
                        var healthComponent = entity.GetComponent<HealthComponent>();
                        if (healthComponent.health <= 0)
                        {
                            _playerLivesService.DecreaseLives(1);
                        }
                    }
                }
            }
        }
    }
}