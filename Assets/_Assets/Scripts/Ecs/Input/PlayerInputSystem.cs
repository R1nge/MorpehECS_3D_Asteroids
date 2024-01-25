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
            _inputFilter = World.Filter.With<InputComponent>().With<PlayerComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _inputFilter)
            {
                ref var inputComponent = ref entity.GetComponent<InputComponent>();
                inputComponent.direction = UnityEngine.Input.GetAxis("Horizontal") * Vector3.right +
                                           UnityEngine.Input.GetAxis("Vertical") * Vector3.forward;
            }
        }
    }
}