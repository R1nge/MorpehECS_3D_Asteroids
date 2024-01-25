using System;
using _Assets.Scripts.Services.Factories;
using Scellecs.Morpeh;
using Random = UnityEngine.Random;

namespace _Assets.Scripts.Ecs
{
    public struct AsteroidComponent : IComponent, IDisposable
    {
        public AsteroidsFactory AsteroidsFactory;

        public void Dispose()
        {
            //TODO: use asteroids spawner
            var number = Random.Range(0, 3);
            switch (number)
            {
                case 0:
                    AsteroidsFactory.CreateSmallAsteroid();
                    break;
                case 1:
                    AsteroidsFactory.CreateMediumAsteroid();
                    break;
                case 2:
                    AsteroidsFactory.CreateLargeAsteroid();
                    break;
            }
        }
    }
}