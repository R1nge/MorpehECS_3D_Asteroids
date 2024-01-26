using System;
using System.Collections.Generic;
using _Assets.Scripts.Ecs.Asteroid;
using _Assets.Scripts.Services.Factories;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Assets.Scripts.Services.Spawners
{
    public class AsteroidsSpawner
    {
        private readonly AsteroidsFactory _asteroidsFactory;
        private readonly List<GameObject> _asteroids = new();
        //Caching to avoid allocations
        private readonly int _enumLength = Enum.GetNames(typeof(AsteroidSize)).Length;

        private AsteroidsSpawner(AsteroidsFactory asteroidsFactory) => _asteroidsFactory = asteroidsFactory;

        public void Spawn()
        {
            for (int i = 0; i < 20; i++)
            {
                SpawnRandomAsteroid();
            }
        }
        
        public void SpawnWithSize(AsteroidSize size, Vector3 position)
        {
            switch (size)
            {
                case AsteroidSize.Large:
                    var large = _asteroidsFactory.CreateLargeAsteroid();
                    large.transform.position = position;
                    _asteroids.Add(large);
                    break;
                case AsteroidSize.Medium:
                    var medium = _asteroidsFactory.CreateMediumAsteroid();
                    medium.transform.position = position;
                    _asteroids.Add(medium);
                    break;
                case AsteroidSize.Small:
                    var small = _asteroidsFactory.CreateSmallAsteroid();
                    small.transform.position = position;
                    _asteroids.Add(small);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size), size, null);
            }
        }

        public void SpawnRandomAsteroid()
        {
            var random = Random.Range(0, _enumLength);
            var size = (AsteroidSize)random;
            var position = GetRandomPosition();
            SpawnWithSize(size, position);
        }

        private Vector3 GetRandomPosition() => new(Random.Range(-100f, 100f), Random.Range(-100f, 100f));

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