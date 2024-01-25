using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh.Providers;

namespace _Assets.Scripts
{
    public class Bullet : MonoProvider<MovementComponent>
    {
        private void Awake()
        {
            Destroy(gameObject, 5f);
        }
    }
}