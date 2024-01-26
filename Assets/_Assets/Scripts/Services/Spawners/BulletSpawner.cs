using System.Collections.Generic;
using _Assets.Scripts.Services.Factories;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Spawners
{
    public class BulletSpawner
    {
        private readonly List<GameObject> _bullets = new();
        [Inject] private BulletFactory _bulletFactory;

        public GameObject Spawn(Vector3 position)
        {
            var bullet = _bulletFactory.Create(position);
            _bullets.Add(bullet);
            return bullet;
        }

        public void Destroy()
        {
            var count = _bullets.Count;

            for (int i = count - 1; i >= 0; i--)
            {
                Object.Destroy(_bullets[i]);
            }

            _bullets.Clear();
        }
    }
}