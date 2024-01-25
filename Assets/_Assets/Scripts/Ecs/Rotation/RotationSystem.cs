using _Assets.Scripts.Ecs.Input;
using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Rotation
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RotationSystem))]
    public class RotationSystem : FixedUpdateSystem
    {
        private Filter _movementWithInputFilter;

        public override void OnAwake()
        {
            _movementWithInputFilter = World.Filter.With<MovementComponent>().With<InputComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movementWithInputFilter)
            {
                ref var inputComponent = ref entity.GetComponent<InputComponent>();
                ref var movementComponent = ref entity.GetComponent<MovementComponent>();
                var deltaRotation = Quaternion.Euler(0, 0, inputComponent.direction.z * movementComponent.speed * deltaTime);
                movementComponent.rigidbody.MoveRotation(movementComponent.rigidbody.rotation * deltaRotation);
            }
        }
    }
}