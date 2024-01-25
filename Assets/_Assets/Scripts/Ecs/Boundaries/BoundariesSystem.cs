using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Boundaries
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BoundariesSystem))]
    public class BoundariesSystem : UpdateSystem
    {
        private Filter _movementWithInputFilter;

        public override void OnAwake() => _movementWithInputFilter = World.Filter.With<MovementComponent>().Build();

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movementWithInputFilter)
            {
                ref var movementComponent = ref entity.GetComponent<MovementComponent>();
                
                var pos = movementComponent.transform.position;

                if (pos.x < -10.5f)
                    pos.x = 10.5f;

                if (pos.x > 10.5f)
                    pos.x = -10.5f;

                if (pos.y < -5.8f)
                    pos.y = 5.8f;

                if (pos.y > 5.8f)
                    pos.y = -5.8f;

                movementComponent.transform.position = pos;
            }
        }
    }
}