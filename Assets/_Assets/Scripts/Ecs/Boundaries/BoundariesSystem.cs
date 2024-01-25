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
            const float limitX = 10.5f;
            const float limitY = 5.8f;

            foreach (var entity in _movementWithInputFilter)
            {
                ref var movementComponent = ref entity.GetComponent<MovementComponent>();

                var pos = movementComponent.rigidbody.position;

                if (pos.x < -limitX)
                    pos.x = limitX;

                if (pos.x > limitX)
                    pos.x = -limitX;

                if (pos.y < -limitY)
                    pos.y = limitY;

                if (pos.y > limitY)
                    pos.y = -limitY;

                movementComponent.rigidbody.position = pos;
            }
        }
    }
}