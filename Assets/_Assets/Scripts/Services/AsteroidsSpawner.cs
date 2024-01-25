using _Assets.Scripts.Services.Factories;

namespace _Assets.Scripts.Services
{
    public class AsteroidsSpawner
    {
        private readonly AsteroidsFactory _asteroidsFactory;

        private AsteroidsSpawner(AsteroidsFactory asteroidsFactory)
        {
            _asteroidsFactory = asteroidsFactory;
        }
        
        public void Spawn()
        {
            //TODO: spawn in different position and different amount
            //Since asteroids are spawned via factory, I can just pass it into them,
            //And call spawn method directly when one is destroyed
            _asteroidsFactory.CreateLargeAsteroid();
            _asteroidsFactory.CreateMediumAsteroid();
            _asteroidsFactory.CreateSmallAsteroid();
        }
    }
}