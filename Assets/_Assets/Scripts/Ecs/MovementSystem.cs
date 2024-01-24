using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementSystem))]
    public class MovementSystem : UpdateSystem
    {
        private Filter _movementFilter;

        public override void OnAwake()
        {
            _movementFilter = World.Filter.With<MovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movementFilter)
            {
                ref var movementComponent = ref entity.GetComponent<MovementComponent>();
                Debug.Log(movementComponent.speed);
            }
        }
    }
}