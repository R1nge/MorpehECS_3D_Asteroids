using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Input
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerInputSystem))]
    public class PlayerInputSystem : UpdateSystem
    {
        private Filter _inputFilter;

        public override void OnAwake()
        {
            _inputFilter = World.Filter.With<MovementComponent>().With<InputComponent>().With<PlayerComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var playerInput in _inputFilter)
            {
                ref var inputComponent = ref playerInput.GetComponent<InputComponent>();
                ref var movementComponent = ref playerInput.GetComponent<MovementComponent>();
                
                var direction = Vector3.zero;

                if (UnityEngine.Input.GetKey(KeyCode.W))
                {
                    direction = movementComponent.rigidbody.transform.right;
                }

                if (UnityEngine.Input.GetKey(KeyCode.A))
                {
                    direction.z = 1;
                }
                else if (UnityEngine.Input.GetKey(KeyCode.D))
                {
                    direction.z = -1;
                }

                inputComponent.direction = direction;
            }
        }
    }
}