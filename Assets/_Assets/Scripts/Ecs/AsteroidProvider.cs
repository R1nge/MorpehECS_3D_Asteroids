using _Assets.Scripts.Services.Factories;
using Scellecs.Morpeh.Providers;
using VContainer;

namespace _Assets.Scripts.Ecs
{
    public class AsteroidProvider : MonoProvider<AsteroidComponent>
    {
        [Inject] private AsteroidsFactory _asteroidsFactory;
        
        //TODO: use own method instead
        // private void OnDestroy()
        // {
        //     var number = Random.Range(0, 3);
        //     switch (number)
        //     {
        //         case 0:
        //             _asteroidsFactory.CreateSmallAsteroid();
        //             break;
        //         case 1:
        //             _asteroidsFactory.CreateMediumAsteroid();
        //             break;
        //         case 2:
        //             _asteroidsFactory.CreateLargeAsteroid();
        //             break;
        //     }
        // }
    }
}