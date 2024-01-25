using _Assets.Scripts.Ecs.Input;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementSystem))]
    public class MovementSystem : FixedUpdateSystem
    {
        private Filter _movementWithInputFilter;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _movementWithInputFilter = World.Filter.With<MovementComponent>().With<InputComponent>().Build();
            foreach (var entity in _movementWithInputFilter)
            {
                ref var inputComponent = ref entity.GetComponent<InputComponent>();
                ref var movementComponent = ref entity.GetComponent<MovementComponent>();
                movementComponent.rigidbody.AddForce(inputComponent.direction * movementComponent.speed * deltaTime, ForceMode.Force);
            }
        }
    }
}