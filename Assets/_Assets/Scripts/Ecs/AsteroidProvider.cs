using _Assets.Scripts.Services.Factories;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using VContainer;

namespace _Assets.Scripts.Ecs
{
    public class AsteroidProvider : MonoProvider<AsteroidComponent>
    {
        [Inject] private AsteroidsFactory _asteroidsFactory;

        protected override void Initialize()
        {
            Entity.GetComponent<AsteroidComponent>().AsteroidsFactory = _asteroidsFactory;
        }
    }
}