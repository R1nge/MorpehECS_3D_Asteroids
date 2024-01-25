using _Assets.Scripts.Ecs.Shooting;
using _Assets.Scripts.Services.Factories;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs
{
    public class EcsBoot : Installer
    {
        [SerializeField] private PlayerShootingSystem playerShootingSystem;
        [Inject] private BulletFactory _bulletFactory;

        private void Start()
        {
            playerShootingSystem.Inject(_bulletFactory);
        }
    }
}