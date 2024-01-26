using _Assets.Scripts.Ecs.Events;
using _Assets.Scripts.Ecs.Health;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.StateMachine;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damage
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OnDamageGameOverSystem))]
    public class OnDamageGameOverSystem : UpdateSystem
    {
        private PlayerLivesService _playerLivesService;
        private Event<DamagedEvent> _damagedEvent;

        public void Inject(PlayerLivesService playerLivesService) => _playerLivesService = playerLivesService;

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
                if (!entity.IsNullOrDisposed())
                {
                    if (entity.Has<HealthComponent>())
                    {
                        var healthComponent = entity.GetComponent<HealthComponent>();
                        if (entity.Has<PlayerComponent>())
                        {
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
}