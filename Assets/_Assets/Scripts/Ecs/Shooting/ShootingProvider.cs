using _Assets.Scripts.Services.Factories;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using VContainer;

namespace _Assets.Scripts.Ecs.Shooting
{
    public class ShootingProvider : MonoProvider<ShootingComponent>
    {
        [Inject] private BulletFactory _bulletFactory;

        protected override void Initialize()
        {
            Entity.GetComponent<ShootingComponent>().BulletFactory = _bulletFactory;
        }
    }
}