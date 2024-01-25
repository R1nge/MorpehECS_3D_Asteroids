using System.Collections.Generic;
using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Services.Spawners
{
    public class AsteroidsSpawner
    {
        private readonly AsteroidsFactory _asteroidsFactory;
        private readonly List<GameObject> _asteroids = new();

        private AsteroidsSpawner(AsteroidsFactory asteroidsFactory)
        {
            _asteroidsFactory = asteroidsFactory;
        }

        public void Spawn()
        {
            //TODO: spawn in different position and different amount
            //Since asteroids are spawned via factory, I can just pass it into them,
            //And call spawn method directly when one is destroyed

            var large = _asteroidsFactory.CreateLargeAsteroid();
            var medium = _asteroidsFactory.CreateMediumAsteroid();
            var small = _asteroidsFactory.CreateSmallAsteroid();
            _asteroids.Add(large);
            _asteroids.Add(medium);
            _asteroids.Add(small);
        }

        public void Destroy()
        {
            var count = _asteroids.Count;

            for (int i = count - 1; i >= 0; i--)
            {
                Object.Destroy(_asteroids[i]);
            }

            _asteroids.Clear();
        }
    }
}