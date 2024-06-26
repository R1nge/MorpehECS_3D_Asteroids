﻿using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Services.Spawners;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Shooting
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerShootingSystem))]
    public class PlayerShootingSystem : UpdateSystem
    {
        [Inject] private BulletSpawner _bulletSpawner;
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<ShootingComponent>().With<PlayerComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    var shootingComponent = entity.GetComponent<ShootingComponent>();
                    var bullet = _bulletSpawner.Spawn(shootingComponent.shootingPoint.position);
                    bullet.GetComponent<Rigidbody>().AddForce(shootingComponent.shootingPoint.right * shootingComponent.bulletSpeed);
                }
            }
        }
    }
}